using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berichtsheft
{
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
