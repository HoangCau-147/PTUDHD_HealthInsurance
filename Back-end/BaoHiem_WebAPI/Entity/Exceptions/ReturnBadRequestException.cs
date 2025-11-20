using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
    public class ReturnBadRequestException : BadRequestException
    {
        public ReturnBadRequestException(string message) : base(message)
        {
        }
    }
}
