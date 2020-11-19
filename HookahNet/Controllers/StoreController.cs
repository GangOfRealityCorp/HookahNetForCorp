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
using HookahNet.Models.Products;

namespace HookahNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class StoreController : Controller
    {
        private readonly StoreContext context;
        public StoreController(StoreContext context)
        {
            this.context = context;
        }



        /// <summary>
        /// Add product to Shopping Cart ----- .Net Version is 5.0 ------
        /// </summary>
        /// <param name="shoppingCartOwner"></param>
        /// <param name="productSku"></param>
        /// <param name="amount"></param>
        /// <returns>Status code</returns>
        [HttpPost("AddProductToShoppingCart")]
        public async Task<IActionResult> AddProductToShoppingCart(string shoppingCartOwner, string productSku, int amount)
        {

            var user = await context.guestUserTable.FirstOrDefaultAsync((el) => el.Email == shoppingCartOwner);
            if (user == null)
            {
                Log.Warning("Attempt to retrieve non-existent user.");
                return StatusCode((int)HttpStatusCode.NoContent, $"User with Email '{shoppingCartOwner}' not found.");
            }

            var product = await context.productTable.FirstOrDefaultAsync((el) => el.SKU == productSku);
            if (product == null)
            {
                Log.Warning("Attempt to retrieve non-existent product.");
                return StatusCode((int)HttpStatusCode.NoContent, $"Product with SKU '{productSku}' not found.");
            }

            await AddToShoppingCart(user, product, amount);

            Log.Information($"Product '{product.SKU}' has been added to ShoppingCart for user '{user.Email}'.");
            return Ok($"Product '{product.SKU}' has been added to ShoppingCart.");
        }

        private async Task AddToShoppingCart(GuestUser guestUser, Product product, int amount)
        {
            var shoppingCartMapping = await context.shoppingCartMappingTable.FirstOrDefaultAsync((el) => el.GuestUser == guestUser);

            if (shoppingCartMapping == null)
            {
                var SC = new ShoppingCart();

                shoppingCartMapping = new ShoppingCartMapping(guestUser, SC);
                await context.shoppingCartMappingTable.AddAsync(shoppingCartMapping);
                await context.SaveChangesAsync();
            }

            var shoppingCartItem = await context.shoppingCartItemTable.FirstOrDefaultAsync(el => el.Product.Id == product.Id);

            var shoppingCart = shoppingCartMapping.ShoppingCart;
            bool isModified;
            shoppingCart.AddItemToList(product, amount, out isModified);

            context.Entry(shoppingCart).State = EntityState.Modified;
            if(isModified)
            {
                context.Entry(shoppingCartItem).State = EntityState.Deleted;
            }

            await context.SaveChangesAsync();
        }

        private void ConvertToOrder(ShoppingCart shoppingCart, IGuestUser customer)
        {
            IOrder order = new Order(shoppingCart, customer);
        }
    }
}
