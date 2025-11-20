using Shared.EntityDtos.Insurances.InsuranceProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Insurances
{
    public interface IInsuranceProductService
    {
        Task<List<InsuranceProductDto>> GetAll(bool trackChanges);
        Task<InsuranceProductDto> GetById(int Id, bool trachChanges);
        Task AddInsuranceProduct(AddInsuranceProductDto productDto);
        Task UpdateProduct(UpdateProductDto updateProductdto);
        Task DisableProduct(int productId);
    }
}
