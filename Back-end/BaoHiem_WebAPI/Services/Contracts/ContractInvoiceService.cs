using AutoMapper;
using Contracts;
using Entity.Exceptions;
using Entity.Models.InsuranceContractModels;
using Service.Contracts.Contracts;
using Shared.EntityDtos.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public class ContractInvoiceService : IContractInvoiceService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ContractInvoiceService(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            this._mapper = mapper;
            this._repository = repositoryManager;
        }
        public async Task<List<ContractInvoiceDto>> GetInvoiceByContractId(Guid contractId)
        {
            
            var contract = await _repository.Contracts.GetContractsById(contractId, false);
            if (contract == null)
                throw new Exception($"Contract with id: {contractId} dosen't exist.");
            var invoices = await _repository.ContractsInvoices.GetInvoiceByContractId(contract.Id, false);
            var returnInvoices = _mapper.Map<List<ContractInvoiceDto>>(invoices);
            return returnInvoices;
        }
        //public async Task addContractInvoice(CreateContractInvoiceDto invoiceDto)
        //{
        //    var contract = await _repository.Contracts.GetContractsById(invoiceDto.ContractId, false);
        //    if (contract == null)
        //    {
        //        throw new Exception($"Contract with Id: {invoiceDto.ContractId} dosen't exist.");
        //    }
        //    var invoice = new ContractInvoice
        //    {
        //        Id = Guid.NewGuid(),
        //        ContractID = contract.Id,
        //        LastPrice = (int)contract.TotalPrice,
        //    };
        //    var check = _repository.ContractsInvoices.AddInvoice(invoice);
        //    if (!check)
        //        throw new Exception();
        //    await _repository.SaveAsync();

        //}
        public async Task<List<ReportContractByYearDto>> GetReportByYear(int year)
        {
            var invoices = await _repository.ContractsInvoices.GetInvoiceByYear(year, false);
            var claim = await _repository.ClaimInvoices.GetByYear(year, false);
            if(invoices == null)
            {
                throw new ReturnNoContentException("Không có dữ liệu trong DB");
            }
            var reports = new List<ReportContractByYearDto>();
            for (int i = 1; i <= 12; i++)
            {
                float? totalMonth = 0;
                float? totalclaim = 0;
                totalMonth = invoices.Where(e => e.CreatedDate.Value.Month == i).Sum(e => e.LastPrice);
                totalclaim = claim.Where(e => e.CreatedDate.Month == i).Sum(e => e.TotalCost);
                reports.Add(new ReportContractByYearDto
                {
                    Month = i,
                    Contract = totalMonth,
                    Request = totalclaim
                });
            }
            return reports;
        }
        public async Task<List<ReportContractByYearDto>> GetCustomerReportByYear(int customerId, int year)
        {
            var customer = await _repository.Customers.GetCustomerAsnyc(customerId, false);
            var payment = ((await _repository.ClaimPayments.GetByCustomerId(customer.Id, false))).Where(e => e.CreatedDate.Value.Year == year).ToList();

            var claim = await _repository.ContractsInvoices.GetInvoiceByYear(year, false);
            if (payment == null)
            {
                throw new ReturnNoContentException("Không có dữ liệu trong DB");
            }
            var reports = new List<ReportContractByYearDto>();
            for (int i = 1; i <= 12; i++)
            {
                float? totalMonth = 0;
                float? totalclaim = 0;
                totalMonth = payment.Where(e => e.CreatedDate.Value.Month == i).Sum(e => e.TotalCost);
                totalclaim = claim.Where(e => e.CreatedDate.Value.Month == i).Sum(e => e.LastPrice);
                reports.Add(new ReportContractByYearDto
                {
                    Month = i,
                    Contract = totalclaim,
                    Request =  totalMonth
                });
            }
            return reports;
        }
    }
}
