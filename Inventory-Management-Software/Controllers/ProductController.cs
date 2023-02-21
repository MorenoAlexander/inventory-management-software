using Inventory_Management_Software.Core.Entities;
using Inventory_Management_Software.Core.Interfaces;
using Inventory_Management_Software.Infrastructure;
using Inventory_Management_Software.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_Software.Controllers;


[Route("api/[controller]")]
[Authorize]
[ApiController]
public class ProductController : ControllerBase
{
    private ILogger<Product> _logger;
    private readonly IEfRepository<Product> _productRepository;



    public ProductController(ILogger<Product> logger, GenericIMSContext genericImsContext, IEfRepository<Product> productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        try
        {
            var products = _productRepository.ListAll();

            return Ok(products);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while fetching products");
            throw;
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(Guid id)
    {
        try
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while fetching product");
            throw;
        }
    }
    
    
    
}