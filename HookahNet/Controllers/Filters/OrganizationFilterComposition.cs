using HookahNet.Controllers.ControllerDTO;
using HookahNet.Controllers.DBContexts;
using HookahNet.Controllers.Filters;
using HookahNet.Models;
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

        private OrganizationSortingSample organizationSortingSample;
        private OrganizationPaginationSample organizationPaginationSample;
        private OrganizationFiltersSample organizationFiltersSample;
        private OrganizationSearchSample organizationSearchSample;
        public OrganizationFilterComposition(StoreContext storeContext)
        {
            queryableOrganizations = storeContext.organizationTable;
            queryableOrganizationsWithoutPagination = storeContext.organizationTable;
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
