using AutoMapper;
using Contracts;
using Entity.Exceptions;
using Entity.Models.Customers;
using Entity.Models.InsuranceContractModels;
using Service.Contracts.Contracts;
using Shared.EntityDtos.Contract;
using Shared.EntityDtos.Staff;


namespace Services.Contracts
{
    public class ContractService : IContractService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public ContractService(IRepositoryManager repositoryManager, IMapper mapper)
        { 
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
        }
        public async Task<List<ContractDto>> GetContracts()
        {
            var contracts = await _repositoryManager.Contracts.GetAll(false);
            if (contracts == null || contracts.Count() == 0)
                throw new ReturnBadRequestException("Db khong co data");
            var rContracts = new List<ContractDto>();
            foreach(var contract in contracts)
            {
                var contractDto = await ConvertEntityToDto(contract);
                rContracts.Add(contractDto);
            }
            return rContracts;
        }
        public async Task<ContractDto> CreateContract(RegisterContractDto registerContractDto)
        {
            if (registerContractDto == null)
                throw new ReturnNotFoundException($"Register Contract is null.");
            // ktra sản phẩm bảo hiểm tồn tại không
            var product = await _repositoryManager.InsuranceProducts.GetById(registerContractDto.ProductId, false);
            if(product == null)
                throw new ReturnNotFoundException($"Product with Id: {registerContractDto.ProductId} don't exits");

            // kiem tra chuong trinh
            var program = await _repositoryManager.InsurancePrograms.GetById(registerContractDto.ProgramId);
            if (program == null)
                throw new ReturnNotFoundException($"Proram with Id: {registerContractDto.ProgramId} don't exits");

            var customer = await _repositoryManager.Customers.GetCustomerByEmail(registerContractDto.Customer.Email, false);
            // khách hàng không tồn tại thì thêm khách hàng
            if (customer == null)
            {
                throw new ReturnNotFoundException("khong tim thay khach hang");
            }    

            //tạo hợp đồng
            var contract = _mapper.Map<Contract>(registerContractDto);
            contract.Customer = null;
            contract.Employee = null;
            contract.EmployeeID = null;
            contract.ContractId = Guid.NewGuid();
            contract.Id = Guid.NewGuid();
            contract.Status = ContractStatus.Unpaid.ToString();
            contract.InsuranceProductId = product.Id;
            contract.InsuranceProgramId = program.Id;
            contract.CustomerID = customer.Id;

            contract.ContractHealthConditions = new List<ContractHealthCondition>();

            if(registerContractDto.HealthConditions != null && registerContractDto.HealthConditions.Count() > 0)
            {
                foreach (var conditionDto in registerContractDto.HealthConditions)
                {
                    if (product.HealthConditionSource == null)
                        break;
                    var condtion = product.HealthConditionSource.Where(p => p.HealthConditionId == conditionDto.Id).SingleOrDefault();
                    if (condtion == null)
                        continue;
                    contract.ContractHealthConditions.Add(new ContractHealthCondition
                    {
                        ContractId = contract.Id,
                        HealthConditionId = condtion.Id,
                        Status = conditionDto.Status,
                    });
                }
            }

            if (!_repositoryManager.Contracts.CreateContract(contract))
                throw new ReturnBadRequestException("Contract can not be created");
            await _repositoryManager.SaveAsync();
            var contractConvert = await _repositoryManager.Contracts.GetContractsById(contract.ContractId, false);
            var returnContract = await ConvertEntityToDto(contractConvert);
            return returnContract;
        }
        public async Task<List<ContractDto>> GetContractByStatus(ContractStatus status)
        {
            var contracts = await _repositoryManager.Contracts.GetContractsByStatus(status, false);
            if (contracts == null || contracts.Count() == 0)
                throw new ReturnBadRequestException("Db khong co data");
            var contractsDto = new List<ContractDto>();
            foreach(var contract in contracts)
            {
                var contractDto = await ConvertEntityToDto(contract);
                contractsDto.Add(contractDto);
            }
            return contractsDto;
        }
        public async Task<ContractDto> GetContractById(Guid Id)
        {
            var contract = await _repositoryManager.Contracts.GetContractsById(Id, false);
            if (contract == null)
            {
                throw new ReturnNotFoundException($"Contract With Id: {Id} not exist");
            }
            var contractDto = await ConvertEntityToDto(contract);
            return contractDto;
        }

        public async Task<ContractDto> ConvertEntityToDto(Contract contract)
        {
            var contractDto = _mapper.Map<ContractDto>(contract);
            contractDto.CreateDate = contract.CreatedDate;
            contractDto.ProgramName = contract.InsuranceProgram.Name;
            contractDto.ProductName = contract.InsuranceProduct.PolicyName;
            contractDto.ProductId = contract.InsuranceProduct.ProductId;
            contractDto.ProgramId = contract.InsuranceProgram.ProgramId;
            contractDto.ConfirmDate = contract.ConfirmDate;
            contractDto.ContractHealthConditions = new List<ContractHealthConditionDto>();
            foreach (var Item in contract.ContractHealthConditions)
            {
                var Condition = await _repositoryManager.HealthConditions.GetByGuidIdAsync(Item.HealthConditionId, false);
                contractDto.ContractHealthConditions.Add(new ContractHealthConditionDto
                {
                    ConditionId = Condition.HealthConditionId,
                    ConditionName = Condition.Name,
                    Status = Item.Status
                });
            }
            return contractDto;
        }

        public async Task UpdateStatus(Guid ContractId, ContractStatus status, EmployeeDto employeeDto)
        {
            var employee = await _repositoryManager.Employees.GetEmployee(employeeDto.EmployeeId, false);
            var contract = await _repositoryManager.Contracts.GetContractsById(ContractId, true);
            if (contract == null)
            {
                throw new ReturnNotFoundException($"Contract with id: {ContractId} dose not exist!");
            }
            contract.EmployeeID = employee.Id;
            if(status == ContractStatus.Using)
            {
                _repositoryManager.ContractsInvoices.AddInvoice(new ContractInvoice
                {
                    ContractID = contract.Id,
                    CreatedDate = DateTime.UtcNow,
                    LastPrice = contract.TotalPrice,
                    Id = Guid.NewGuid()
                });
                contract.ConfirmDate = DateTime.Now;
            }
            contract.Status = status.ToString();
            await _repositoryManager.SaveAsync();
        }
        public async Task<List<ContractDto>> GetContractByCustomerIdAndStatus(int customerId, ContractStatus status)
        {
            var customer = await _repositoryManager.Customers.GetCustomerAsnyc(customerId, false);
            if (customer == null)
            {
                throw new ReturnNotFoundException($"Customer with id: {customerId} dose not exist");
            }
            var contracts = await _repositoryManager.Contracts.GetContractsByCustomerIdAndStatus(customer.Id, status.ToString(), false);
            if(contracts == null || contracts.Count() == 0)
            {
                throw new ReturnNoContentException("");
            }
            var rContracts = new List<ContractDto>();
            foreach (var contract in contracts)
            {
                rContracts.Add(await ConvertEntityToDto(contract));
            }
            return rContracts;
        }
    }
}
