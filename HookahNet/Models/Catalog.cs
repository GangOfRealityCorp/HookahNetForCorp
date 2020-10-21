using HookahNet.Models.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Models
{
    public class Catalog
    {
        public Guid Id { get; private set; }
        public Guid? ParentCatalogId { get; private set; }

        public virtual Catalog ParentCatalog { get; private set; }
        public virtual List<Catalog> ChildrenCatalogs { get; private set; }
        public string Name { get; private set; }

        public virtual List<Product> Products { get; private set; }


        public Guid? OrganizationId { get; private set; }

        public virtual Organization Organization { get; private set; }

        public Catalog(Guid? organizationId, string name)
        {
            this.OrganizationId = organizationId;
            this.Name = name;
        }
        public Catalog(string name, Guid? parentId)
        {
            this.Name = name;
            this.ParentCatalogId = parentId;
        }

        public Organization GetParentOrganization()
        {
            if (Organization != null)
                return Organization;
            return ParentCatalog.GetParentOrganization();
        }
    }
}
