using HookahNet.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class Catalog
    {
        public Guid Id { get; private set; }
        private string name;
        private IEnumerable<Product> products { get; set; }
        private IEnumerable<Catalog> catalogs;

        public Guid OrganizationId { get; private set; }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        public IEnumerable<Catalog> GetCatalogs()
        {
            return catalogs;
        }
    }
}
