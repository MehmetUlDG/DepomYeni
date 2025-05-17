using DataAccess.Businness;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Entities;

namespace ProductApp.WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
     public class ProductController: ControllerBase{
        private readonly IProductService _service;
        public ProductController(IProductService service)=> _service = service;

        [HttpGet]
        public IActionResult GetAll()=>Ok(_service.GetAll());
     
     [HttpGet("{id}")]
     public IActionResult GetById(int id){
        var product = _service.GetById(id);
        if(product == null) return NotFound();
        return Ok(product);
     }
        [HttpPost]
        public IActionResult Add(Product product){
            _service.Add(product);
            return CreatedAtAction(nameof(GetById),new { id=product.ProductId}, product);
        }
}
}