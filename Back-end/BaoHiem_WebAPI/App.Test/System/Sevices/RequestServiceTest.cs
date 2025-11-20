using Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Test.MockData;
using Services.Claims;
using Entity.Exceptions;
using Entity.Models.Claim;

namespace App.Test.System.Sevices
{
    public class RequestServiceTest
    {
        // convert entity to dto
        [Fact]
        public async Task RequestService_ConvertEntityToDto_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsByPrimaryId(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);
            var input = RequestDataMock.GetRequest(RequestStatus.Processing.ToString());

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act
            var result = await requestMock.ConvertEntityToDto(input);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task RequestService_ConvertEntityToDto_BadRequest()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsByPrimaryId(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContractEmpty);
            var input = RequestDataMock.GetRequest(RequestStatus.Processing.ToString());

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert
            Assert.ThrowsAsync<ReturnBadRequestException>(async () => await requestMock.ConvertEntityToDto(input));
        }

        // Create Request
        [Fact]
        public async Task RequestService_CreateRequest_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsById(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            mockRepository.Setup(repo
                    => repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), false))
                .ReturnsAsync(CustomerDataMock.GetCustomer);

            mockRepository.Setup(repo
                    => repo.ClaimRequests.AddRequest(It.IsAny<ClaimRequest>()))
                .Returns(true);

            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = RequestDataMock.GetCreateClaimRequestDto();

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert
            await requestMock.CreateRequest(input);
            Assert.True(productAdded);
        }
        [Fact]
        public async Task RequestService_CreateRequest_AddFailed()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsById(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            mockRepository.Setup(repo
                    => repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), false))
                .ReturnsAsync(CustomerDataMock.GetCustomer);

            mockRepository.Setup(repo
                    => repo.ClaimRequests.AddRequest(It.IsAny<ClaimRequest>()))
                .Returns(false);

            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = RequestDataMock.GetCreateClaimRequestDto();

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert

            Assert.ThrowsAsync<ReturnBadRequestException>(async () => await requestMock.CreateRequest(input));
        }
        [Fact]
        public async Task RequestService_CreateRequest_CustomerNotFound()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsById(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            mockRepository.Setup(repo
                    => repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), false))
                .ReturnsAsync(CustomerDataMock.GetCustomerNull);

            mockRepository.Setup(repo
                    => repo.ClaimRequests.AddRequest(It.IsAny<ClaimRequest>()))
                .Returns(true);

            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = RequestDataMock.GetCreateClaimRequestDto();

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert

            Assert.ThrowsAsync<ReturnNotFoundException>(async () => await requestMock.CreateRequest(input));
        }
        [Fact]
        public async Task RequestService_CreateRequest_ContractNotFound()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsById(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            mockRepository.Setup(repo
                    => repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), false))
                .ReturnsAsync(CustomerDataMock.GetCustomer);

            mockRepository.Setup(repo
                    => repo.ClaimRequests.AddRequest(It.IsAny<ClaimRequest>()))
                .Returns(true);

            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = RequestDataMock.GetCreateClaimRequestDto();

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert

            Assert.ThrowsAsync<ReturnNotFoundException>(async () => await requestMock.CreateRequest(input));
        }

        // GetClaimRequestOfCustomer
        [Fact]
        public async Task RequestService_GetClaimRequestOfCustomer_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), false))
                .ReturnsAsync(CustomerDataMock.GetCustomer);

            mockRepository.Setup(repo
                    => repo.ClaimRequests.GetCustomerRequest(It.IsAny<Guid>(), false))
                .ReturnsAsync(RequestDataMock.GetRequests);

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsByPrimaryId(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            var cusotmerId = 1;
            var status = RequestStatus.Waiting;

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert

            var result = await requestMock.GetClaimRequestOfCustomer(cusotmerId, status);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task RequestService_GetClaimRequestOfCustomer_CustomerNotFound()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), false))
                .ReturnsAsync(CustomerDataMock.GetCustomerNull);

            mockRepository.Setup(repo
                    => repo.ClaimRequests.GetCustomerRequest(It.IsAny<Guid>(), false))
                .ReturnsAsync(RequestDataMock.GetRequests);

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsByPrimaryId(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            var cusotmerId = 1;
            var status = RequestStatus.Waiting;

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert
            Assert.ThrowsAsync<ReturnNotFoundException>(async () => await requestMock.GetClaimRequestOfCustomer(cusotmerId, status));
        }
        [Fact]
        public async Task RequestService_GetClaimRequestOfCustomer_NoContent()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.Customers.GetCustomerAsnyc(It.IsAny<int>(), false))
                .ReturnsAsync(CustomerDataMock.GetCustomer);

            mockRepository.Setup(repo
                    => repo.ClaimRequests.GetCustomerRequest(It.IsAny<Guid>(), false))
                .ReturnsAsync(RequestDataMock.GetRequestsEmpty);

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsByPrimaryId(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            var cusotmerId = 1;
            var status = RequestStatus.Waiting;

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert
            Assert.ThrowsAsync<ReturnNoContentException>(async () => await requestMock.GetClaimRequestOfCustomer(cusotmerId, status));
        }

        // GetClaimRequestByStatus
        [Fact]
        public async Task RequestService_GetClaimRequestByStatus_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.ClaimRequests.GetRequestByStatus(It.IsAny<string>(), false))
                .ReturnsAsync(RequestDataMock.GetRequests);

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsByPrimaryId(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            var input = RequestStatus.Accepted;

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert

            var result = await requestMock.GetClaimRequestByStatus(input);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task RequestService_GetClaimRequestByStatus_NoContent()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.ClaimRequests.GetRequestByStatus(It.IsAny<string>(), false))
                .ReturnsAsync(RequestDataMock.GetRequestsEmpty);

            mockRepository.Setup(repo
                    => repo.Contracts.GetContractsByPrimaryId(It.IsAny<Guid>(), false))
                .ReturnsAsync(ContractMockData.GetContract);

            var input = RequestStatus.Accepted;

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert

            Assert.ThrowsAsync<ReturnNoContentException>(async() => await requestMock.GetClaimRequestByStatus(input));
        }

        //DenyRequest
        [Fact]
        public async Task RequestService_DenyRequest_Success()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.ClaimRequests.GetRequestById(It.IsAny<Guid>(), true))
                .ReturnsAsync(RequestDataMock.GetRequest("ENABLED"));

            var isUpdate = false;
            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    isUpdate = true;
                });
            var input = Guid.NewGuid();

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert
            await requestMock.DenyRequest(input);

            Assert.True(isUpdate);
        }
        [Fact]
        public async Task RequestService_DenyRequest_NotFound()
        {
            //arrange
            var mockRepository = new Mock<IRepositoryManager>();

            mockRepository.Setup(repo
                    => repo.ClaimRequests.GetRequestById(It.IsAny<Guid>(), true))
                .ReturnsAsync(RequestDataMock.GetRequestEmpty());

            var isUpdate = false;

            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    isUpdate = true;
                });
            var input = Guid.NewGuid();

            var requestMock = new ClaimRequestService(mockRepository.Object);
            // act assert
            

            Assert.ThrowsAsync<ReturnNotFoundException>(async () => await requestMock.DenyRequest(input));
        }
    }
}
