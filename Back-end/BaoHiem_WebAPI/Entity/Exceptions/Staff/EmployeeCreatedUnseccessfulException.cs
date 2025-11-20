using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions.Staff
{
    public class EmployeeCreatedUnseccessfulException : BadRequestException
    {
        public EmployeeCreatedUnseccessfulException() : base("User unsuccessfully created")
        {
        }
    }
}
