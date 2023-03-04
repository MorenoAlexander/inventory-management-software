using Inventory_Management_Software.Core.Entities;
using Inventory_Management_Software.Core.Interfaces;
using Inventory_Management_Software.DTOS;
using Inventory_Management_Software.Extensions;
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
    private readonly ILogger<Product> _logger;
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

    [HttpPut("{id}")]
    public ActionResult Put(Guid id, [FromBody] NewProductDto product)
    {
        try
        {
            var productToUpdate = _productRepository.GetById(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }


            productToUpdate.UpdateFromDto(product);
            _productRepository.Update(productToUpdate);

            return NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to update product {Guid}", id);
            throw;
        }
        
    }
    
    
    
}