using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HookahNet.Models.Products;

namespace HookahNet.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; private set; }
        public virtual List<ShoppingCartItem> shoppingCartItems { get; private set; } = new();
        public decimal Total { get; private set; }

        public void AddItemToList(Product product, int amount, out bool isModified)
        {
            if(shoppingCartItems.Any((item) => item.Product.Id == product.Id))
            {
                var item = shoppingCartItems.First((item) => item.Product.Id == product.Id);
                var index = shoppingCartItems.IndexOf(item);
                shoppingCartItems[index] = new ShoppingCartItem(item.Product, amount + item.Amount);
                isModified = true;
            }
            else
            {
                shoppingCartItems.Add(new ShoppingCartItem(product, amount));
                isModified = false;
            }

            Total = 
                shoppingCartItems
                    .Select((el) => el.Subtotal)
                    .Sum((subtotal) => subtotal);
        }
    }
}
