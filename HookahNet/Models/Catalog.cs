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
        public string Name { get; private set; }
        public List<Product> Products { get; private set; }
        private IEnumerable<Catalog> catalogs;

        public Guid OrganizationId { get; private set; }
        public Catalog(Guid organizationId, string name)
        {
            this.OrganizationId = organizationId;
            this.Name = name;
        }

        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }
        public IEnumerable<Catalog> GetCatalogs()
        {
            return catalogs;
        }
    }
}
