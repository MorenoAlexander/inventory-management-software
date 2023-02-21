using Inventory_Management_Software.Core.Entities;
using Inventory_Management_Software.Core.Interfaces;
using Inventory_Management_Software.DTOS;
using Inventory_Management_Software.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management_Software.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{
   private readonly ILogger<VendorController> _logger;
   private readonly IEfRepository<Vendor> _vendorRepository;

   public VendorController(ILogger<VendorController> logger, IEfRepository<Vendor> vendorRepository)
   {
      _logger = logger;
      _vendorRepository = vendorRepository;
   }

   [HttpGet]
   public async Task<IActionResult> Get()
   {
      try
      {
         return Ok(await _vendorRepository.ListAllAsync());
      }
      catch (Exception e)
      {
         _logger.LogError(e, "An error occurred while fetching vendors");
         throw;
      }
   }

   [HttpPost]
   public async Task<ActionResult<Vendor>> CreateNewVendor([FromBody] NewVendorDto vendor)
   {
      try
      {
         if (String.IsNullOrEmpty(vendor.Name))
         {
            return BadRequest();
         }

         var newVendor = new Vendor();
         newVendor.UpdateFromDto(vendor);
         
         await _vendorRepository.AddAsync(newVendor);
         return Ok(newVendor);
      }
      catch (Exception e)
      {
         _logger.LogError(e, "An error occurred while creating a new vendor");
         throw;
      }
   }
}