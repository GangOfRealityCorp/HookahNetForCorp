using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HookahNet.Model.Products;

namespace HookahNet.Model
{
    public interface IProduct
    {
        Price GetPrice();
        string GetName();
    }
}
