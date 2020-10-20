using HookahNet.Controllers.ControllerDTO;
using HookahNet.Controllers.DBContexts;
using HookahNet.Controllers.Filters;
using HookahNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Controllers
{
    public class OrganizationFilterComposition
    {
        private IQueryable<Organization> queryableOrganizations;
        private IQueryable<Organization> queryableOrganizationsWithoutPagination;

        [JsonProperty]
        private OrganizationSortingSample organizationSortingSample;
        [JsonProperty]
        private OrganizationPaginationSample organizationPaginationSample;
        [JsonProperty]
        private OrganizationFiltersSample organizationFiltersSample;
        [JsonProperty]
        private OrganizationSearchSample organizationSearchSample;
        public OrganizationFilterComposition()
        {
        }
        public OrganizationFilterComposition(StoreContext storeContext)
        {
            SetDbContext(storeContext);
        }

        public void SetDbContext(StoreContext storeContext)
        {
            queryableOrganizations = storeContext.organizationTable.AsQueryable();
            queryableOrganizationsWithoutPagination = storeContext.organizationTable.AsQueryable();
        }

        public IQueryable<Organization> GetQueryableOrganizationsWithFilters()
        {
            organizationSortingSample?.Sort(ref queryableOrganizations);
            organizationPaginationSample?.Paginate(ref queryableOrganizations);
            return queryableOrganizations;
        }

        public IQueryable<Organization> GetQueryableOrganizationWithoutPagination()
        {
            organizationSortingSample?.Sort(ref queryableOrganizationsWithoutPagination);
            return queryableOrganizationsWithoutPagination;
        }

        internal void SetFilterParameters()
        {
            throw new NotImplementedException();
        }

        internal void SetPaginationParameters(int firstElement, int quantity)
        {
            organizationPaginationSample = new OrganizationPaginationSample(
                firstElement,
                quantity);
        }

        internal void SetSortingParameters(SortParameters sortParameters)
        {
            organizationSortingSample = new OrganizationSortingSample(sortParameters);
        }

        internal void SetSearchParameters()
        {
            throw new NotImplementedException();
        }
    }
}
