using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.InsuranceModels;
using Shared.EntityDtos.Insurances.InsuranceBenefit;
using Shared.EntityDtos.Insurances.InsuranceProgram;

namespace App.Test.MockData
{
    public class BenefitDataMock
    {
        public static InsuranceBenefit GetBenefit()
        {
            return new InsuranceBenefit
            {
                BenefitId = 1,
                BenefitName = "62391837",
                BenefitTypeId = Guid.NewGuid(),
                Id = Guid.NewGuid()
            };
        }

        public static BenefitProgramCostDto GetBenefitProgramCostDto()
        {
            return new BenefitProgramCostDto()
            {
                ProgramId = 1,
                ProgramName = "đồng",
                Price = 12345
            };
        }
        public static InsuranceBenefitProductDto GetBenefitProductDto()
        {
            Random random = new Random();
            return new InsuranceBenefitProductDto()
            {
                BenefitId = random.Next(),
                Description = "daksj",
                BenefitName = "djlaks",
                benefitProgramCosts = new List<BenefitProgramCostDto>()
                {
                    GetBenefitProgramCostDto(),
                    GetBenefitProgramCostDto(),
                    GetBenefitProgramCostDto(),
                    GetBenefitProgramCostDto(),
                },
                
            };
        }

        public static AddBenefitProductDto GetAddBenefitProductDto()
        {
            Random random = new Random();
            return new AddBenefitProductDto()
            {
                BenefitId = random.Next(1,10),
                Price = 1803921
            };
        }

        public static List<AddBenefitProductDto> GetAddBenefitProductDtos()
        {
            return new List<AddBenefitProductDto>()
            {
                GetAddBenefitProductDto(),
                GetAddBenefitProductDto(),
                GetAddBenefitProductDto(),
                GetAddBenefitProductDto(),
            };
        }

        public static AddInsuranceBenefitDto GetAddInsuranceBenefitDto()
        {
            return new AddInsuranceBenefitDto()
            {
                BenefitName = "adsjlfka",
                Description = "dạlskld"
            };
        }

        public static List<AddInsuranceBenefitDto> GetAddInsuranceBenefitDtos()
        {
            return new List<AddInsuranceBenefitDto>()
            {
                GetAddInsuranceBenefitDto(),
                GetAddInsuranceBenefitDto(),
                GetAddInsuranceBenefitDto(),
                GetAddInsuranceBenefitDto(),
            };
        }
    }
}
