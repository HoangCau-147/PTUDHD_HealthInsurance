using Contracts.CustomerContracts;
using Entity.Models.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Customers
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }
        public bool CreateCusomter(Customer customer)
        {
            return Create(customer);
        }
        public async Task<Customer> GetCustomerAsnyc(int customerId, bool trachChanges)
        {
            return await FindByCondition(c => c.CustomerId == customerId, trachChanges).SingleOrDefaultAsync();
        }
        public async Task<Customer> GetCustomerByEmail(string Email, bool trackChange)
        {
            return await FindByCondition(e => e.Email == Email, trackChange).SingleOrDefaultAsync();
        }
        public async Task<List<Customer>> GetCustomers(bool trackChanges) 
            => await FindAll(trackChanges).ToListAsync();
    }
}
