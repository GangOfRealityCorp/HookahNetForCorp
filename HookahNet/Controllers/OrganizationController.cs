using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

using HookahNet.Controllers.DBContexts;
using HookahNet.Models;
using HookahNet.Controllers.ControllerDTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Net;
using HookahNet.Controllers.Filters;
using Newtonsoft.Json;
using Serilog;

namespace HookahNet.Controllers.Account
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class OrganizationController : Controller
    {
        private readonly StoreContext context;
        OrganizationFilterComposition organizationFilterComposition;
        public OrganizationController(StoreContext context)
        {
            this.context = context;
        }

        #region Organization

        /// <summary>
        /// Get one organization by SKU
        /// </summary>
        /// <param name="organizationSKU"></param>
        /// <returns>Json with Organization, RootCatalog, NestedCatalogs and Products.</returns>
        [HttpGet("{organizationSKU}")]
        public async Task<IActionResult> RetreveOrganizationBySKU(string organizationSKU)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((el) => el.SKU == organizationSKU);

            if (organization == null)
            {
                Log.Warning("Attempt to retrieve non-existent organisation.");
                return StatusCode((int)HttpStatusCode.NoContent, $"Organization with SKU '{organizationSKU}' not found.");
            }

            return Content(JsonConvert.SerializeObject(
                organization, 
                new JsonSerializerSettings 
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        }

        /// <summary>
        /// Create organization
        /// </summary>
        /// <param name="organizationDTO"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrganization([FromBody] OrganizationDTO organizationDTO)
        {
            if (organizationDTO.SKU == null)
                return Conflict($"SKU is required");

            var organization = await context.organizationTable.FirstOrDefaultAsync((organization) => organization.SKU == organizationDTO.SKU);
            if (organization == null)
            {
                context.organizationTable.Add(
                    new Organization(organizationDTO));
                await context.SaveChangesAsync();

                return Ok($"Organization with SKU '{organizationDTO.SKU}' has been created");
            }
            return Conflict($"Organization with SKU '{organizationDTO.SKU}' already exist");
        }

        #endregion

        #region Filters

        /// <summary>
        /// Get list of organizations with filters applied
        /// </summary>
        /// <returns></returns>
        [HttpGet("Filter")]
        public async Task<IActionResult> GetOrganizationsWithFiltersApplied()
        {
            SetFilterComposition();

            organizationFilterComposition.SetFilterParameters();
            return await ReteieveOrganizationsWithFilterComposition();
        }

        /// <summary>
        /// Get list of organizations with pagination applied
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpGet("Pagination")]
        public async Task<IActionResult> GetOrganizationsWithPaginationApplied(int firstElement, int quantity)
        {
            SetFilterComposition();

            organizationFilterComposition.SetPaginationParameters(firstElement, quantity);
            return await ReteieveOrganizationsWithFilterComposition();
        }

        /// <summary>
        /// Get list of organizations with sorting applied
        /// </summary>
        /// <param name="sortParameters"></param>
        /// <returns></returns>
        [HttpGet("Sorting")]
        public async Task<IActionResult> GetOrganizationsWithSortingApplied(SortParameters sortParameters)
        {
            SetFilterComposition();

            organizationFilterComposition.SetSortingParameters(sortParameters);
            return await ReteieveOrganizationsWithFilterComposition();
        }

        /// <summary>
        /// Get list of organizations with search applied
        /// </summary>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> GetOrganizationsWithSearchApplied()
        {
            SetFilterComposition();

            organizationFilterComposition.SetSearchParameters();
            return await ReteieveOrganizationsWithFilterComposition();
        }

        private void SetFilterComposition()
        {
            if (HttpContext.Session.Keys.Contains(SessionKeys.organizationFilterComposition.ToString()))
            {
                this.organizationFilterComposition = HttpContext.Session.Get<OrganizationFilterComposition>(SessionKeys.organizationFilterComposition);
                organizationFilterComposition.SetDbContext(context);
            }
            else this.organizationFilterComposition = new OrganizationFilterComposition(context);
        }

        private async Task<IActionResult> ReteieveOrganizationsWithFilterComposition()
        {
            try
            {
                context.ChangeTracker.LazyLoadingEnabled = false;
                var query = organizationFilterComposition.GetQueryableOrganizationsWithFilters();
                var selectedOrganizations = await query.ToListAsync();

                if (selectedOrganizations.Count == 0)
                {
                    Log.Warning("Attempt to apply filters with incorrect parameters.");
                    return StatusCode((int)HttpStatusCode.NoContent, "Out of bounds the Organizations list");
                }

                var queryWithoutPagination = organizationFilterComposition.GetQueryableOrganizationWithoutPagination();
                int count = await queryWithoutPagination.CountAsync();

                HttpContext.Session.Set(SessionKeys.organizationFilterComposition, organizationFilterComposition);

                return Json(new { selectedOrganizations, count });
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
        }

        #endregion

        #region Organization/Catalog

        /// <summary>
        /// Create catalog for organization by organizationSKU
        /// </summary>
        /// <param name="organizationSKU"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost("{organizationSKU}/CreateRootCatalog")]
        public async Task<IActionResult> CreateRootCatalogByOrganizationSKU(string organizationSKU, [FromBody] string catalogName)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((organization) => organization.SKU == organizationSKU);
            if (organization == null)
            {
                return StatusCode(
                    (int)HttpStatusCode.NoContent,
                    $"Organization with SKU '{organizationSKU}' is not exist.");
            }

            var catalog = await context.catalogTable.FirstOrDefaultAsync((catalog) => catalog.OrganizationId == organization.Id);
            if (catalog != null)
            {
                Log.Warning($"Attempt to create existing root catalog to organization '{organization.SKU}'.");
                return BadRequest($"Root catalog for organization '{organization.SKU}' already exist");
            }

            context.catalogTable.Add(
                new Catalog(organization.Id, catalogName));
            await context.SaveChangesAsync();

            return Ok($"Root catalog for organization '{organization.SKU}' has been created");
        }


        [HttpPost("{parentCatalogName}/CreateNestedCatalog")]
        public async Task<IActionResult> CreateNestedCatalogByParentCatalogName(string parentCatalogName, [FromBody] string childCatalogName)
        {
            //TODO: Constraint catalogs via Organizations in Claims
            var parentCatalog = await context.catalogTable.FirstOrDefaultAsync((catalog) => catalog.Name == parentCatalogName);
            if (parentCatalog == null)
            {
                return StatusCode(
                    (int)HttpStatusCode.NoContent,
                    $"Parent catalog with name '{parentCatalogName}' is not exist.");
            }

            context.catalogTable.Add(
                new Catalog(childCatalogName, (Guid?)parentCatalog.Id));
            await context.SaveChangesAsync();

            return Ok("Child catalog has been created");
        }

        #endregion
    }
}
