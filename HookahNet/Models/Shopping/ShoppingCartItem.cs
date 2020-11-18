using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HookahNet.Models.Products;

namespace HookahNet.Models
{
    public class ShoppingCartItem
    {
        public Guid Id { get; private set; }
        //public IProduct Product { get; private set; }
        public virtual Product Product { get; private set; }
        private int amount;
        public decimal Subtotal { get; private set; }
        public ShoppingCartItem()
        {
        }
        public ShoppingCartItem(Product product, int amount)
        {
            this.Product = product;
            this.Amount = amount;
        }

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                Subtotal = Product.Price.Value * amount;
            }
        }
    }
}
