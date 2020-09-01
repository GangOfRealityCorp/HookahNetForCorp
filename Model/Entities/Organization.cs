using HookahNet.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Byte> Images { get; set; }
        public int ProductListingId { get; set; }
        public ProductListing ProductListing { get; set; } // navigation property


        //public ProductListing ProductListing { get; set; }
        //public List<Product> Products { get; set; }

    }
}
