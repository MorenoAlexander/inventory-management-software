using Inventory_Management_Software.Core.Entities;
using Inventory_Management_Software.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_Software.Controllers;


[Route("api/[controller]")]
[Authorize]
[ApiController]
public class ProductController : ControllerBase
{
    private ILogger<Product> _logger;
    private readonly GenericIMSContext _genericImsContext;
    


    public ProductController(ILogger<Product> logger, GenericIMSContext genericImsContext)
    {
        _logger = logger;
        _genericImsContext = genericImsContext;
    }

    public ActionResult<List<Product>> Get()
    {
        try
        {
            var products = _genericImsContext.Products.ToList();

            return Ok(products);

        }
        catch (Exception e)
        {
            _logger.LogError(e, $"An error occurred while fetching products");
            throw;
        }
    }
    
    
}