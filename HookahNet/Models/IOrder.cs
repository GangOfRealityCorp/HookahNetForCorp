using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public interface IOrder
    {
        IGuestUser Customer { get; }
        List<ShoppingCartItem> ShoppingCartItems { get; }
    }
}
