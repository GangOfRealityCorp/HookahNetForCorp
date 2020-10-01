using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
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
