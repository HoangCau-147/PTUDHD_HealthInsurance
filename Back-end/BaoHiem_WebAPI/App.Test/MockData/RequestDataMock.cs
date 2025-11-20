using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.Claim;
using Shared.EntityDtos.Claim;

namespace App.Test.MockData
{
    public class RequestDataMock
    {
        public static ClaimRequest GetRequest(string status)
        {
            return new ClaimRequest()
            {
                ContractId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CustomerId = Guid.NewGuid(),
                Customer = CustomerDataMock.GetCustomer(),
                HospitalBillAmount = "daklsdfj",
                Status = status
            };
        }
        public static ClaimRequest GetRequestEmpty()
        {
            return null;
        }
        public static List<ClaimRequest> GetRequests()
        {
            return new List<ClaimRequest>()
            {
                GetRequest(RequestStatus.Processing.ToString()),
                GetRequest(RequestStatus.Waiting.ToString()),
                GetRequest(RequestStatus.Accepted.ToString()),
                GetRequest(RequestStatus.Denied.ToString()),
            };
        }
        public static List<ClaimRequest> GetRequestsEmpty()
        {
            return new List<ClaimRequest>();

        }
        public static ClaimRequestDto GetClaimRequestDto()
        {
            Random rnd = new Random();
            return new ClaimRequestDto()
            {
                ClaimRequestId = Guid.NewGuid(),
                ContractId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                CustomerId = rnd.Next(1, 10),
                Status = "Waiting",
                CustomerName = "dsll",
                ProgramName = "dfsl",
                ProductName = "lkdjsal"
            };
        }

        public static CreateClaimRequestDto GetCreateClaimRequestDto()
        {
            return new CreateClaimRequestDto()
            {
                ContractId = Guid.NewGuid(),
                CustomerId = 1,
                HospitalBillAmount = "djalsk"
            };
        }
    }
}
