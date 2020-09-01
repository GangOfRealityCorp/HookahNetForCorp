using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model.Entities
{
    public class ProductListing
    {
        public int ProductListingId { get; set; }
        public List<Product> Products { get; set; }


        public int OrganizationId { get; set; }
        public Organization Organization { get; set; } // navigation property
    }
}
