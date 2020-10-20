using HookahNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Controllers.Filters
{
    public class OrganizationPaginationSample
    {
        [JsonProperty]
        private int firstElement;
        [JsonProperty]
        private int quantity;
        public OrganizationPaginationSample(int firstElement, int quantity)
        {
            this.firstElement = firstElement;
            this.quantity = quantity;
        }

        public void Paginate(ref IQueryable<Organization> targetQuaryableOrganizations)
        {
            targetQuaryableOrganizations = targetQuaryableOrganizations
                    .Skip(firstElement)
                    .Take(quantity);
        }
    }
}
