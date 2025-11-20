using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public abstract class NoContentException : Exception
    {
        protected NoContentException(string message) : base(message) { }
    }
}
