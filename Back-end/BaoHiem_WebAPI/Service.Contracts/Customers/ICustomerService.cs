using Shared.EntityDtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Customers
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto CustomerDto);
        Task<CustomerDto> GetCustomerByEmail(string email);
        Task<List<CustomerDto>> GetCustomers();
        Task UpdateCustomer(int customerId, UpdateCustomerDto CustomerDto);
    }
}
