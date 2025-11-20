using Contracts;
using Entity.Exceptions;
using Entity.Models.Claim;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.Contracts.Claims;
using Shared.EntityDtos.Claim;
using Shared.EntityDtos.Contract;
using Shared.Helper;

namespace Services.Claims
{
    public class ClaimRequestService : IClaimRequestService
    {
        private readonly IRepositoryManager _repository;
        public ClaimRequestService(IRepositoryManager repositoryManager) { 
            _repository = repositoryManager;
        }
        public async Task<ClaimRequestDto> ConvertEntityToDto(ClaimRequest request)
        {
            var dto = new ClaimRequestDto
            {
                CreatedDate = request.CreatedDate,
                ContractId = request.ContractId,
                //MedicalCondition = request.MedicalCondition,
                //MedicalHistory = request.MedicalHistory,
                Status = request.Status,
                CustomerId = request.Customer.CustomerId,
                CustomerName = request.Customer.Name,
                HospitalBillAmount = request.HospitalBillAmount,
                ClaimRequestId = request.Id
            };
            var contract = await _repository.Contracts.GetContractsByPrimaryId(request.ContractId.GetValueOrDefault(), false);
            if (contract == null)
                throw new ReturnBadRequestException("");
            dto.ProductName = contract.InsuranceProduct.PolicyName;
            dto.ProgramName = contract.InsuranceProgram.Name;
            return dto;
        }
        public async Task CreateRequest(CreateClaimRequestDto requestDto)
        {
            var Contract = await _repository.Contracts.GetContractsById(requestDto.ContractId, false);
            if(Contract == null)
            {
                throw new ReturnNotFoundException($"Contract with id: {requestDto.ContractId} dose not exist ");
            }
            var customer = (await _repository.Customers.GetCustomerAsnyc(requestDto.CustomerId, false));
            if (customer == null)
            {
                throw new ReturnNotFoundException($"Customer with id: {requestDto.CustomerId} dose not exist ");
            }
            var newRequest = new ClaimRequest
            {
                CreatedDate = DateTime.Now,
                ContractId = Contract.Id,
                CustomerId = customer.Id,
                //MedicalCondition = requestDto.MedicalCondition,
                //MedicalHistory = requestDto.MedicalHistory,
                HospitalBillAmount = requestDto.HospitalBillAmount,
                Status = RequestStatus.Waiting.ToString()
            };
            if(!_repository.ClaimRequests.AddRequest(newRequest))
            {
                throw new ReturnBadRequestException("Contract is added unsuccessfully");
            }
            await _repository.SaveAsync();
        }
        public async Task<List<ClaimRequestDto>> GetClaimRequestOfCustomer(int cusotmerId, RequestStatus status)
        {
            var customer = await _repository.Customers.GetCustomerAsnyc(cusotmerId, false);
            if (cusotmerId == null)
            {
                throw new ReturnNotFoundException("Customer with id: {customerId} dose not exist");
            }
            var requests = (await _repository.ClaimRequests.GetCustomerRequest(customer.Id, false)).Where(e=> e.Status == status.ToString()).ToList();
            if (requests.Count == 0)
            {
                throw new ReturnNoContentException("");
            }
            var returnRequest = new List<ClaimRequestDto>();
            foreach(var request in requests)
            {
                returnRequest.Add(await ConvertEntityToDto(request));
            }
            return returnRequest;
        }
        public async Task<List<ClaimRequestDto>> GetClaimRequestByStatus(RequestStatus Status)
        {
            var requests = await _repository.ClaimRequests.GetRequestByStatus(Status.ToString(), false);
            if (requests.Count == 0)
            {
                throw new ReturnNoContentException("");
            }
            var returnRequest = new List<ClaimRequestDto>();
            foreach (var request in requests)
            {
                returnRequest.Add(await ConvertEntityToDto(request));
            }
            return returnRequest;
        }
        public async Task DenyRequest(Guid Id)
        {
            var request = await _repository.ClaimRequests.GetRequestById(Id, true);
            if(request == null)
            {
                throw new ReturnNotFoundException("Khogn tin thay request");
            }
     
            request.Status = RequestStatus.Denied.ToString();
            await _repository.SaveAsync();
        }
    }
}