using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class Catalog
    {
        private string name;
        private IEnumerable<IProduct> products;
        private IEnumerable<Catalog> catalogs;

        public IEnumerable<IProduct> GetProducts()
        {
            return products;
        }
        public IEnumerable<Catalog> GetCatalogs()
        {
            return catalogs;
        }
    }
}
