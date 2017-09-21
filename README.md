# DatabaseMigrateExt
A new way, new rule to work with MSSQL database version use fluent migrator

## Installation
>Install-Package DatabaseMigrateExt

## Sample Project

See [Sample Project](https://github.com/minhhungit/DatabaseMigrateExt/tree/master/Tutorials/DatabaseMigrateRunner) at [https://github.com/minhhungit/DatabaseMigrateExt/tree/master/Tutorials/DatabaseMigrateRunner](https://github.com/minhhungit/DatabaseMigrateExt/tree/master/Tutorials/DatabaseMigrateRunner)

## Config
```xml
<add key="mgr:DatabaseKeys" value="MovieStore, InventoryDb"/>
<add key="mgr:RootNamespace" value="DatabaseMigrateRunner.Migrations"/>

<add key="mgr:MovieStore_ConnString" value="Data Source=JINPC\MSSQL2014;Initial Catalog=FirstDb;User ID=u;Password=p;Connection Timeout=6000;"/>
<add key="mgr:InventoryDb_ConnString" value="Data Source=JINPC\MSSQL2014;Initial Catalog=SecondDb;User ID=u;Password=p;Connection Timeout=6000;"/>
```

## Migration Scripts
<img src="https://raw.githubusercontent.com/minhhungit/DatabaseMigrateExt/master/wiki/sample%20migration%20structure.png" />

## Run
```c#
using DatabaseMigrateExt;
.
.
static void Main(string[] args)
{
    var setting = new MigrationSetting
    {
        DatabaseKeys = ConfigurationManager.AppSettings["mgr:DatabaseKeys"].Split(',').Select(p => p.Trim()).ToList(),
        MigrationAssembly = Assembly.GetExecutingAssembly()
    };

    // apply
    MigrationManager.Instance.Run(setting);

    Console.ReadKey();
}
```
