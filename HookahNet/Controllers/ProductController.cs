using HookahNet.Controllers.DBContexts;
using HookahNet.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HookahNet.Controllers.ControllerDTO;
using HookahNet.Models;

namespace HookahNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly StoreContext context;
        public ProductController(StoreContext context)
        {
            this.context = context;
        }

        #region FactoryMethods

        private Product CreateTobaccoProduct(ProductDTO productDTO)
        {
            return new TobaccoProduct(productDTO);
        }

        private Product CreateHookahProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        private Product CreateFlaskFluidProduct(ProductDTO productDTO)
        {
            return new FlaskFluidProduct(productDTO);
        }

        #endregion

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (productDTO.SKU == null)
                    return Conflict($"SKU is required");

                var product = await context.productTable.FirstOrDefaultAsync((prod) => prod.SKU == productDTO.SKU);
                if (product == null)
                {
                    context.productTable.Add(productDTO.ProductType switch
                    {
                        ProductTypes.Tobacco => CreateTobaccoProduct(productDTO),
                        ProductTypes.Hookah => CreateHookahProduct(productDTO),
                        ProductTypes.FlaskFluid => CreateFlaskFluidProduct(productDTO),
                        _ => throw new Exception("Product Type is required."),
                    });
                    await context.SaveChangesAsync();

                    return Ok($"Product with SKU '{productDTO.SKU}' has been created");
                }
                return Conflict($"Product with SKU '{productDTO.SKU}' already exist");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }

        }
    }
}
