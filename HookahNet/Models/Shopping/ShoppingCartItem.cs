using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HookahNet.Models.Products;

namespace HookahNet.Models
{
    public class ShoppingCartItem
    {
        private readonly IProduct product;
        private int amount;
        private Price subtotal;
        public ShoppingCartItem(IProduct product, int amount)
        {
            this.product = product;
            this.Amount = amount;
        }

        private int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                subtotal = product.GetPrice() * amount;
            }
        }

        public Price GetSubtotal()
        {
            return subtotal;
        }
    }
}
