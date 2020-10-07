using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models.Products
{
    public abstract class Product
    {
        public Guid Id { get; set; }
        public Guid CatalogId { get; set; } // foreign key
        public Price Price { get; set; }
        private string name { get; set; }

        public string GetName()
        {
            return name;
        }

        public virtual Price GetPrice()
        {
            return Price;
        }
    }
}
