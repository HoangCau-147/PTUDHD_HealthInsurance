using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.InsuranceModels;

namespace App.Test.MockData
{
    public class BenefitCostDataMock
    {
        public static InsuranceBenefitCost GetBenefitCost()
        {
            return new InsuranceBenefitCost()
            {
                BenefitId = Guid.NewGuid(),
                ProgramId = Guid.NewGuid(),
                PolicyId = Guid.NewGuid(),
                Cost = 1000
            };
        }

        public static List<InsuranceBenefitCost> GetBenefitCostList()
        {
            return new List<InsuranceBenefitCost>()
            {
                GetBenefitCost(),
                GetBenefitCost(),
                GetBenefitCost(),
            };
        }
    }
}
