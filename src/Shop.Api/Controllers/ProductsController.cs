using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.DTO.Responses;
using Shop.Core.Entities;
using Shop.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Productos>> ListAsync()
        {
            var result = await _productService.FindAllAsync();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Productos product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.SaveAsync(product);

            if (!result.IsSuccess())
            {
                return BadRequest(result as ErrorCRUDResponse);
            }

            return CreatedAtAction("Get", new { id = (result as SuccessCRUDResponse).Data.Codigo }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Productos product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.UpdateAsync(id, product);

            if (!result.IsSuccess())
            {
                var errorResponse = result as ErrorCRUDResponse;
                if (errorResponse.status == 404)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(errorResponse);
                }
            }

            return Ok((result as SuccessCRUDResponse).Data);
        }

        [HttpGet("{id}")]
        public ActionResult<Productos> Get(int id)
        {
            var result = _productService.FindById(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.IsSuccess())
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}