using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class ShoppingCartMapping
    {
        public Guid Id { get; private set; }
        //public IGuestUser GuestUser { get; private set; }
        public virtual GuestUser GuestUser { get; private set; }
        public virtual ShoppingCart ShoppingCart { get; private set; }

        public ShoppingCartMapping()
        {
        }

        public ShoppingCartMapping(GuestUser guestUser)
        {
            this.GuestUser = guestUser;
            this.ShoppingCart = new ShoppingCart();
        }

        public ShoppingCartMapping(GuestUser guestUser, ShoppingCart shoppingCart)
        {
            this.GuestUser = guestUser;
            this.ShoppingCart = shoppingCart;
        }
    }
}
