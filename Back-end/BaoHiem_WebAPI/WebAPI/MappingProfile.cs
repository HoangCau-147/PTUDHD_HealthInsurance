using AutoMapper;
using Entity.Models;
using Entity.Models.Claim;
using Entity.Models.Customers;
using Entity.Models.InsuranceContractModels;
using Entity.Models.InsuranceModels;
using Entity.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.EntityDtos.Claim;
using Shared.EntityDtos.Contract;
using Shared.EntityDtos.Customer;
using Shared.EntityDtos.Insurances;
using Shared.EntityDtos.Insurances.HealthCondition;
using Shared.EntityDtos.Insurances.InsuranceBenefit;
using Shared.EntityDtos.Insurances.InsuranceProduct;
using Shared.EntityDtos.Insurances.InsuranceProgram;
using Shared.EntityDtos.Staff;
using Shared.UserDto;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserRegistrationDto>().ReverseMap();
            
            //staff
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            //customer
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();

            //contract
            CreateMap<HealthCondition, RegisterContractHealthConditionDto>().ReverseMap();
            CreateMap<ContractHealthCondition, ContractHealthConditionDto>().ReverseMap();
            CreateMap<Contract, RegisterContractDto>().ReverseMap();
            CreateMap<Contract, ContractDto>().ReverseMap();

            CreateMap<ContractInvoice, ContractInvoiceDto> ().ReverseMap();

            //insurance
            CreateMap<InsuranceProduct, InsuranceProductDto>().ReverseMap();
            CreateMap<InsuranceProduct, AddInsuranceProductDto>().ReverseMap();
            CreateMap<HealthConditionProductDto, HealthCondition>().ReverseMap();
            CreateMap<HealthConditionDto, HealthCondition>().ReverseMap();
            CreateMap<AddHealthConditionDto, HealthCondition>().ReverseMap();
            CreateMap<AddInsuranceBenefitTypeDto, InsuranceBenefitType>().ReverseMap();
            CreateMap<InsuranceBenefitTypeDto, InsuranceBenefitType>().ReverseMap();
            CreateMap<InsuranceBenefitDto, InsuranceBenefit>().ReverseMap();
            CreateMap<AddInsuranceBenefitDto, InsuranceBenefit>().ReverseMap();
            CreateMap<BenefitProductDto, InsuranceBenefit>().ReverseMap();
            CreateMap<InsuranceBenefitTypeProductDto, InsuranceBenefitType>().ReverseMap();
            CreateMap<InsuranceBenefitProductDto, InsuranceBenefit>().ReverseMap();

            CreateMap<InsuranceProgramDto, InsuranceProgram>().ReverseMap();
            CreateMap<AddInsuranceProgramDto, InsuranceProgram>().ReverseMap();

            //Claim
            CreateMap<ClaimPayment, ClaimPaymentDto>().ReverseMap();
            CreateMap<ClaimHealthDto, ClaimHealthService>().ReverseMap();
            CreateMap<ClaimInvoice, CLaimInvoiceDto>().ReverseMap();

        }
    }
}
