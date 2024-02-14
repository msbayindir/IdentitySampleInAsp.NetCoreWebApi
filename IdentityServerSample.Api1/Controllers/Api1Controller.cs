using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerSample.Api1.Controllers;

[ApiController]
[Route("/api1/product")]
[Authorize]
public class Api1Controller : ControllerBase
{ 
    public static List<Product> _products;

    public Api1Controller()
    {
        _products = new List<Product>()
        {
            new Product(1, "Kulaklık"),
            new Product(2, "Telefon"),
            new Product(3, "Korkurt")
        };
    }

    [HttpGet]
    public IActionResult GetProduct()
    {
        return Ok(_products);
        
    }
    [HttpPost]
    public IActionResult GetProduct([FromBody]Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        _products.Add(product);
        return StatusCode(201);

    }
}