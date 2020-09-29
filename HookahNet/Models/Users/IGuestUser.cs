using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public interface IGuestUser : IUser
    {
        //List<IOrder> Orders { get; }
        void AddOrder(IOrder order);
    }
}
