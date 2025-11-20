using Entity.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test.MockData
{
    public class CustomerDataMock
    {
        public static Customer GetCustomer()
        {
            return new Customer { 
                Id = Guid.Parse("EBB77F5D-DFC3-40C6-A59D-08DBF7C0C064"),
                CustomerId = 3
            };
        }
        public static Customer GetCustomerNull()
        {
            return null;
        }
    }
}
