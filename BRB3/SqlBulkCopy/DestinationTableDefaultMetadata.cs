using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Globalization;

namespace ErikEJ.SqlCe
{
    public sealed class DestinationTableDefaultMetadata
    {

        public string ColumnName
        {
            get;
            set;
        }

        public bool IsNullable
        {
            get;
            set;
        }

        public bool HasDefault
        {
            get;
            set;
        }

        public DestinationTableDefaultMetadata(IDataReader reader)
        {
            this.ColumnName = (reader.GetString(0) ?? string.Empty).ToUpper();
            this.IsNullable = reader.GetString(1).Equals("YES", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            this.HasDefault = reader.GetBoolean(2);
        }

        public static List<DestinationTableDefaultMetadata> GetDataForTable(SqlCeConnection conn, string tableName)
        {
            var retVal = new List<DestinationTableDefaultMetadata>();

            using (SqlCeCommand ordCmd = new SqlCeCommand(string.Format(CultureInfo.InvariantCulture,
                    "SELECT Column_Name, Is_Nullable, Column_HasDefault FROM information_schema.columns WHERE TABLE_NAME = N'{0}' ORDER BY Ordinal_Position;", tableName),
                    conn))
            {
                var val = ordCmd.ExecuteReader();
                while (val.Read())
                {
                    retVal.Add(new DestinationTableDefaultMetadata(val));
                }
            }

            return retVal;
        }
    }
}
