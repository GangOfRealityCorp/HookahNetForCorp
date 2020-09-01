using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model.Entities
{
    public class OrganizationListing
    {
        public List<Organization> Organizations { get; set; }

        public List<Organization> Search(string organizationName)
        {
            return null;
        }
        public void Add(Organization organization)
        {
            Organizations.Add(organization);
        }
        public void Sort(/*to add enum*/)
        {
            this.Organizations = new List<Organization>();
            //TODO: will make via standart List() methods.
        }
    }
}
