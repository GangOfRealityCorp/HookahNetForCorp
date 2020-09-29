using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public class Order : IOrder
    {
        public IGuestUser Customer { get; }
        public List<ShoppingCartItem> ShoppingCartItems { get; }
        public Order(ShoppingCart shoppingCart, IGuestUser customer)
        {
            throw new NotImplementedException();
        }
    }
}
