using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HookahNet.Models.Products.Product;

namespace HookahNet.Controllers.ControllerDTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public Guid CatalogId { get; set; }
        public ProductTypes ProductType { get; set; }
        public string TobaccoProductBrand { get; set; }
        public string FlaskFluidProductColor { get; set; }
    }
}
