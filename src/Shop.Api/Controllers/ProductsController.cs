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
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Lista los productos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IEnumerable<Productos>> ListAsync()
        {
            var result = await _productService.FindAllAsync();
            return result;
        }

        /// <summary>
        /// Registra un producto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] Productos product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.SaveAsync(product);

            return StatusCode(result.status, result);
        }

        /// <summary>
        /// Actualiza un producto
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Obtiene un producto
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Productos> Get(int id)
        {
            var result = _productService.FindById(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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