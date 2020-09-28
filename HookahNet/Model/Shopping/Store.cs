using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public class Store
    {
        private Dictionary<IGuestUser, ShoppingCart> cartMap = new Dictionary<IGuestUser, ShoppingCart>();

        public void AddToShoppingCart(IGuestUser guestUser, IProduct product, int amount)
        {
            if (!cartMap.ContainsKey(guestUser))
            {
                cartMap.Add(guestUser, new ShoppingCart());
            }
            var shoppingCart = cartMap[guestUser];
            shoppingCart.AddItemToList(product, amount);
        }
        public void ConvertToOrder(ShoppingCart shoppingCart, IGuestUser customer)
        {
            IOrder order = new Order(shoppingCart, customer);
            customer.AddOrder(order);
        }
    }
}
