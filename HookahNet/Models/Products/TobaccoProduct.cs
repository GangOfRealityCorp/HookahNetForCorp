using HookahNet.Controllers.ControllerDTO;
using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    [Table("TobaccoProductTable")]
    public class TobaccoProduct : Product
    {
        public string Brand { get; private set; }
        public string Strength { get; private set; }
        public TobaccoProduct()
        {
        }
        public TobaccoProduct(ProductDTO productDTO) : base(productDTO)
        {
            this.Brand = productDTO.TobaccoProductBrand;
        }
        public string GetName()
        {
            throw new NotImplementedException();
        }

        public Price GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
