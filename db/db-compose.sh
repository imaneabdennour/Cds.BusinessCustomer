#!/bin/bash
# Manage database containers.
#
# Copyright (c) 2019  Cdiscount

APPDIR=`dirname "$0"`
APPNAME=`basename "$0"`

function option_error() {
	echo "$@" >&2
	echo "Try '$APPNAME --help' for more information." >&2
	exit 2
}

function exit_error() {
	echo "$@" >&2
	exit 1
}

function print_help() {
	cat <<EOF
Manage database containers.

Usage:
  $APPNAME [options] COMMAND [DATABASE_TYPE...]
  $APPNAME -h|--help

Options:
  -p, --project-name NAME     Specify an alternate project name (default: parent
                              directory name, that should be the project directory)
  -t, --test                  Set the test mode, i.e. do not use the default Docker
                              Compose override and use 'docker-compose.testoverride.yml'
                              if it exists

Commands:
  down          Stop and remove database server containers
  start         Start database server containers
  stop          Stop database server containers
  up            Create, start and initialize database server containers
EOF
}

function compose_args() {
	local __resultarray=$1

	args=(-p "$PROJECT_NAME")
	if [ -n "$TEST_MODE" ]
	then
		args[${#args[@]}]="-f"
		args[${#args[@]}]="docker-compose.yml"
		if [ -e "docker-compose.testoverride.yml" ]
		then
			args[${#args[@]}]="-f"
			args[${#args[@]}]="docker-compose.testoverride.yml"
		fi
	fi

	eval $__resultarray='("${args[@]}")'
}

function init_db() {
	compose_args dbargs
	docker-compose "${dbargs[@]}" up --force-recreate db_instance
	docker-compose "${dbargs[@]}" create --force-recreate db_structure

	if [ -n "$TEST_MODE" ]
	then
		container_id=$(docker-compose "${dbargs[@]}" ps -q db_structure)
		docker cp . ${container_id}:/workspace/db
	fi

	docker-compose "${dbargs[@]}" up db_structure
	docker-compose "${dbargs[@]}" rm -f
}

function compose_do() {
	dbtype="$1"

	pushd "$APPDIR/$dbtype" >/dev/null

	compose_args args

	case "$COMMAND" in
	"up")
		docker-compose "${args[@]}" up -d

		for db in */
		do
			[ -d "$db" ] && [ -e "$db/docker-compose.yml" ] && (cd "$db" && init_db) &
			wait
		done
		wait
		;;
	*)
		docker-compose "${args[@]}" $COMMAND
		;;
	esac

	echo "$dbtype: $COMMAND"
	popd >/dev/null
}

while [ -n "$1" ]
do
	shift=1
	case "$1" in
	-h|--help)
		print_help
		exit 0
		;;
	-t|--test)
		TEST_MODE=1
		;;
	-p|--project-name)
		PROJECT_NAME="$2"
		shift=2
		;;
	-*)
		option_error "Invalid option '$1'"
		;;
	*)
		break
		;;
	esac
	shift $shift
done

[ -n "$PROJECT_NAME" ] || PROJECT_NAME=$(basename "`realpath "$APPDIR/.."`")

COMMAND="$1"
shift

case "$COMMAND" in
up|start|down|stop)
	;;
"")
	option_error "Missing command"
	;;
*)
	option_error "Invalid command '$COMMAND'"
	;;
esac

while [ -n "$1" ]
do
	case "$1" in
	-*)
		option_error "Invalid command option '$1'"
		;;
	*)
		break
		;;
	esac
	shift
done

dbtype_list=()
dbtype_args=("$@")
if (( ${#dbtype_args[@]} == 0 ))
then
	for path in "$APPDIR/"*/
	do
		[ -d "$path" ] && [ -e "$path/docker-compose.yml" ] && \
			dbtype_list[${#dbtype_list[@]}]=$(basename "$path")
	done
else
	for arg in "${dbtype_args[@]}"
	do
		dbname=$(basename "$arg")
		[ ! -d "$APPDIR/$dbname" ] && exit_error "Invalid database type '$arg': no such directory"
		[ ! -e "$APPDIR/$dbname/docker-compose.yml" ] && \
			exit_error "Invalid database type '$arg': missing 'docker-compose.yml'"
		dbtype_list[${#dbtype_list[@]}]="$dbname"
	done
fi
(( ${#dbtype_list[@]} == 0 )) && exit_error "Nothing to do: no database to process"

for dbtype in "${dbtype_list[@]}"
do
	compose_do "$dbtype"
done
