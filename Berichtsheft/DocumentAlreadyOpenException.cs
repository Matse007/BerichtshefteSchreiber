using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berichtsheft
{
    /// <summary>
    /// Custom Exception for when a word document is already open when trying to open one.
    /// </summary>
    [Serializable]
    class DocumentAlreadyOpenException : Exception
    {

        DocumentAlreadyOpenException()
        { }

        public DocumentAlreadyOpenException(string message)
            : base(message)
        { }
        public DocumentAlreadyOpenException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
