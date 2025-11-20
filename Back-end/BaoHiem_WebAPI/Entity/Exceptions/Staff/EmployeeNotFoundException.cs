using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Entity.Exceptions.Staff
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int EmployeeId) : base($"Employee with id: {EmployeeId} doesn't exist in the database")
        {
        }
    }
}
