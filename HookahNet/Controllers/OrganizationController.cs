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

        [HttpGet]
        public async Task<IActionResult> RetreveOrganizations()
        {
            var organizations = await context.organizationTable.ToListAsync();
            if (organizations.Count == 0)
            {
                //TODO: add logs
                return NoContent();
            }

            return Json(organizations);
        }

        [HttpGet("{organizationName}")]
        public async Task<IActionResult> RetreveOrganizationByName(string organizationName)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((el) => el.Name == organizationName);
            if (organization == null)
            {
                //TODO: add logs
                return NoContent();
            }

            return Json(organization);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization([FromBody] OrganizationDTO organizationDTO)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((organization) => organization.Name == organizationDTO.Name);
            if (organization == null)
            {
                context.organizationTable.Add(new Organization(
                    organizationDTO.Name));
                await context.SaveChangesAsync();

                return Ok($"Organization with Name '{organizationDTO.Name}' has been created");
            }
            return Conflict($"Organization with Name '{organizationDTO.Name}' already exist");
        }

        #endregion

        #region Organization/Catalog

        [HttpGet("{organizationName}/Catalog")]
        public async Task<IActionResult> RetreveCatalogByOrganizationName(string organizationName)
        {
            var organization = await context.organizationTable.FirstOrDefaultAsync((organization) => organization.Name == organizationName);
            var catalog = await context.catalogTable.FirstOrDefaultAsync((catalog) => catalog.OrganizationId == organization.Id);
            if (catalog == null)
            {
                //TODO: add logs
                return NoContent();
            }

            return Json(catalog);
        }

        #endregion

    }
}
