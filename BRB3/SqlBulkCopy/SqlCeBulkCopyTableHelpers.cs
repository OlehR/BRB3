using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Globalization;

namespace ErikEJ.SqlCe
{
    /// <summary>
    /// Helpers for queries against sql ce for things like schema and auto id columns
    /// </summary>
    public static class SqlCeBulkCopyTableHelpers
    {
        public static int IdentityOrdinal(SqlCeConnection conn, SqlCeBulkCopyOptions copyOption, string tableName)
        {
            int ordinal = -1;
            if (!IsCopyOption(SqlCeBulkCopyOptions.KeepIdentity, copyOption))
            {
                using (SqlCeCommand ordCmd = new SqlCeCommand(string.Format(CultureInfo.InvariantCulture,
                    "SELECT ORDINAL_POSITION FROM information_schema.columns WHERE TABLE_NAME = N'{0}' AND AUTOINC_SEED IS NOT NULL", tableName),
                    conn))
                {
                    object val = ordCmd.ExecuteScalar();
                    if (val != null)
                        ordinal = (int)val - 1;
                }
            }
            return ordinal;
        }

        public static int IdentityOrdinalIgnoreOptions(SqlCeConnection conn, string tableName)
        {
            int ordinal = -1;
            using (SqlCeCommand ordCmd = new SqlCeCommand(string.Format(CultureInfo.InvariantCulture,
                "SELECT ORDINAL_POSITION FROM information_schema.columns WHERE TABLE_NAME = N'{0}' AND AUTOINC_SEED IS NOT NULL", tableName),
                conn))
            {
                object val = ordCmd.ExecuteScalar();
                if (val != null)
                    ordinal = (int)val - 1;
            }
            return ordinal;
        }

        public static bool RecordExistsInTable(string connString, string tableName, string columnName, int id)
        {

            using (var conn = new SqlCeConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCeCommand(string.Format("SELECT TOP 1 {1} FROM [{0}] Where {1} = {2};", tableName, columnName, id), conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        public static bool IsCopyOption(SqlCeBulkCopyOptions options, SqlCeBulkCopyOptions copyOption)
        {
            return ((options & copyOption) == options);
        }
    }
}
