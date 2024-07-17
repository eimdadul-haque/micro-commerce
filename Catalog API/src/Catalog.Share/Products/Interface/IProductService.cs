using Catalog.Share.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Share.Products.Interface
{
    public interface IProductService
    {
        Task<IList<ProductDto>> Get(ProductFilterDto filter);
        Task<ProductDto> Get(int id);
        Task Add(ProductDto input);
        Task Update(ProductDto input);
        Task Delete(int id);
    }
}
