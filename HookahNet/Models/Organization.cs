using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class Organization
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Catalog Catalog { get; private set; }

        public Organization()
        {
        }
        public Organization(string name)
        {
            this.Name = name;
            this.Catalog = new Catalog();
        }

        public Catalog GetCatalog()
        {
            return Catalog;
        }
    }
}
