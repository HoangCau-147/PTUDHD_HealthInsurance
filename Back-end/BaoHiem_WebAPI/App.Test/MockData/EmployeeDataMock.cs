using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.EntityDtos.Staff;

namespace App.Test.MockData
{
    public class EmployeeDataMock
    {
        public static EmployeeDto GetEmployeeDto()
        {
            return new EmployeeDto()
            {
                Address = "fda",
                Birthday = DateTime.Now,
                EmployeeId = 1,
                IdentifycationNumber = "2314531",
                Name = "2314",
                PhoneNumber = "0123456789"
            };
        }
    }
}
