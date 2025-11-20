using Entity.Models.InsuranceContractModels;
using Shared.EntityDtos.Contract;
using Shared.EntityDtos.Insurances.InsuranceProduct;
using Shared.EntityDtos.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Contracts
{
    public interface IContractService
    {
        Task<ContractDto> CreateContract(RegisterContractDto registerContractDto);
        Task<List<ContractDto>> GetContracts();
        Task<List<ContractDto>> GetContractByStatus(ContractStatus status);
        Task<ContractDto> GetContractById(Guid Id);
        Task UpdateStatus(Guid ContractId, ContractStatus status, EmployeeDto employeeDto);
        Task<List<ContractDto>> GetContractByCustomerIdAndStatus(int customerId, ContractStatus status);
    }
}
