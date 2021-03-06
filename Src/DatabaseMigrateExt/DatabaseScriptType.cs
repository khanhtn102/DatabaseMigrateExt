﻿using System.ComponentModel;

namespace DatabaseMigrateExt
{
    public enum DatabaseScriptType
    {
        [Description("Data And Structure")]
        SqlDataAndStructure = 1000,
        [Description("Function")]
        SqlFunction = 2000,
        [Description("Stored Procedure And Scripts")]
        SqlStoredProcedureAndTsqlScripts = 3000
    }
}
