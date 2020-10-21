using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HookahNet.Controllers.ControllerDTO;

namespace HookahNet.Models.Products
{
    /// <summary>
    /// 1 - Tobacco
    /// 2 - Hookah
    /// 3 - FlaskFluid
    /// </summary>
    public enum ProductTypes { Tobacco = 1, Hookah, FlaskFluid }
    public abstract class Product
    {
        public Guid Id { get; private set; }
        public Guid CatalogId { get; private set; } // foreign key
        public virtual Price Price { get; private set; }
        public string Name { get; private set; }
        public string SKU { get; private set; }
        public ProductTypes ProductType { get; private set; }
        public Product()
        {
        }
        public Product(ProductDTO productDTO)
        {
            this.Name = productDTO.Name;
            this.SKU = productDTO.SKU;
            this.CatalogId = productDTO.CatalogId;
            this.ProductType = productDTO.ProductType;
        }

        public string GetName()
        {
            return Name;
        }

        public virtual Price GetPrice()
        {
            return Price;
        }
    }
}
