using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Model
{
    public class OrganizationListing
    {
        private List<Organization> organizations;

        public void AddOrganization(Organization organization)
        {
            this.organizations.Add(organization);
        }
        public List<Organization> GetOrganizations()
        {
            return organizations;
        }
    }
}
