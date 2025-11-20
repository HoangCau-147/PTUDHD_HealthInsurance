using Entity.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions.Insurance
{
    public class InsuranceProductNotFoundException : NotFoundException
    {
        public InsuranceProductNotFoundException(int id) :
            base($"Insurance Product with id: {id} doesn't exist in the database")
        {
        }
    }
}
