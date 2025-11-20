using AutoMapper;
using Contracts;
using Service.Contracts.Claims;
using Shared.EntityDtos.Claim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Claims
{
    public class ClaimInvoiceService : IClaimInvoiceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ClaimInvoiceService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<List<CLaimInvoiceDto>> GetAll()
        {
            var list = await _repositoryManager.ClaimInvoices.GetAll(false);
            return _mapper.Map<List<CLaimInvoiceDto>>(list);
        }
    }
}
