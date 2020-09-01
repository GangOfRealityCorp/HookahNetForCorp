using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public Byte Image { get; set; }
        public string Description { get; set; }

        public int ProductListingId { get; set; }   // Foreign Key
        public ProductListing ProductListing { get; set; }  // navigation property
    }
}
