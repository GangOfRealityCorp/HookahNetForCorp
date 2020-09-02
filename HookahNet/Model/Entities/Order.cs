using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<ShoppingCartItem> OrderedItems { get; set; }
        private decimal Total { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
        public Organization Organization { get; set; }
    }
}
