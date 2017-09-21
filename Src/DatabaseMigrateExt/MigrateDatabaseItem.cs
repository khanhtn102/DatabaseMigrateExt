﻿using System.Configuration;
using System.Data.SqlClient;

namespace DatabaseMigrateExt
{
    public class MigrateDatabaseItem
    {
        public static MigrateDatabaseItem CreateDatabaseItem(string databaseKey)
        {
            return new MigrateDatabaseItem
            {
                DatabaseKey = databaseKey
            };
        }

        public string DatabaseKey { get; set; }
        public string RootNamespace => ConfigurationManager.AppSettings[$"mgr:RootNamespace"];
        public string ConnectionString => ConfigurationManager.AppSettings[$"mgr:{DatabaseKey}_ConnString"];

        public int ConnectionTimeout
        {
            get
            {
                var builder = new SqlConnectionStringBuilder(this.ConnectionString);
                return builder.ConnectTimeout;
            }
        }

        public string SqlArchitectureRefScriptNamespace     => $"{RootNamespace}.{DatabaseKey}.SqlDataAndStructure._RefScript";
        public string SqlArchitectureChangeScriptNamespace  => $"{RootNamespace}.{DatabaseKey}.SqlDataAndStructure";

        public string SqlFunctionRefScriptNamespace         => $"{RootNamespace}.{DatabaseKey}.SqlFunction._RefScript";
        public string SqlFunctionChangeScriptNamespace      => $"{RootNamespace}.{DatabaseKey}.SqlFunction";

        public string SqlStoredRefScriptNamespace           => $"{RootNamespace}.{DatabaseKey}.SqlStored._RefScript";
        public string SqlStoredChangeScriptNamespace        => $"{RootNamespace}.{DatabaseKey}.SqlStored";
        
    }
}
