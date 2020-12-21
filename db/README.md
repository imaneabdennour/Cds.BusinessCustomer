# Local databases

You can test all your interactions with your databases locally without
interferences with the other users.

With one command you will start all your databases pre-set with your schema and data. This will also be used for the functional tests.

## Requirement

To use this tool, you need:

- Bash (or gitbash on windows)
- Docker running

It will start several docker containers and expose some ports. You should check first if you don't have any other service running on the port defined in the databases.

## Quick start

### start

To start the databases you simply need to run :

    ./db-compose.sh up

It will start all the database servers and initiate all the databases described in the sub-directories.

> **You can configure the databases by editing the files in the _sub-directories_**

> **The connection strings of the databases are availabled into their readme.**

### stop

To stop you simply need to run :

    ./db-compose.sh down

## Help

The `db-compose` script has options for functional test purpose:

    Manage database containers.

    Usage:
      db-compose.sh [options] COMMAND [DATABASE_TYPE...]
      db-compose.sh -h|--help

    Options:
      -p, --project-name NAME     Specify an alternate project name (default:     parent
                                  directory name, that should be the project     directory)
      -t, --test                  Set the test mode, i.e. do not use the     default Docker
                                  Compose override and use     'docker-compose.testoverride.yml'
                                  if it exists

    Commands:
      down          Stop and remove database server containers
      start         Start database server containers
      stop          Stop database server containers
      up            Create, start and initialize database server containers
