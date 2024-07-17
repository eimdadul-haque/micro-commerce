using Catalog.Domain.products;
using Catalog.Infrastructure;
using Catalog.Share.Products.Dtos;
using Catalog.Share.Products.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly CatalogDbContext _catalogDbContext;
        public ProductService(
             CatalogDbContext catalogDbContext) 
        {
            _catalogDbContext = catalogDbContext;
        }

        public async Task<IList<ProductDto>> Get(ProductFilterDto filter)
        {
            var productQuery = _catalogDbContext
                .Products
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Keyword))
            {
                productQuery = productQuery
                    .Where(p => p.Name.Contains(filter.Keyword)
                    || p.Description.Contains(filter.Keyword)
                    || p.Summary.Contains(filter.Keyword));
            }

            var products = await productQuery.Select(p => new ProductDto() 
            {
              Id = p.Id,
              Name = p.Name,
              Description = p.Description,
              Summary = p.Summary,
              Price = p.Price,
              Category = p.Category
            }).ToListAsync();

            return products;
        }

        public async Task<ProductDto> Get(int id)
        {
            var productQuery = _catalogDbContext
                .Products
                .AsQueryable();

            var product = await productQuery.Select(p => new ProductDto()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Summary = p.Summary,
                Price = p.Price,
                Category = p.Category
            }).FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task Add(ProductDto input)
        {
            var product = new Product()
            {
                Name = input.Name,
                Description = input.Description,
                Summary = input.Summary,
                Price = input.Price,
                Category = input.Category,
                Created = input.Created,
                CreatorId = input.CreatorId
            };

            await _catalogDbContext.Products.AddAsync(product);
            await _catalogDbContext.SaveChangesAsync();
        }

        public async Task Update(ProductDto input)
        {
            var product = _catalogDbContext.Products
                .FirstOrDefault(p => p.Id == input.Id);

            product.Name = input.Name;
            product.Description = input.Description;
            product.Summary = input.Summary;
            product.Price = input.Price;
            product.Category = input.Category;
            product.Created = input.Created;
            product.CreatorId = input.CreatorId;
            
            _catalogDbContext.Products.Update(product);
            await _catalogDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = _catalogDbContext.Products
                .FirstOrDefault(p => p.Id == id);

            if(product == null)
                throw new Exception("Product not found!");

            _catalogDbContext.Remove(product);
            await _catalogDbContext.SaveChangesAsync();
        }
    }
}
