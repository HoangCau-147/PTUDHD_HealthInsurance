using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class ReturnNoContentException : NoContentException
    {
        public ReturnNoContentException(string message) : base(message)
        {
        }
    }
}
