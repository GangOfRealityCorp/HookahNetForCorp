using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    [Table("FlaskFluidProductTable")]
    public class FlaskFluidProduct : Product
    {
        public string Color { get; set; }
    }
}
