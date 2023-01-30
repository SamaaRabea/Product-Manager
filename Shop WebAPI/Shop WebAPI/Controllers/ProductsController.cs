using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DAL;
using Shope.BL;
using Shope.BL.Dto;

namespace Shop_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _Manager;

        public ProductsController(IProductManager context)
        {
            _Manager = context;
        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public IActionResult GetById(string code)
        {
            ProductDto product = _Manager.GetById(code);
            if (product == null)
            {
                return new NotFoundResult();
            }
            return Ok(product);
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetAll()
        {
            List<ProductDto> products = _Manager.GetAll();
            if (products.Count > 0 && products[0] != null)
            {
                return products;
            }
            else
            {
                return new List<ProductDto>();
            }
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data provided." });
            }
            _Manager.Add(product);
            return Ok(new { message = "Product added successfully." });
        }
       
        [HttpPut]
        public IActionResult Update([FromBody] ProductDto productDto)
        {
            try
            {
                _Manager.Update(productDto);
                return Ok("Product and its versions have been updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{code}")]
        public ActionResult Delete(string code)
        {
            //_Manager.Product_Version.RemoveRange(_context.Product_Version.Where(x => x.Code == product.Code));
            //if (product != null)
            //{
                _Manager.Delete(code);
            //}
            //else
            //{
            //    return BadRequest();
            //}

            return Ok();
        }



    }
}
