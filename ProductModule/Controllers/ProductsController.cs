using Microsoft.AspNetCore.Mvc;
using ProductModule.IServices;
using ProductModule.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductsController(IProductServices services)
        {
            _services = services;
        }
        // GET: api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            string result = await _services.AddNewProduct(product);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get(Product product)
        {
            return Ok(await _services.GetAllProducts(product));
        }



        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _services.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpGet("{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var result =await _services.GetProductByCategory(category);
            if(result != null)
                return Ok(result);
            else return NotFound();

        }
        [HttpGet("{brand}")]
      
        public async Task<IActionResult> GetByBrand(string brand)
        {
            var result = await _services.GetProductByBrand(brand);
            if (result != null)
                return Ok(result);
            else
                return NotFound();

        }

        // POST api/<ProductsController>
        [HttpGet("{name},{price},{category},{brand}")]
        public async Task<IActionResult> Get(string name,double price,string category,string brand)
        {
            var result=await _services.GetProductBySearch(name, price, category, brand);    
            if(result != null)
                return Ok(result);
            else 
                return NotFound();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product updateProduct)
        {
            string result = await _services.UpdateProduct(updateProduct);
            if(result== "Product Updated")
                return Ok(result); 
            else
                return NotFound();  

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string result= await _services.DeleteProduct(id);
            if(result== "Product not found")
                return Ok(result);
            return BadRequest();
        }

    
    
    }

        
 }
