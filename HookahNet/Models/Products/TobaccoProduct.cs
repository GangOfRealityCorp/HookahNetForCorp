using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    [Table("TobaccoProductTable")]
    public class TobaccoProduct : Product
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
