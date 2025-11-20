using AutoMapper;
using Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Insurances;
using Entity.Exceptions;
using App.Test.MockData;
using Entity.Models.InsuranceContractModels;
using Entity.Models.InsuranceModels;
using Shared.EntityDtos.Insurances.InsuranceProduct;
using Microsoft.AspNetCore.Components.Forms;
using Shared.EntityDtos.Insurances.HealthCondition;
using Shared.EntityDtos.Insurances.InsuranceBenefit;
using Entity.Exceptions.Insurance;

namespace App.Test.System.Sevices
{
    public class ProductServiceTest
    {
        // TotalQuantitySoldOfProduct
        [Fact]
        public async Task ProductService_TotalQuantitySoldOfProduct_ListNull()
        {
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Contracts.GetByProductId(It.IsAny<Guid>(),It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContractsEmpty);

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);

            var inputData = Guid.NewGuid();
            //act
            var result = await mockProduct.TotalQuantitySoldOfProduct(inputData);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task ProductService_TotalQuantitySoldOfProduct_ListHasValue()
        {
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.Contracts.GetByProductId(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts);

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);

            var inputData = Guid.NewGuid();
            //act
            var result = await mockProduct.TotalQuantitySoldOfProduct(inputData);
            //Assert
            Assert.NotNull(result);
        }
        // convert entity => dto
        [Fact]
        public async Task ProductSerVice_ConvertProductEntityToDto_Success()
        {
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            #region  ConvertEntityToDto data mock

            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ProductDataMock.GetProductsEmpty());

            mockMapper.Setup(map => map.Map<InsuranceProductDto>(It.IsAny<InsuranceProduct>()))
                .Returns(ProductDataMock.GetProductDto());

            mockMapper.Setup(map => map.Map<List<HealthConditionProductDto>>(It.IsAny<List<HealthConditionProductDto>>()))
                .Returns(HealthConditionDataMock.GetConditionProductDtos());

            mockRepository.Setup(repo =>
                    repo.Contracts.GetByProductId(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts);

            mockRepository.Setup(repo =>
                    repo.InsuranceBenefitType.GetByIdAsync(It.IsAny<int>(),It.IsAny<bool>()))
                .ReturnsAsync(BenefitTypeDataMock.GetBenefitType());

            mockMapper.Setup(map => map.Map<InsuranceBenefitProductDto>(It.IsAny<InsuranceBenefit>()))
                .Returns(BenefitDataMock.GetBenefitProductDto());

            mockRepository.Setup(repo =>
                    repo.InsurancePrograms.GetByGuidId(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            #endregion

            var input = ProductDataMock.GetProduct();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act
            var result = await mockProduct.ConvertProductEntityToDto(input);
            //Assert
            Assert.NotNull(result);
        }

        // GetAll
        [Fact]
        public async Task ProductService_GetAll_NoCotent()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetAll( It.IsAny<bool>()))
                .ReturnsAsync(ProductDataMock.GetProductsEmpty());

            var input = false;

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act
            var exception = await Record.ExceptionAsync(() => mockProduct.GetAll(input));
            //Assert
            Assert.IsType<ReturnNoContentException>(exception);
        }
        [Fact]
        public async Task ProductService_GetAll_Success()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ProductDataMock.GetProducts());

            #region  ConvertEntityToDto data mock

            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ProductDataMock.GetProductsEmpty());

            mockMapper.Setup(map => map.Map<InsuranceProductDto>(It.IsAny<InsuranceProduct>()))
                .Returns(ProductDataMock.GetProductDto());

            mockMapper.Setup(map => map.Map<List<HealthConditionProductDto>>(It.IsAny<List<HealthConditionProductDto>>()))
                .Returns(HealthConditionDataMock.GetConditionProductDtos());

            mockRepository.Setup(repo =>
                    repo.Contracts.GetByProductId(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts);

            mockRepository.Setup(repo =>
                    repo.InsuranceBenefitType.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(BenefitTypeDataMock.GetBenefitType());

            mockMapper.Setup(map => map.Map<InsuranceBenefitProductDto>(It.IsAny<InsuranceBenefit>()))
                .Returns(BenefitDataMock.GetBenefitProductDto());

            mockRepository.Setup(repo =>
                    repo.InsurancePrograms.GetByGuidId(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            #endregion

            var input = false;

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act
            var result = await mockProduct.GetAll(input);
            //Assert
            Assert.NotNull(result);
        }

        // GetbyId
        [Fact]
        public async Task ProductService_GetById_NotFound()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetById(It.IsAny<int>(),It.IsAny<bool>()))
                .ReturnsAsync(ProductDataMock.GetProductNull());

            Random random = new Random();
            var input = random.Next();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act
            var exception = await Record.ExceptionAsync(() => mockProduct.GetById(input, false));
            //Assert
            Assert.IsType<ReturnNotFoundException>(exception);
        }
        [Fact]
        public async Task ProductService_GetById_Success()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetById(It.IsAny<int>(),It.IsAny<bool>()))
                .ReturnsAsync(ProductDataMock.GetProduct());

            #region  ConvertEntityToDto data mock

            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetAll(It.IsAny<bool>()))
                .ReturnsAsync(ProductDataMock.GetProductsEmpty());

            mockMapper.Setup(map => map.Map<InsuranceProductDto>(It.IsAny<InsuranceProduct>()))
                .Returns(ProductDataMock.GetProductDto());

            mockMapper.Setup(map => map.Map<List<HealthConditionProductDto>>(It.IsAny<List<HealthConditionProductDto>>()))
                .Returns(HealthConditionDataMock.GetConditionProductDtos());

            mockRepository.Setup(repo =>
                    repo.Contracts.GetByProductId(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ContractMockData.GetContracts);

            mockRepository.Setup(repo =>
                    repo.InsuranceBenefitType.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(BenefitTypeDataMock.GetBenefitType());

            mockMapper.Setup(map => map.Map<InsuranceBenefitProductDto>(It.IsAny<InsuranceBenefit>()))
                .Returns(BenefitDataMock.GetBenefitProductDto());

            mockRepository.Setup(repo =>
                    repo.InsurancePrograms.GetByGuidId(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(ProgramDataMock.GetProgramId1());
            #endregion

            Random random = new Random();
            var input = random.Next();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act
            var result = await mockProduct.GetById(input, false);
            //Assert
            Assert.NotNull(result);
        }
        // add product
        [Fact]
        public async Task ProductService_AddProduct_Success()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.Add(It.IsAny<InsuranceProduct>()))
                .Returns(true);


            mockRepository.Setup(repo =>
                    repo.InsurancePrograms.GetAllAsync(It.IsAny<bool>()))
                .ReturnsAsync(ProgramDataMock.GetPrograms());

            mockRepository.Setup(repo =>
                    repo.InsuranceBenefitType.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(BenefitTypeDataMock.GetBenefitType());

            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.InsuranceProducts.Add(It.IsAny<InsuranceProduct>()))
                .Callback<InsuranceProduct>(product =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = ProductDataMock.GetAddInsuranceProductDto();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act
            await mockProduct.AddInsuranceProduct(input);
            //Assert
            Assert.True(productAdded);
        }
        [Fact]
        public async Task ProductService_AddProduct_ProgramsEmpty()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.Add(It.IsAny<InsuranceProduct>()))
                .Returns(true);


            mockRepository.Setup(repo =>
                    repo.InsurancePrograms.GetAllAsync(It.IsAny<bool>()))
                .ReturnsAsync(ProgramDataMock.GetProgramsEmpty());

            mockRepository.Setup(repo =>
                    repo.InsuranceBenefitType.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(BenefitTypeDataMock.GetBenefitType());

            var input = ProductDataMock.GetAddInsuranceProductDto();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act
            
            //Assert
            Assert.ThrowsAsync<ReturnBadRequestException>(async () => await mockProduct.AddInsuranceProduct(input));
        }
        [Fact]
        public async Task ProductService_AddProduct_BenefitTypeEmpty()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.Add(It.IsAny<InsuranceProduct>()))
                .Returns(true);


            mockRepository.Setup(repo =>
                    repo.InsurancePrograms.GetAllAsync(It.IsAny<bool>()))
                .ReturnsAsync(ProgramDataMock.GetPrograms());

            mockRepository.Setup(repo =>
                    repo.InsuranceBenefitType.GetByIdAsync(It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(BenefitTypeDataMock.GetBenefitTypeEmpty());

            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.InsuranceProducts.Add(It.IsAny<InsuranceProduct>()))
                .Callback<InsuranceProduct>(product =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = ProductDataMock.GetAddInsuranceProductDto();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act //Assert
            await Assert.ThrowsAsync<ReturnNotFoundException>(async () => await mockProduct.AddInsuranceProduct(input));
        }

        // update product
        [Fact]
        public async Task ProductService_UpdateProduct_inputNull()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.InsuranceProducts.Add(It.IsAny<InsuranceProduct>()))
                .Callback<InsuranceProduct>(product =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = new UpdateProductDto();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act //Assert
            await Assert.ThrowsAsync<ReturnBadRequestException>(async () => await mockProduct.UpdateProduct(input));
        }
        [Fact]
        public async Task ProductService_UpdateProduct_NotFound()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetById(It.IsAny<int>(), true))
                .ReturnsAsync(ProductDataMock.GetProductNull());



            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.InsuranceProducts.Add(It.IsAny<InsuranceProduct>()))
                .Callback<InsuranceProduct>(product =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = ProductDataMock.GetUpdateProductDto();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act //Assert
            await Assert.ThrowsAsync<ReturnNotFoundException>(async () => await mockProduct.UpdateProduct(input));
        }
        [Fact]
        public async Task ProductService_UpdateProduct_Success()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();


            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetById(It.IsAny<int>(), true))
                .ReturnsAsync(ProductDataMock.GetProduct());



            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = ProductDataMock.GetUpdateProductDto();

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act //Assert
            await mockProduct.UpdateProduct(input);
            Assert.True(productAdded);
        }

        // Disable Product
        [Fact]
        public async Task ProductService_DisableProduct_Success()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetById(It.IsAny<int>(), true))
                .ReturnsAsync(ProductDataMock.GetProduct());
            bool productAdded = false;
            // Thiết lập hàm callback để kiểm tra khi repo.InsuranceProducts.Add được gọi
            mockRepository.Setup(repo => repo.SaveAsync())
                .Callback(() =>
                {
                    // Trong callback, đặt biến kiểm tra thành true để chỉ ra rằng phương thức đã được gọi
                    productAdded = true;
                });

            var input = 1;

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act //Assert
            await mockProduct.DisableProduct(input);
            Assert.True(productAdded);
        }
        [Fact]
        public async Task ProductService_DisableProduct_NotFound()
        {
            // arrange
            var mockRepository = new Mock<IRepositoryManager>();
            var mockMapper = new Mock<IMapper>();

            mockRepository.Setup(repo =>
                    repo.InsuranceProducts.GetById(It.IsAny<int>(), true))
                .ReturnsAsync(ProductDataMock.GetProductNull());

            var input = 1;

            var mockProduct = new InsuranceProductService(mockRepository.Object, mockMapper.Object);
            //Act //Assert

            Assert.ThrowsAsync< ReturnNotFoundException>(async () => await mockProduct.DisableProduct(input));
        }
    }
}
