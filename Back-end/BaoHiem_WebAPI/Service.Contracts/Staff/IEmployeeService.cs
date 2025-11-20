using Shared.EntityDtos.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Staff
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees(bool trackChanges);
        Task<EmployeeDto> GetEmployee(int EmployeeId);
        Task<EmployeeDto?> CreateEmployeeAsync(EmployeeCreateDto employeedto);
        Task<EmployeeDto> GetEmployeeByEmail(string Email);
    }
}
