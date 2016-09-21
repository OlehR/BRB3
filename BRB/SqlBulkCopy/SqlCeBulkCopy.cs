using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace ErikEJ.SqlCe
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ce")]
    public class SqlCeBulkCopy : IDisposable 
    {
        private int notifyAfter;
        private readonly SqlCeConnection conn;
        private readonly bool ownsConnection;
        private readonly bool keepNulls;
        private readonly bool keepIdentity;
        private string destination;
        private readonly SqlCeBulkCopyOptions options;
        private SqlCeBulkCopyColumnMappingCollection mappings = new SqlCeBulkCopyColumnMappingCollection();
        private readonly SqlCeTransaction trans;
        private static readonly Type DbNullType = typeof(System.DBNull);

        public SqlCeBulkCopy(SqlCeConnection connection)
        {
            conn = connection;
        }

        public SqlCeBulkCopy(SqlCeConnection connection, SqlCeBulkCopyOptions copyOptions)
        {
            conn = connection;
            options = copyOptions;
            keepNulls = IsCopyOption(SqlCeBulkCopyOptions.KeepNulls);
            keepIdentity = IsCopyOption(SqlCeBulkCopyOptions.KeepIdentity);
        }

        public SqlCeBulkCopy(string connectionString)
        {
            conn = new SqlCeConnection(connectionString);
            ownsConnection = true;
        }
        public SqlCeBulkCopy(string connectionString, SqlCeBulkCopyOptions copyOptions)
        {
            conn = new SqlCeConnection(connectionString);
            ownsConnection = true;
            options = copyOptions;
            keepNulls = IsCopyOption(SqlCeBulkCopyOptions.KeepNulls);
            keepIdentity = IsCopyOption(SqlCeBulkCopyOptions.KeepIdentity);
        }

        //TODO Implement
        public SqlCeBulkCopyColumnMappingCollection ColumnMappings
        {
            get
            {
                return mappings;
            }
        }

        public string DestinationTableName 
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }

        public SqlCeBulkCopyColumnMappingCollection Mappings
        {
            get
            {
                return mappings;
            }
            set
            {
                mappings = value;
            }
        }

        public int NotifyAfter 
        {
            get
            {
                return notifyAfter;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Must be > 0");
                }
                notifyAfter = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ce")]
        public event EventHandler<SqlCeRowsCopiedEventArgs> RowsCopied;

        public void Close()
        {
            if (ownsConnection && conn != null)
            {
                conn.Dispose();
            }
        }
        
        public void WriteToServer(DataRow[] rows)
        {
            throw new NotImplementedException();
        }

        public void WriteToServer(DataTable table)
        {
            WriteToServer(table, 0);
        }

        public void WriteToServer(DataTable table, DataRowState rowState)
        {
            WriteToServer(new SqlCeBulkCopyDataTableAdapter(table, rowState));
        }

       /* public void WriteToServer(DataTable table, DataRowState rowState)
        {
            CheckDestination();

            if (mappings.Count < 1)
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SqlCeCommand cmd = new SqlCeCommand(destination, conn))
                {
                    cmd.CommandType = CommandType.TableDirect;
                    using (SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable))
                    {
                        int idOrdinal = IdentityOrdinal();
                        int offset = 0;
                        SqlCeUpdatableRecord rec = rs.CreateRecord();
                        //mappings.ValidateCollection(rec, table.Columns);

                        int fieldCount = rec.FieldCount;
                        if (idOrdinal > -1)
                        {
                            fieldCount = fieldCount-1 ;
                            offset = 1;
                        }
                        if (table.Columns.Count-1 != fieldCount)
                        {
                            throw new ArgumentException("Field counts do not match " + fieldCount + " и " + table.Columns.Count+", "+idOrdinal);
                        }
                        int rowCounter = 0;
                        int totalRows = 0;
                        IdInsertOn();
                        foreach (DataRow row in table.Rows)
                        {
                            // Never process deleted rows
                            if (row.RowState == DataRowState.Deleted)
                                continue;
                            
                            // if a specific rowstate is requested
                            if (rowState != 0)
                            {
                                if (row.RowState != rowState)
                                    continue;
                            }

                            for (int i = 0; i < rec.FieldCount; i++)
                            {
                                // Let the destination assign identity values
                                if (!keepIdentity && i == idOrdinal)
                                    continue;

                                int y = i - offset;

                                if (row[y] != null && row[y].GetType() != typeof(System.DBNull))
                                {
                                    rec.SetValue(i, row[y]);
                                }
                                else
                                {
                                    if (keepNulls)
                                    {
                                        rec.SetValue(i, DBNull.Value);
                                    }
                                    else
                                    {
                                        rec.SetDefault(i);
                                    }
                                }
                                // Fire event if needed
                                if (notifyAfter > 0 && rowCounter == notifyAfter)
                                {
                                    FireRowsCopiedEvent(totalRows);
                                    rowCounter = 0;
                                }
                            }
                            rowCounter++;
                            totalRows++;
                            rs.Insert(rec);
                        }
                        IdInsertOff();
                    }
                }

                
            }
        } */

        public void WriteToServer(IDataReader reader)

        {
            try
            {
                CheckDestination();

                if (mappings.Count < 1)
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    using (SqlCeCommand cmd = new SqlCeCommand(destination, conn))
                    {
                        cmd.CommandType = CommandType.TableDirect;
                        using (SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable))
                        {
                            int idOrdinal = IdentityOrdinal();
                            int offset = 0;
                            SqlCeUpdatableRecord rec = rs.CreateRecord();
                            //mappings.ValidateCollection(rec, table.Columns);

                            int fieldCount = rec.FieldCount;
                            if (idOrdinal > -1)
                            {
                                fieldCount = fieldCount - 1;
                                offset = 1;
                            }
                            if (reader.FieldCount != rec.FieldCount)
                            {
                                throw new ArgumentException("Field counts do not match");
                            }
                            int rowCounter = 0;
                            int totalRows = 0;
                            IdInsertOn();
                            while (reader.Read())
                            {
                                for (int i = 0; i < fieldCount; i++)
                                {

                                    // Let the destination assign identity values
                                    if (!keepIdentity && i == idOrdinal)
                                        continue;

                                    int y = i - offset;

                                    if (reader[y] != null && reader[y].GetType() != typeof(System.DBNull))
                                    {
                                        rec.SetValue(i, reader[y]);
                                    }
                                    else
                                    {
                                        if (keepNulls)
                                        {
                                            rec.SetValue(i, DBNull.Value);
                                        }
                                        else
                                        {
                                            rec.SetDefault(i);
                                        }
                                    }
                                    // Fire event if needed
                                    if (notifyAfter > 0 && rowCounter == notifyAfter)
                                    {
                                        FireRowsCopiedEvent(totalRows);
                                        rowCounter = 0;
                                    }
                                }
                                rowCounter++;
                                totalRows++;
                                rs.Insert(rec);
                            }
                            IdInsertOff();
                        }
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }

        private void WriteToServer(ISqlCeBulkCopyInsertAdapter adapter)
        {
            CheckDestination();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            List<KeyValuePair<int, int>> mappings = null;

            if (Mappings.Count > 0)
            {
                //mapping are set, and should be validated
                mappings = Mappings.ValidateCollection(conn, adapter, options, destination);
            }
            else
            {
                //create default column mappings
                mappings = SqlCeBulkCopyColumnMappingCollection.Create(conn, adapter, options, destination);
            }

            SqlCeTransaction localTrans = trans ?? conn.BeginTransaction();

            using (SqlCeCommand cmd = new SqlCeCommand(destination, conn, localTrans))
            {
                cmd.CommandType = CommandType.TableDirect;
                using (SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable))
                {
                    int idOrdinal = SqlCeBulkCopyTableHelpers.IdentityOrdinal(conn, options, destination);
                    SqlCeUpdatableRecord rec = rs.CreateRecord();

                    int rowCounter = 0;
                    int totalRows = 0;
                    IdInsertOn();

                    //Converting to an array removed the perf issue of a list and foreach statement.
                    var cm = mappings.ToArray();

                    while (adapter.Read())
                    {
                        if (adapter.SkipRow())
                            continue;

                        for (int i = 0; i < cm.Length; i++)
                        {
                            //caching the values this way do not cause a perf issue.
                            var sourceIndex = cm[i].Key;
                            var destIndex = cm[i].Value;

                            // Let the destination assign identity values
                            if (!keepIdentity && destIndex == idOrdinal)
                                continue;

                            //determine if we should ever allow this in the map.
                            if (sourceIndex < 0)
                                continue;

                            var value = sourceIndex > -1 ? adapter.Get(sourceIndex) : null;

                            if (value != null && value.GetType() != DbNullType)
                            {
                                rec.SetValue(destIndex, value);
                            }
                            else
                            {
                                //we can't write to an auto number column so continue
                                if (keepNulls && destIndex == idOrdinal)
                                    continue;

                                if (keepNulls)
                                {
                                    rec.SetValue(destIndex, DBNull.Value);
                                }
                                else
                                {
                                    rec.SetDefault(destIndex);
                                }
                            }
                            // Fire event if needed
                            if (notifyAfter > 0 && rowCounter == notifyAfter)
                            {
                                FireRowsCopiedEvent(totalRows);
                                rowCounter = 0;
                            }
                        }
                        rowCounter++;
                        totalRows++;
                        rs.Insert(rec);
                    }
                    IdInsertOff();
                }
            }

            //if we have our own transaction, we will commit it
            if (trans == null)
            {
                localTrans.Commit(CommitMode.Immediate);
            }
        }


        private void CheckDestination()
        {
            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentException("DestinationTable not specified");
            }
        }

        private void IdInsertOn()
        {
            if (keepIdentity)
            {
                using (
                    SqlCeCommand idCmd =
                        new SqlCeCommand(
                            string.Format(CultureInfo.InvariantCulture, "SET IDENTITY_INSERT [{0}] ON",
                                          DestinationTableName), conn))
                {
                    idCmd.ExecuteNonQuery();
                }
            }
        }

        private void IdInsertOff()
        {
            if (keepIdentity)
            {
                using (SqlCeCommand idCmd = new SqlCeCommand(string.Format(CultureInfo.InvariantCulture, "SET IDENTITY_INSERT [{0}] OFF", DestinationTableName), conn))
                {
                    idCmd.ExecuteNonQuery();
                }
            }
        }

        private int IdentityOrdinal()
        {
            int ordinal = -1;
            if (!IsCopyOption(SqlCeBulkCopyOptions.KeepIdentity))
            {
                using (SqlCeCommand ordCmd = new SqlCeCommand(string.Format(CultureInfo.InvariantCulture, "SELECT ORDINAL_POSITION FROM information_schema.columns WHERE TABLE_NAME = N'{0}' AND AUTOINC_SEED IS NOT NULL", DestinationTableName), conn))
                {
                    object val = ordCmd.ExecuteScalar();
                    if (val != null)
                        ordinal = (int)val - 1;
                }
            }
            return ordinal;
        }


        private void OnRowsCopied(SqlCeRowsCopiedEventArgs e)
        {
             if(RowsCopied != null)
            {
                RowsCopied(this, e);
            }
        }

        private void FireRowsCopiedEvent(long rowsCopied)
        {
            SqlCeRowsCopiedEventArgs args = new SqlCeRowsCopiedEventArgs(rowsCopied);
            OnRowsCopied(args);
        }

        private bool IsCopyOption(SqlCeBulkCopyOptions copyOption)
        {
            return ((options & copyOption) == copyOption);
        }


        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (ownsConnection && conn != null)
                {
                    conn.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
