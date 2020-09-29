using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class GuestUser : IGuestUser
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        //public List<IOrder> Orders { get; private set; }
        public GuestUser(string Name, string Password)
        {
            this.Name = Name;
            this.Password = Password;
        }
        public void AddOrder(IOrder order)
        {
            //Orders.Add(order);
        }
    }
}
