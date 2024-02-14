using IdentityServerSample.Api1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerSample.Api2.Controllers;

[ApiController]
[Route("/api2/product")]
[Authorize]
public class Api1Controller : ControllerBase
{
    public List<Product> _products;

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
    [Authorize("Read")]
    public IActionResult GetProduct()
    {
        return Ok(_products);
        
    }
    [HttpPost]
    [Authorize("Write")]

    public IActionResult GetProduct([FromBody]Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        _products.Add(product);
        return StatusCode(201);

    }
}