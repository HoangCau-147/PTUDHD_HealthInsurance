using Entity.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.CustomerContracts
{
    public interface ICustomerRepository
    {
        bool CreateCusomter(Customer customer);
        Task<Customer> GetCustomerAsnyc(int customerId, bool trachChanges);
        Task<Customer> GetCustomerByEmail(string Email, bool trackChange);
        Task<List<Customer>> GetCustomers(bool trackChanges);
    }
}
