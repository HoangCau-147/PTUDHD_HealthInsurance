using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.EntityDtos.Insurances.HealthCondition;
using Shared.EntityDtos.Insurances.InsuranceProduct;

namespace App.Test.MockData
{
    public class ProductDataMock
    {
        public static InsuranceProduct GetProduct()
        {
            Random random = new Random();
            return new InsuranceProduct
            {
                ShortDescription = "Test",
                BenefitTypes = new List<InsuranceBenefitType>
                {
                    BenefitTypeDataMock.GetBenefitType(),
                    BenefitTypeDataMock.GetBenefitType(),
                    BenefitTypeDataMock.GetBenefitType(),
                    
                },
                ProductId = random.Next(),
                Id = Guid.NewGuid(),
                HealthConditionSource = new List<HealthCondition>
                {
                    new HealthCondition
                    {
                        Id = Guid.NewGuid(),
                        HealthConditionId = 1
                    },
                    new HealthCondition
                    {
                        Id = Guid.NewGuid(),
                        HealthConditionId = 2
                    },
                },
                Commitment = "fdajls",
                FeeGuarantee = "fdasjf",
                ImageUrl = "dhask",
                InsuredParty = "jdflaskjf",
                TerritorialScope = "jdflakjfs",
                Status = "ENABLED",
                Prices = PriceDataMock.GetPrices(),
                Costs = BenefitCostDataMock.GetBenefitCostList()
            };
        }
        public static List<InsuranceProduct> GetProductsEmpty()
        {
            return new List<InsuranceProduct>
            {
                
            };
        }
        public static InsuranceProduct GetProductNull()
        {
            return null;
        }
        public static InsuranceProduct GetProductConditionNull()
        {
            return new InsuranceProduct
            {
                ShortDescription = "Test",
                BenefitTypes = null,
                ProductId = 7,
                Id = Guid.Parse("184051AB-E6F4-48AA-3782-08DBFBCD31FD"),
                HealthConditionSource = null
            };
        }

        public static InsuranceProductDto GetProductDto()
        {
            return new InsuranceProductDto()
            {


            };
        }

        public static List<InsuranceProduct> GetProducts()
        {
            Random random = new Random();
            return new List<InsuranceProduct>()
            {
                GetProduct(),
                GetProduct(),
                GetProduct(),
                new InsuranceProduct
                {
                    ShortDescription = "Test",
                    BenefitTypes = new List<InsuranceBenefitType>
                    {
                        BenefitTypeDataMock.GetBenefitType(),
                        BenefitTypeDataMock.GetBenefitType(),
                        BenefitTypeDataMock.GetBenefitType(),

                    },
                    ProductId = random.Next(),
                    Id = Guid.NewGuid(),
                    HealthConditionSource = new List<HealthCondition>
                    {
                        HealthConditionDataMock.GetCondition(),
                        HealthConditionDataMock.GetCondition(),
                    },
                    Commitment = "fdajls",
                    FeeGuarantee = "fdasjf",
                    ImageUrl = "dhask",
                    InsuredParty = "jdflaskjf",
                    TerritorialScope = "jdflakjfs",
                    Status = "ENABLED",
                    Prices = PriceDataMock.GetPrices(),
                    Costs = BenefitCostDataMock.GetBenefitCostList()
                }
        };
        }

        public static AddInsuranceProductDto GetAddInsuranceProductDto()
        {
            return new AddInsuranceProductDto()
            {
                PolicyName = "đấ",
                InsuredParty = "jkls",
                FeeGuarantee = "kajks",
                Commitment = "fjdla",
                ParticipationProcedure = "dalks",
                ShortDescription = "djlask",
                ImageUrl = "djaksl",
                Conditions = HealthConditionDataMock.GetConditionProductDtos(),
                ProgramPrices = ProgramDataMock.GetAddProgramPricePerProductDtos(),
                BenefitTypes = BenefitTypeDataMock.GetAddBenefitTypeInProducts()
            };
        }

        public static UpdateProductDto GetUpdateProductDto()
        {
            return new UpdateProductDto()
            {
                ProductId = 1,
                PolicyName = "đấ",
                InsuredParty = "jkls",
                FeeGuarantee = "kajks",
                Commitment = "fjdla",
                ParticipationProcedure = "dalks",
                ShortDescription = "djlask",
                ImageUrl = "djaksl",
                TerritorialScope = "sakljfkd"
            };
        }
    }
}
