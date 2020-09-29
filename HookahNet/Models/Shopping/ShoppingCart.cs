using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HookahNet.Model.Products;

namespace HookahNet.Model
{
    public class ShoppingCart
    {
        private List<ShoppingCartItem> shoppingCartItems;
        private Price total;

        public Price GetTotal()
        {
            return total;
        }
        public void AddItemToList(IProduct product, int amount)
        {
            shoppingCartItems.Add(new ShoppingCartItem(product, amount));
            total = new Price(
                shoppingCartItems.Select((el) => el.GetSubtotal())
                                 .Sum((subtotal) => subtotal.value),
                total.currency);
        }
        public List<ShoppingCartItem> GetItems()
        {
            return shoppingCartItems;
        }
    }
}
