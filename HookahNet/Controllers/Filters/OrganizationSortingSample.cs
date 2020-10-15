using HookahNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Controllers.Filters
{
    public enum SortParameters { ByName, ByNameDesc }
    public class OrganizationSortingSample
    {
        private SortParameters sortParameter;
        public OrganizationSortingSample(SortParameters sortParameter)
        {
            this.sortParameter = sortParameter;
        }

        public void Sort(ref IQueryable<Organization> targetQuaryableOrganizations)
        {
            targetQuaryableOrganizations = sortParameter switch
            {
                SortParameters.ByName => targetQuaryableOrganizations.OrderBy(org => org.Name),
                SortParameters.ByNameDesc => targetQuaryableOrganizations.OrderByDescending(org => org.Name),
                _ => targetQuaryableOrganizations,
            };
        }
    }
}
