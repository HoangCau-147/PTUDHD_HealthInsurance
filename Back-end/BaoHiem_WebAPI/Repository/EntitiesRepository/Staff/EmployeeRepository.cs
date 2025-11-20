using Contracts.StaffContracts;
using Entity.Models.Staff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Staff
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly InsuranceDBContext _dBContext;
        public EmployeeRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
            _dBContext = insuranceDBContext;
        }

        public async Task<Employee> GetEmployee(int employeeId, bool trackChanges)
        {
            var result = await FindByCondition(e => e.EmployeeId == employeeId, trackChanges).SingleOrDefaultAsync();
            return result;
        }
        public async Task<Employee> GetEmployeeByEmail(string Email, bool trackChanges)
        {
            var result = await FindByCondition(e => e.Email == Email, trackChanges).SingleOrDefaultAsync();
            return result;
        }
        public async Task<List<Employee>> GetEmployees(bool trackchanges)
        {
            return await FindAll(trackchanges).ToListAsync();
        }
        public bool CreateEmployee(Employee employee)
        {
            return Create(employee);
            
        }
    }
}
