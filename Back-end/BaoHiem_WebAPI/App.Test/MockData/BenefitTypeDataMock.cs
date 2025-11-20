using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.InsuranceModels;
using Shared.EntityDtos.Insurances.InsuranceBenefit;

namespace App.Test.MockData
{
    public class BenefitTypeDataMock
    {
        public static InsuranceBenefitType GetBenefitType()
        {
            return new InsuranceBenefitType
            {
                Id = Guid.NewGuid(),
                BenefitTypeId = 1,
                Name = "dhfalksdj",
                Benefits = new List<InsuranceBenefit>
                {
                    BenefitDataMock.GetBenefit(),
                    BenefitDataMock.GetBenefit()
                }
            };
        }
        public static InsuranceBenefitType GetBenefitTypeEmpty()
        {
            return null;
        }
        public static AddInsuranceBenefitTypeDto GeAddInsuranceBenefitTypeDto()
        {
            return new AddInsuranceBenefitTypeDto()
            {
                Name = "sjalskdf",
                benefits = BenefitDataMock.GetAddInsuranceBenefitDtos()
            };
        }

        public static AddBenefitTypeInProduct GetAddBenefitTypeInProduct()
        {
            Random rnd = new Random();
            return new AddBenefitTypeInProduct()
            {
                Name = "hska",
                BenefitTypeId = rnd.Next(1, 10),
                Benefits = BenefitDataMock.GetAddBenefitProductDtos()
            };
        }

        public static List<AddBenefitTypeInProduct> GetAddBenefitTypeInProducts()
        {
            return new List<AddBenefitTypeInProduct>()
            {
                GetAddBenefitTypeInProduct(),
                GetAddBenefitTypeInProduct(),
                GetAddBenefitTypeInProduct()
            };
        }
    }
}
