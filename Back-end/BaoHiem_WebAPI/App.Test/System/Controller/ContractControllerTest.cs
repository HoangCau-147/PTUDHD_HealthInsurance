using App.Test.MockData;
using Entity.Models.InsuranceContractModels;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Org.BouncyCastle.Security;
using Service.Contracts;
using Services.Payment.Momo;
using Shared.EntityDtos.Contract;
using Shared.EntityDtos.Payment.Momo.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebAPI.Controllers.Contracts;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http.Connections.Features;

namespace App.Test.System.Controller
{
    public class ContractControllerTest
    {
        [Fact]
        public async Task ContractController_AddContract_ReturnCreated()
        {
            //arrange
            var serviceManager = new Mock<IServiceManager>();
            var newContract = ContractMockData.NewContractDto();
            var controller = new ContractController(serviceManager.Object);

            serviceManager.Setup(ser =>
                ser.Contracts.CreateContract(It.IsAny<RegisterContractDto>()))
                .ReturnsAsync(ContractMockData.GetContractDto());

            serviceManager.Setup(ser =>
                ser.Contracts.CreateContract(It.IsAny<RegisterContractDto>()))
                .ReturnsAsync(ContractMockData.GetContractDto());

            serviceManager.Setup(ser =>
                ser.Momo.PaymentRequest(It.IsAny<MomoOneTimePaymentRequestDto>()))
                .Returns("adfadfa");
            //act
            var result = await controller.AddContract(newContract);

            //assert
            serviceManager.Verify(_ => _.Contracts.CreateContract(newContract), Times.Exactly(1));
        }
        [Fact]
        public async Task ContractController_GetContracts_ReturnOK()
        {
            //arrange
            var serviceManager = new Mock<IServiceManager>();
            serviceManager.Setup(_ => _.Contracts.GetContracts())
                .ReturnsAsync(ContractMockData.GetContractDtos());
            var sut = new ContractController(serviceManager.Object);
            //act
            var result = (OkObjectResult)await sut.GetContracts();
            //assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ContractController_GetContracts_ReturnNoConTent()
        {
            //arrange
            var serviceManager = new Mock<IServiceManager>();
            serviceManager.Setup(_ => _.Contracts.GetContracts()).ReturnsAsync(ContractMockData.GetEmptyContracts());
            var sut = new ContractController(serviceManager.Object);
            //act
            var result = (NoContentResult)await sut.GetContracts();
            //assert
            result.StatusCode.Should().Be(204);
            serviceManager.Verify(_ => _.Contracts.GetContracts(), Times.Exactly(1));
        }
        [Fact]
        public async Task ContractController_GetContractsWithContract_ReturnOK()
        {
            //arrange
            var serviceManager = new Mock<IServiceManager>();
            serviceManager.Setup(_ => _.Contracts.GetContractByStatus(It.IsAny<ContractStatus>()))
                .ReturnsAsync(ContractMockData.GetContractDtos());

            var sut = new ContractController(serviceManager.Object);
            var inputdata = ContractStatus.Cancelled;
            //act
            var result = (OkObjectResult)await sut.GetContractsWithContract(inputdata);
            //assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ContractController_GetContract_ReturnOK()
        {
            //arrange
            var serviceManager = new Mock<IServiceManager>();
            serviceManager.Setup(_ => _.Contracts.GetContractById(It.IsAny<Guid>()))
                .ReturnsAsync(ContractMockData.GetContractDto());

            var sut = new ContractController(serviceManager.Object);
            var inputdata = ContractStatus.Cancelled;
            //act
            var result = (OkObjectResult)await sut.GetContractsWithContract(inputdata);
            //assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ContractController_GetContractByCustomerIdAndStatus_ReturnOK()
        {
            //arrange
            var serviceManager = new Mock<IServiceManager>();
            serviceManager.Setup(_ => _.Contracts.GetContractById(It.IsAny<Guid>()))
                .ReturnsAsync(ContractMockData.GetContractDto());

            var sut = new ContractController(serviceManager.Object);
            var customerId = 1;
            var status = ContractStatus.Cancelled;
            //act
            var result = (OkObjectResult)await sut.GetContractByCustomerIdAndStatus(customerId, status);
            //assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task ContractController_UpdateStatus_Unathorized()
        {
            //arrange

            #region Set Authorize

            var httpContext = new Mock<IHttpContextFeature>();
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, "sonba4102@gmail.com"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.Role, "Employee"),
            }));
            httpContext.Setup(context => context.HttpContext.User)
                .Returns(user);
            #endregion


            var serviceManager = new Mock<IServiceManager>();
            serviceManager.Setup(_ => _.Contracts.GetContractById(It.IsAny<Guid>()))
                .ReturnsAsync(ContractMockData.GetContractDto());
            serviceManager.Setup(service => service.Employees.GetEmployeeByEmail(It.IsAny<string>()))
                .ReturnsAsync(EmployeeDataMock.GetEmployeeDto);

            var sut = new ContractController(serviceManager.Object);
            var ContractId = Guid.NewGuid();
            var status = ContractStatus.Cancelled;
            //act
            var result = (OkObjectResult)await sut.UpdateStatus(ContractId, status);
            //assert
            Assert.IsType< UnauthorizedResult>(result);
        }
    }
}
