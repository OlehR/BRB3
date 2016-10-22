using System;
using System.Collections.Generic;
using System.Text;

namespace ErikEJ.SqlCe
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ce")]
    public class SqlCeRowsCopiedEventArgs : EventArgs
    {
        private long _rowsCopied;
        private bool _abort;

        public SqlCeRowsCopiedEventArgs(long rowsCopied)
        {
            _rowsCopied = rowsCopied;
        }

        public long RowsCopied
        {
            get
            {
                return _rowsCopied;
            }
        }

        public bool Abort
        {
            get
            {
                return _abort;
            }
            set
            {
                _abort = value;
            }
        }

    }

}
