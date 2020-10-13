using HookahNet.Controllers.ControllerDTO;
using HookahNet.Controllers.DBContexts;
using HookahNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HookahNet.Controllers
{
    public class OrganizationFilter
    {
        private FiltersDTO filtersDTO;
        private IQueryable<Organization> selectedOrganizations;
        public OrganizationFilter(StoreContext storeContext, FiltersDTO filtersDTO)
        {
            this.filtersDTO = filtersDTO;
            selectedOrganizations = storeContext.organizationTable;
        }

        public enum SortParameters { ByName, ByNameDesc}

        private void Paginate()
        {
            selectedOrganizations = selectedOrganizations
                    .Skip(filtersDTO.FirstElement)
                    .Take(filtersDTO.Quantity);
        }

        private void Sort()
        {
            selectedOrganizations = filtersDTO.SortParameter switch
            {
                SortParameters.ByName => selectedOrganizations.OrderBy(org => org.Name),
                SortParameters.ByNameDesc => selectedOrganizations.OrderByDescending(org => org.Name),
                _ => selectedOrganizations,
            };
        }

        public IQueryable<Organization> GetQueryableOrganizationsWithFilters()
        {
            Sort();
            Paginate();
            return selectedOrganizations;
        }

        public IQueryable<Organization> GetQueryableOrganizationWithoutPagination()
        {
            Sort();
            return selectedOrganizations;
        }
    }
}
