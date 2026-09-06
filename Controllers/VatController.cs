using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VatController : ControllerBase
{
    private readonly IVatService _vatService;

    public VatController(IVatService vatService)
    {
        _vatService = vatService;
    }

    // GET: api/Vat
    [HttpGet]
    public async Task<IActionResult> GetAllVats()
    {
        var vats = await _vatService.GetAllVatsAsync();

        return Ok(vats);
    }

    // GET: api/Vat/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVatById(int id)
    {
        var vat = await _vatService.GetVatByIdAsync(id);

        if (vat == null)
        {
            return NotFound(new
            {
                message = "VAT not found"
            });
        }

        return Ok(vat);
    }

    // POST: api/Vat
    [HttpPost]
    public async Task<IActionResult> CreateVat(VatDto vatDto)
    {
        var vat = await _vatService.CreateVatAsync(vatDto);

        return CreatedAtAction(
            nameof(GetVatById),
            new { id = vat.Id },
            vat
        );
    }

    // PUT: api/Vat/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVat(int id, VatDto vatDto)
    {
        var vat = await _vatService.UpdateVatAsync(id, vatDto);

        if (vat == null)
        {
            return NotFound(new
            {
                message = "VAT not found"
            });
        }

        return Ok(vat);
    }

    // DELETE: api/Vat/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVat(int id)
    {
        var deleted = await _vatService.DeleteVatAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "VAT not found"
            });
        }

        return Ok(new
        {
            message = "VAT deleted successfully"
        });
    }
}