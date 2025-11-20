using Contracts.InsuranceContracts;
using Entity.Models.InsuranceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesRepository.Insurance
{
    public class InsuranceProgramRepository : RepositoryBase<InsuranceProgram>, IInsuranceProgramRepository
    {
        public InsuranceProgramRepository(InsuranceDBContext insuranceDBContext) : base(insuranceDBContext)
        {
        }

        public bool Add(InsuranceProgram program)
        {
            return Create(program);
        }
        public async Task<InsuranceProgram> GetById(int id)
        {
            return await FindByCondition(e => e.ProgramId == id, false).SingleOrDefaultAsync();
        }
        public async Task<List<InsuranceProgram>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
        public async Task<InsuranceProgram> GetByNameAsync(string name)
        {
            return await FindByCondition(e => e.NormalizedName == name.ToUpper(), false).SingleOrDefaultAsync();
        }

        public List<InsuranceProgram> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }
        public async Task<InsuranceProgram> GetByGuidId(Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id == id, trackChanges).SingleOrDefaultAsync();
        }
        public async Task<bool> checkExistById(int id)
        {
            var program = await FindByCondition(e => e.ProgramId == id, false).SingleOrDefaultAsync();
            if(program != null)
            {
                return true;
            }
            return false;
        }
    }
}
