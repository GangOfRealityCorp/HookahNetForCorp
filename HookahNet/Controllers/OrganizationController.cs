﻿using System;
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

namespace HookahNet.Controllers.Account
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class OrganizationController : Controller
    {
        private readonly StoreContext context;
        public OrganizationController(StoreContext context)
        {
            this.context = context;
        }

        #region Organization

        [HttpPost]
        public async Task<IActionResult> RetreveOrganizationsWithFilters([FromBody] FiltersDTO filtersDTO)
        {
            try
            {
                OrganizationFilter organizationFilter = new OrganizationFilter(context, filtersDTO);
                var query = organizationFilter.GetQueryableOrganizationsWithFilters();
                var selectedOrganizations = await query.ToListAsync();

                if (selectedOrganizations.Count == 0)
                {
                    //TODO: add logs
                    return StatusCode((int)HttpStatusCode.NoContent, "Out of bounds the Organizations list");
                }


                OrganizationFilter organizationFilterWithoutPagination = new OrganizationFilter(context, filtersDTO);
                var queryWithoutPagination = organizationFilterWithoutPagination.GetQueryableOrganizationWithoutPagination();
                int count = await queryWithoutPagination.CountAsync();

                return Json(new { selectedOrganizations, count});
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet("{organizationSKU}")]
        public async Task<IActionResult> RetreveOrganizationBySKU(string organizationSKU)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((el) => el.SKU == organizationSKU);
            if (organization == null)
            {
                //TODO: add logs
                return NoContent();
            }

            return Json(organization);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrganization([FromBody] OrganizationDTO organizationDTO)
        {
            if(organizationDTO.SKU == null)
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

        #region Organization/Catalog

        [HttpGet("{organizationSKU}/Catalog")]
        public async Task<IActionResult> RetreveCatalogByOrganizationSKU(string organizationSKU)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((organization) => organization.SKU == organizationSKU);
            if(organization == null)
                return NoContent();

            var catalog = await context.catalogTable.FirstOrDefaultAsync((catalog) => catalog.OrganizationId == organization.Id);
            if (catalog == null)
            {
                //TODO: add logs
                return NoContent();
            }

            return Json(catalog);
        }

        [HttpPost("{organizationSKU}/Catalog")]
        public async Task<IActionResult> CreateCatalogByOrganizationSKU(string organizationSKU, [FromBody] string name)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((organization) => organization.SKU == organizationSKU);
            if (organization == null)
                return NoContent();

            var catalog = await context.catalogTable.FirstOrDefaultAsync((catalog) => catalog.OrganizationId == organization.Id);
            if (catalog != null)
            {
                //TODO: add logs
                return BadRequest("Catalog already exist");
            }

            context.catalogTable.Add(
                new Catalog(organization.Id, name));
            await context.SaveChangesAsync();

            return Ok("Catalog has been created");
        }

        #endregion

    }
}
