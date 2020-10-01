using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HookahNet.Models.Products;

namespace HookahNet.Models
{
    public interface IProduct
    {
        Price GetPrice();
        string GetName();
    }
}
