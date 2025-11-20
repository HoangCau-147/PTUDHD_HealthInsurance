using App.Test.MockData;
using AutoMapper;
using Contracts;
using Entity.Exceptions;
using Entity.Models.Customers;
using Entity.Models.InsuranceContractModels;
using Moq;
using Org.BouncyCastle.Ocsp;
using Services.Contracts;
using Shared.EntityDtos.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test.System.Sevices
{
    public class ContractServiceTest
    {
        // convert entity to dto
        [Fact]
        public async Task ContractService_ConverctEntityToDto_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            var inputData = ContractMockData.GetContract();

            //mockRepository.Setup(repo =>
            //        repo.Contracts.GetAll(It.IsAny<bool>()))
            //    .ReturnsAsync(ContractMockData.GetContracts());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(),It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var result = await mockContractService.ConvertEntityToDto(inputData);
            //Assert
            Assert.NotNull(result);
        }
        //GetContract
        [Fact]
        public async Task ContractService_GetContracts_Failed()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            var inputData = ContractMockData.GetContract();

            mockRepository.Setup(repo =>
                    repo.Contracts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContractsEmpty());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var exception = await Record.ExceptionAsync(() => mockContractService.GetContracts());
            //Assert
            Assert.IsType<ReturnBadRequestException>(exception);
        }
        
        [Fact]
        public async Task ContractService_GetContract_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Contracts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());
            mockRepository.Setup(repo =>
                    repo.Contracts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts());

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var result = await mockContractService.GetContracts();
            //Assert
            Assert.NotNull(result);
        }
        //GetContract by status
        [Fact]
        public async Task ContractService_GetContractsByStatus_Failed()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.Contracts.GetContractsByStatus(It.IsAny<ContractStatus>(),It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContractsEmpty());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());
            var inputdata = ContractStatus.Cancelled;

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var exception = await Record.ExceptionAsync(() => mockContractService.GetContractByStatus(inputdata));
            //Assert
            Assert.IsType<ReturnBadRequestException>(exception);
        }

        [Fact]
        public async Task ContractService_GetContractsByStatus_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo => 
                    repo.Contracts.GetContractsByStatus(It.IsAny<ContractStatus>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());
            mockRepository.Setup(repo =>
                    repo.Contracts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts());

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var result = await mockContractService.GetContracts();
            //Assert
            Assert.NotNull(result);
        }
        //GetContract by id
        [Fact]
        public async Task ContractService_GetContractsByID_Failed()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContractEmpty());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var inputdata = GuidDataMock.GetNewGuid();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var exception = await Record.ExceptionAsync(() => mockContractService.GetContractById(inputdata));
            //Assert
            Assert.IsType<ReturnNotFoundException>(exception);
        }

        [Fact]
        public async Task ContractService_GetContractsById_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var inputdata = GuidDataMock.GetNewGuid();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var result = await mockContractService.GetContractById(inputdata);
            //Assert
            Assert.NotNull(result);
        }
        //GetContract by id
        [Fact]
        public async Task ContractService_GetContractByCustomerIdAndStatus_customerIdInvalid()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomerNull());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            int customerId = -99;
            ContractStatus Status = ContractStatus.Cancelled;

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var exception = await Record.ExceptionAsync(() => mockContractService.GetContractByCustomerIdAndStatus(customerId, Status));
            //Assert
            Assert.IsType<ReturnNotFoundException>(exception);
        }
        [Fact]
        public async Task ContractService_GetContractByCustomerIdAndStatus_NotFound()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo =>
                    repo.Contracts.GetContractsByCustomerIdAndStatus(It.IsAny<Guid>(), It.IsAny<string>() ,It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContractsEmpty());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            int customerId = -99;
            ContractStatus Status = ContractStatus.Cancelled;

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var exception = await Record.ExceptionAsync(() => mockContractService.GetContractByCustomerIdAndStatus(customerId, Status));
            //Assert
            Assert.IsType<ReturnNoContentException>(exception);
        }
        [Fact]
        public async Task ContractService_GetContractByCustomerIdAndStatus_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo =>
                    repo.Contracts.GetContractsByCustomerIdAndStatus(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            int customerId = 1;
            ContractStatus Status = ContractStatus.Cancelled;

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var result = await mockContractService.GetContractByCustomerIdAndStatus(customerId, Status);
            //Assert
            Assert.NotNull(result);
        }
        //create contract
        [Fact]
        public async Task ContractService_CreateContract_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            mockRepository.Setup(repo =>
                repo.Customers.GetCustomerByEmail(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo => 
                repo.InsurancePrograms.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            mockRepository.Setup(repo =>
               repo.InsuranceProducts.GetById(It.IsAny<int>(), It.IsAny<bool>()))
               .ReturnsAsync(ProductDataMock.GetProduct());
            mockRepository.Setup(repo =>
               repo.Contracts.CreateContract(It.IsAny<Contract>()))
               .Returns(true);
            mockRepository.Setup(repo =>
                repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Contract>(It.IsAny<RegisterContractDto>()))
                .Returns(new Contract
                {
                    EndDate = DateTime.Parse("2024-12-12"),
                    StartDate = DateTime.Parse("2023-12-12"),
                    TotalPrice = 1000000
                });
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var testData = ContractMockData.NewContractDto();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var result = await mockContractService.CreateContract(testData);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task ContractService_CreateContract_InputNull()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            mockRepository.Setup(repo =>
                repo.Customers.GetCustomerByEmail(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo =>
                repo.InsurancePrograms.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            mockRepository.Setup(repo =>
               repo.InsuranceProducts.GetById(It.IsAny<int>(), It.IsAny<bool>()))
               .ReturnsAsync(ProductDataMock.GetProduct());
            mockRepository.Setup(repo =>
               repo.Contracts.CreateContract(It.IsAny<Contract>()))
               .Returns(true);
            mockRepository.Setup(repo =>
                repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Contract>(It.IsAny<RegisterContractDto>()))
                .Returns(new Contract
                {
                    EndDate = DateTime.Parse("2024-12-12"),
                    StartDate = DateTime.Parse("2023-12-12"),
                    TotalPrice = 1000000
                });
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var testData = ContractMockData.NewContractDtoNull();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            //Assert
            await Assert.ThrowsAsync<ReturnNotFoundException>(() => mockContractService.CreateContract(testData));
        
        }
        [Fact]
        public async Task ContractService_CreateContract_ProductNull()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            mockRepository.Setup(repo =>
                repo.Customers.GetCustomerByEmail(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo =>
                repo.InsurancePrograms.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            mockRepository.Setup(repo =>
               repo.InsuranceProducts.GetById(It.IsAny<int>(), It.IsAny<bool>()))
               .ReturnsAsync(ProductDataMock.GetProductNull());
            mockRepository.Setup(repo =>
               repo.Contracts.CreateContract(It.IsAny<Contract>()))
               .Returns(true);
            mockRepository.Setup(repo =>
                repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Contract>(It.IsAny<RegisterContractDto>()))
                .Returns(new Contract
                {
                    EndDate = DateTime.Parse("2024-12-12"),
                    StartDate = DateTime.Parse("2023-12-12"),
                    TotalPrice = 1000000
                });
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var testData = ContractMockData.NewContractDto();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            //var result = await mockContractService.CreateContract(testData);
            var exception = await Record.ExceptionAsync(() => mockContractService.CreateContract(testData));
            //Assert
            Assert.IsType<ReturnNotFoundException>(exception);
            //await Assert.ThrowsAsync<ReturnNotFoundException>(() => mockContractService.CreateContract(testData));

        }
        [Fact]
        public async Task ContractService_CreateContract_ProgramNull()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            mockRepository.Setup(repo =>
                repo.Customers.GetCustomerByEmail(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo =>
                repo.InsurancePrograms.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProgramDataMock.GetProgramNull());
            mockRepository.Setup(repo =>
               repo.InsuranceProducts.GetById(It.IsAny<int>(), It.IsAny<bool>()))
               .ReturnsAsync(ProductDataMock.GetProduct());
            mockRepository.Setup(repo =>
               repo.Contracts.CreateContract(It.IsAny<Contract>()))
               .Returns(true);
            mockRepository.Setup(repo =>
                repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Contract>(It.IsAny<RegisterContractDto>()))
                .Returns(new Contract
                {
                    EndDate = DateTime.Parse("2024-12-12"),
                    StartDate = DateTime.Parse("2023-12-12"),
                    TotalPrice = 1000000
                });
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var testData = ContractMockData.NewContractDto();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            //act
            //var result = await mockContractService.CreateContract(testData);
            var exception = await Record.ExceptionAsync(() => mockContractService.CreateContract(testData));
            //Assert
            Assert.IsType<ReturnNotFoundException>(exception);
            //await Assert.ThrowsAsync<ReturnNotFoundException>(() => mockContractService.CreateContract(testData));

        }
        [Fact]
        public async Task ContractService_CreateContract_CustomerNull()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            mockRepository.Setup(repo =>
                repo.Customers.GetCustomerByEmail(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomerNull());
            mockRepository.Setup(repo =>
            repo.Customers.CreateCusomter(It.IsAny<Customer>()))
            .Returns(true);
            mockRepository.Setup(repo =>
                repo.InsurancePrograms.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            mockRepository.Setup(repo =>
               repo.InsuranceProducts.GetById(It.IsAny<int>(), It.IsAny<bool>()))
               .ReturnsAsync(ProductDataMock.GetProduct());
            mockRepository.Setup(repo =>
               repo.Contracts.CreateContract(It.IsAny<Contract>()))
               .Returns(true);
            mockRepository.Setup(repo =>
                repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());
                // mapper
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Customer>(It.IsAny<RegisterContractDto>()))
                .Returns(new Customer
                {
                    IdentifycationNumber = "874983749",
                    Address = "dịalfklas",
                    UserID = "djalfka"
                });
            mockMapper.Setup(map => map.Map<Contract>(It.IsAny<RegisterContractDto>()))
                .Returns(new Contract
                {
                    EndDate = DateTime.Parse("2024-12-12"),
                    StartDate = DateTime.Parse("2023-12-12"),
                    TotalPrice = 1000000
                });
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());


            var testData = ContractMockData.NewContractDto();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var exception = await Record.ExceptionAsync(() => mockContractService.CreateContract(testData));
            //Assert
            Assert.IsType<ReturnNotFoundException>(exception);
        }
        [Fact]
        public async Task ContractService_CreateContract_ProductConditionNull()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            mockRepository.Setup(repo =>
                repo.Customers.GetCustomerByEmail(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo =>
            repo.Customers.CreateCusomter(It.IsAny<Customer>()))
            .Returns(true);
            mockRepository.Setup(repo =>
                repo.InsurancePrograms.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            mockRepository.Setup(repo =>
               repo.InsuranceProducts.GetById(It.IsAny<int>(), It.IsAny<bool>()))
               .ReturnsAsync(ProductDataMock.GetProductConditionNull());
            mockRepository.Setup(repo =>
               repo.Contracts.CreateContract(It.IsAny<Contract>()))
               .Returns(true);
            mockRepository.Setup(repo =>
                repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());
            mockRepository.Setup(repo =>
                    repo.HealthConditions.GetByGuidIdAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(HealthConditionDataMock.GetCondition());
            // mapper
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(map => map.Map<Contract>(It.IsAny<RegisterContractDto>()))
                .Returns(new Contract
                {
                    EndDate = DateTime.Parse("2024-12-12"),
                    StartDate = DateTime.Parse("2023-12-12"),
                    TotalPrice = 1000000
                });
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());


            var testData = ContractMockData.NewContractDto();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            var result = await mockContractService.CreateContract(testData);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task ContractService_CreateContract_CreateFailed()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();
            mockRepository.Setup(repo =>
                repo.Customers.GetCustomerByEmail(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(CustomerDataMock.GetCustomer());
            mockRepository.Setup(repo =>
                repo.InsurancePrograms.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            mockRepository.Setup(repo =>
               repo.InsuranceProducts.GetById(It.IsAny<int>(), It.IsAny<bool>()))
               .ReturnsAsync(ProductDataMock.GetProduct());
            mockRepository.Setup(repo =>
               repo.Contracts.CreateContract(It.IsAny<Contract>()))
               .Returns(false);
            mockRepository.Setup(repo =>
                repo.Contracts.GetContractsById(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContract());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(map => map.Map<Contract>(It.IsAny<RegisterContractDto>()))
                .Returns(new Contract
                {
                    EndDate = DateTime.Parse("2024-12-12"),
                    StartDate = DateTime.Parse("2023-12-12"),
                    TotalPrice = 1000000
                });
            mockMapper.Setup(map => map.Map<ContractDto>(It.IsAny<Contract>()))
                .Returns(ContractMockData.GetContractDto());

            var testData = ContractMockData.NewContractDto();

            var mockContractService = new ContractService(mockRepository.Object, mockMapper.Object);
            //act
            //act
            //var result = await mockContractService.CreateContract(testData);
            var exception = await Record.ExceptionAsync(() => mockContractService.CreateContract(testData));
            //Assert
            Assert.IsType<ReturnBadRequestException>(exception);
            //await Assert.ThrowsAsync<ReturnNotFoundException>(() => mockContractService.CreateContract(testData));

        }

        // 
    }
}
