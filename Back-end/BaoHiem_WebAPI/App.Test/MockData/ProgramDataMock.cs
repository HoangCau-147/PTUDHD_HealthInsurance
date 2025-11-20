using Entity.Models.InsuranceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.EntityDtos.Insurances;

namespace App.Test.MockData
{
    public class ProgramDataMock
    {
        public static InsuranceProgram GetProgramId1()
        {
            return new InsuranceProgram
            {
                ProgramId = 1,
                Id = Guid.NewGuid(),
                Name = "Bronze"
            };
        }
        public static InsuranceProgram GetProgramNull()
        {
            return null;
        }

        public static List<InsuranceProgram> GetPrograms()
        {
            return new List<InsuranceProgram>()
            {
                new InsuranceProgram
                {
                    ProgramId = 1,
                    Id = Guid.NewGuid(),
                    Name = "Bronze"
                },
                new InsuranceProgram
                {
                    ProgramId = 2,
                    Id = Guid.NewGuid(),
                    Name = "Bronze"
                },
                new InsuranceProgram
                {
                    ProgramId = 3,
                    Id = Guid.NewGuid(),
                    Name = "Bronze"
                },
                new InsuranceProgram
                {
                    ProgramId = 4,
                    Id = Guid.NewGuid(),
                    Name = "Bronze"
                },
                new InsuranceProgram
                {
                    ProgramId = 5,
                    Id = Guid.NewGuid(),
                    Name = "Bronze"
                },
            };
        }

        public static AddProgramPricePerProductDto GetAddProgramPricePerProductDto()
        {
            return new AddProgramPricePerProductDto()
            {
                price = 1234,
                ProgramId = 1,
                ProgramName = "sád"
            };
        }
        public static List<AddProgramPricePerProductDto> GetAddProgramPricePerProductDtos()
        {
            return new List<AddProgramPricePerProductDto>
            {
                new AddProgramPricePerProductDto()
                {
                    price = 1234,
                    ProgramId = 1,
                    ProgramName = "sád"
                },               
                new AddProgramPricePerProductDto()
                {
                    price = 1234,
                    ProgramId = 2,
                    ProgramName = "sád"
                },               
                new AddProgramPricePerProductDto()
                {
                    price = 1234,
                    ProgramId = 3,
                    ProgramName = "sád"
                },               
                new AddProgramPricePerProductDto()
                {
                    price = 1234,
                    ProgramId = 4,
                    ProgramName = "sád"
                },               
                new AddProgramPricePerProductDto()
                {
                    price = 1234,
                    ProgramId = 5,
                    ProgramName = "sád"
                },
            };
        }

        public static List<InsuranceProgram> GetProgramsEmpty()
        {
            return new List<InsuranceProgram>();
        }
    }
}
