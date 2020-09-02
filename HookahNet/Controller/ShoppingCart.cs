using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HookahNet.Model.Entities
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> OrderedItems { get; set; }
        private decimal total;
        public ShoppingCart()
        {
            OrderedItems = new List<ShoppingCartItem>();
        }
        public ShoppingCart(List<ShoppingCartItem> orderItems)
        {
            OrderedItems = new List<ShoppingCartItem>(orderItems);
        }

        public void AddToCart(ShoppingCartItem orderItems)
        {
            OrderedItems.Add(orderItems);
        }
        public void RemoveFromCart(ShoppingCartItem orderItems)
        {
            OrderedItems.Remove(orderItems);
        }
        public void ClearCart()
        {
            OrderedItems.Clear();
        }
        public decimal GetTotal()
        {
            foreach(var item in OrderedItems)
            {
                total += item.GetSubtotal();
            }
            return total;
        }
        public Order CreateOrder()
        {
            return new Order();
        }
    }
}
