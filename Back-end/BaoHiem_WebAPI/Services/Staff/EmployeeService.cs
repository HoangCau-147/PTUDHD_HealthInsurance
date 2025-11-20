using AutoMapper;
using Contracts;
using Entity.Exceptions;
using Entity.Exceptions.Staff;
using Entity.Models;
using Entity.Models.Staff;
using Microsoft.AspNetCore.Identity;
using Service.Contracts.Staff;
using Shared.EntityDtos.Customer;
using Shared.EntityDtos.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Staff
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public EmployeeService(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager) 
        { 
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
            this._userManager = userManager;
        }
        public async Task<List<EmployeeDto>> GetEmployees(bool trackChanges)
        {
            var employees = await _repositoryManager.Employees.GetEmployees(trackChanges);
            var returnEmployees = _mapper.Map<List<EmployeeDto>>(employees);
            return returnEmployees;
        }

        public async Task<EmployeeDto> GetEmployee(int EmployeeId)
        {
            var employee = await _repositoryManager.Employees.GetEmployee(EmployeeId, false);
            if(employee == null)
            {
                throw new EmployeeNotFoundException(EmployeeId);
            }
            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }
        public async Task<EmployeeDto> GetEmployeeByEmail(string Email)
        {
            var employee = await _repositoryManager.Employees.GetEmployeeByEmail(Email, false);
            if (employee == null)
            {
                throw new ReturnNotFoundException("Khong tim thấy nhân viên");
            }
            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }
        public async Task<EmployeeDto?> CreateEmployeeAsync(EmployeeCreateDto employeedto)
        {
            var user = await _userManager.FindByEmailAsync(employeedto.Email);
            var employee = _mapper.Map<Employee>(employeedto);
            var result = _repositoryManager.Employees.CreateEmployee(employee);
            employee.UserID = user.Id;
            await _repositoryManager.SaveAsync();
            if (result)
            {
                var employeeReturn = _mapper.Map<EmployeeDto>(employee);
                return employeeReturn;
            }
            else
                throw new EmployeeCreatedUnseccessfulException();
        }
    }
}
