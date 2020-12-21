# DemoMongoDb mongo database

The DemoMongoDb database will be created into your local mongodb server allong with the collections and validation rules you have defined.

## Connection string

Use this connection string in the functional test settings :

    mongodb://monuser:12345-abcde@mongodb:27017/DemoMongoDb

Use this connection string to run your application localy in you IDE:

    mongodb://monuser:12345-abcde@localhost:27017/DemoMongoDb

### Adapt the connection string

The connection information are set into the file `database-configuration`:

- **DATABASE_NAME** : actual name of your database, whih is originaly
  DemoMongoDb.
- **DATABASE_USER** : the user associated to your database, it will be created if not existing. By default it is : monuser.
- **DATABASE_PASSWORD** : The password of your user, 12345-abcde by default.

If you change one of this value, you have to adapt your connection string
accordingly.

The connection string is organized as is:

    mongodb://DATABASE_USER:DATABASE_PASSORD@HOST:PORT/DATABASE_NAME

- **HOST**: the host is the adress of your server. If you need to access it locally (from you IDE for example) it will be localhost. Otherwise, for functional test it will be `mongodb`.
- **PORT**: the port is by default `27017`. It has to be 27017 for functional test, but for local test you should use the one set at the server level.

## Collections and field validation

By default there is no model validation. So when you run the database you can create whatever resource you want. But during functional test the strictness of the control is raised up. So you have to describe your collections and fields to pass the functionals test.

### Describe your collections

The description of your fields is done into the `model` directory. Each file represent a collection. The file name is actually the collection name like : `collectionName.yaml`.

Then content follow the official documentation : [mongodb schema
validation](https://docs.mongodb.com/manual/core/schema-validation/). You can also consult [CT-DATA](https://confluence.cdiscount.com/display/CTDT/CT+-+Collection+MongoDB)

### Raise up stritcess

By default the database is open to any creation or edition. Only in functional test mode the creation of collection and fields is limited.

You can nevertheless use the same level of control by changing the value into the file `database-strictness-configuration`.
