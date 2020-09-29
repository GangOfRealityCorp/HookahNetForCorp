using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public interface IOrder
    {
        IGuestUser Customer { get; }
        List<ShoppingCartItem> ShoppingCartItems { get; }
    }
}
