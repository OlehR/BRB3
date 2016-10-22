using System;
using System.Collections.Generic;
using System.Text;

namespace ErikEJ.SqlCe
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ce")]
    public sealed class SqlCeBulkCopyColumnMapping
    {
        // Fields
        internal string _destinationColumnName;
        internal int _destinationColumnOrdinal;
        internal string _sourceColumnName;
        internal int _sourceColumnOrdinal;

        // Methods
        public SqlCeBulkCopyColumnMapping()
        {
        }

        public SqlCeBulkCopyColumnMapping(int sourceColumnOrdinal, int destinationOrdinal)
        {
            SourceOrdinal = sourceColumnOrdinal;
            DestinationOrdinal = destinationOrdinal;
        }

        public SqlCeBulkCopyColumnMapping(int sourceColumnOrdinal, string destinationColumn)
        {
            SourceOrdinal = sourceColumnOrdinal;
            DestinationColumn = destinationColumn;
        }

        public SqlCeBulkCopyColumnMapping(string sourceColumn, int destinationOrdinal)
        {
            SourceColumn = sourceColumn;
            DestinationOrdinal = destinationOrdinal;
        }

        public SqlCeBulkCopyColumnMapping(string sourceColumn, string destinationColumn)
        {
            SourceColumn = sourceColumn;
            DestinationColumn = destinationColumn;
        }

        // Properties
        public string DestinationColumn
        {
            get
            {
                if (_destinationColumnName != null)
                {
                    return _destinationColumnName;
                }
                return string.Empty;
            }
            set
            {
                _destinationColumnOrdinal = -1;
                _destinationColumnName = value;
            }
        }

        public int DestinationOrdinal
        {
            get
            {
                return _destinationColumnOrdinal;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Must be > 0");
                }
                _destinationColumnName = null;
                _destinationColumnOrdinal = value;
            }
        }

        public string SourceColumn
        {
            get
            {
                if (_sourceColumnName != null)
                {
                    return _sourceColumnName;
                }
                return string.Empty;
            }
            set
            {
                _sourceColumnOrdinal = -1;
                _sourceColumnName = value;
            }
        }

        public int SourceOrdinal
        {
            get
            {
                return _sourceColumnOrdinal;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Must be > 0");
                }
                _sourceColumnName = null;
                _sourceColumnOrdinal = value;
            }
        }
    }

}
