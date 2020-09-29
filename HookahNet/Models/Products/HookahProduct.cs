using HookahNet.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public class HookahProduct : IProduct
    {
        public string GetName()
        {
            throw new NotImplementedException();
        }

        public Price GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
