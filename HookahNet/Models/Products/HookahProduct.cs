using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    [Table("HookahProductTable")]
    public class HookahProduct : Product
    {
        public new Guid Id { get; set; }
        public virtual List<Product> Products { get; set; }

        public string Brand { get; set; }
        public HookahProduct()
        {
            Products = new List<Product>();
        }

        //public override Price GetPrice()
        //{
        //    Price price = new Price();
        //    foreach (var product in Products)
        //    {
        //        price += product.GetPrice();
        //    }
        //    return price;
        //}

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
