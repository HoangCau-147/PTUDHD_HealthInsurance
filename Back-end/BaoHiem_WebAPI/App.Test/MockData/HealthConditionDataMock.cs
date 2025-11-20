using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.InsuranceModels;
using Shared.EntityDtos.Insurances.HealthCondition;

namespace App.Test.MockData
{
    public static class HealthConditionDataMock
    {
        public static HealthCondition GetCondition()
        {
            return new HealthCondition
            {
                HealthConditionId = 1,
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Name = "dfsa",
                Question = "daf"
            };
        }

        public static List<HealthCondition> GetConditionList()
        {
            return new List<HealthCondition>()
            {
                GetCondition(),
                GetCondition(),
                GetCondition(),
                GetCondition()
            };
        }

        public static HealthConditionProductDto GetConditionProductDto()
        {
            Random random = new Random();
            return new HealthConditionProductDto()
            {
                HealthConditionId = random.Next(),
                Name = "djlfajks",
                Question = "djalskjf"
            };
        }

        public static List<HealthConditionProductDto> GetConditionProductDtos()
        {
            return new List<HealthConditionProductDto>()
            {
                GetConditionProductDto(),
                GetConditionProductDto(),
                GetConditionProductDto(),
                GetConditionProductDto(),
            };
        }
    }
}
