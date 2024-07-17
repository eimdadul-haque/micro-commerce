using Catalog.Share.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Share.Products.Dtos
{
    public class ProductDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
