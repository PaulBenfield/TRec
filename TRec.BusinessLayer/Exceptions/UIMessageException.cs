using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer.Exceptions
{
    public class UIMessageException : ApplicationException
    {
        public UIMessageException( string message, Exception innerException )
            : base( message, innerException )
        {
        }
    }
}
