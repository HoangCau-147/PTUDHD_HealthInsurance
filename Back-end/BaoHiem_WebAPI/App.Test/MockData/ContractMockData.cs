using Entity.Models.InsuranceContractModels;
using Entity.Models.InsuranceModels;
using Shared.EntityDtos.Contract;
using Shared.EntityDtos.Customer;

namespace App.Test.MockData
{
    public class ContractMockData
    {
        public static List<ContractDto> GetContractDtos()
        {
            return new List<ContractDto> {
                new ContractDto
                {
                    StartDate = DateTime.Parse("2023-12-25"),
                    EndDate = DateTime.Parse("2024-12-25"),
                    ContractHealthConditions = null,
                    ContractId = Guid.NewGuid(),
                    Status = ContractStatus.Unpaid.ToString(),
                    TotalPrice = 100000,
                    ProductId = 1,
                    ProgramId = 1,
                    ProductName = "An tâm sống khỏe",
                    ProgramName = "Bronze"
                },
                new ContractDto
                {
                    StartDate = DateTime.Parse("2023-12-25"),
                    EndDate = DateTime.Parse("2024-12-25"),
                    ContractHealthConditions = null,
                    ContractId = Guid.NewGuid(),
                    Status = ContractStatus.Unpaid.ToString(),
                    TotalPrice = 100000,
                    ProductId = 1,
                    ProgramId = 1,
                    ProductName = "An tâm sống khỏe",
                    ProgramName = "Gold"
                }
            };
        }
        public static List<ContractDto> GetEmptyContracts()
        {
            return new List<ContractDto>();
        }

        public static Contract GetContractEmpty()
        {
            return null;
        }
        public static Contract GetContract()
        {
            return new Contract
            {
                ContractId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ConfirmDate = DateTime.Now,
                EndDate = DateTime.Now,
                HealthDeclaration = " đà",
                StartDate = DateTime.Now,
                InsuranceProduct = new InsuranceProduct
                {
                    Id = Guid.NewGuid(),
                    ProductId = 1,
                    PolicyName = "hd",

                },
                InsuranceProgram = new InsuranceProgram
                {
                    ProgramId = 1,
                    Name = "Bronze"
                },
                ContractHealthConditions = new List<ContractHealthCondition>
                {
                    new ContractHealthCondition
                    {
                        ContractId = Guid.NewGuid(),
                        HealthConditionId = Guid.NewGuid(),
                        Status = true
                    },
                    new ContractHealthCondition
                    {
                        ContractId = Guid.NewGuid(),
                        HealthConditionId = Guid.NewGuid(),
                        Status = true
                    }
                }
            };
        }
        public static ContractDto GetContractDto()
        {
            return new ContractDto
            {
                ContractId = Guid.Parse("F53272E2-AC97-4D59-8E58-147A93B6345E"),
                TotalPrice = 1000000,
                Customer = new CustomerDto
                {
                    Name = "123123"
                },
                ProductId = 1,
                ProductName = "da",
                ProgramId = 1,
                ProgramName = "Bronze"
            };
        }
        public static RegisterContractDto NewContractDto()
        {
            return new RegisterContractDto
            {
                Customer = new CustomerDto
                {
                    Address = "Ktx khu b",
                    Birthday = DateTime.Parse("2002-12-12"),
                    CustomerId = 3,
                    Email = "sonbatest@gmail.com",
                    Name = "To Tran Son Ba",
                    PhoneNumber = "0123456789",
                    IdentifycationNumber = "0123456789"
                },
                ProductId = 7,
                EndDate = DateTime.Parse("2024-12-12"),
                StartDate = DateTime.Parse("2023-12-12"),
                HealthConditions = new List<RegisterContractHealthConditionDto>
                {
                   new RegisterContractHealthConditionDto
                   {
                       Id = 15,
                       Status = true
                   },
                   new RegisterContractHealthConditionDto
                   {
                       Id = 16,
                       Status = true
                   },
                   new RegisterContractHealthConditionDto
                   {
                       Id = 17,
                       Status = true
                   }
                },
                PaymentMethod = 0,
                ProgramId = 1,
                TotalPrice = 1000000
            };
        }
        public static RegisterContractDto NewContractDtoNull()
        {
            return null;
        }

        public static List<Contract> GetContracts()
        {
            return new List<Contract>
            {
                GetContract(),
                GetContract()
            };
        }
        public static List<Contract> GetContractsEmpty()
        {
            return new List<Contract>();
        }
    }
}
