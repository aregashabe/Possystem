using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/deliveries")]
public class DeliveriesController : ControllerBase
{
    private readonly IDeliveryService _deliveryService;

    public DeliveriesController(IDeliveryService deliveryService)
    {
        _deliveryService = deliveryService;
    }

    // GET: api/deliveries
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var deliveries = await _deliveryService.GetAllAsync();

        return Ok(deliveries);
    }

    // GET: api/deliveries/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var delivery = await _deliveryService.GetByIdAsync(id);

        if (delivery == null)
        {
            return NotFound(new
            {
                message = "Delivery not found."
            });
        }

        return Ok(delivery);
    }

    // POST: api/deliveries
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DeliveryDto dto)
    {
        var delivery = await _deliveryService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = delivery.Id },
            delivery
        );
    }

    // PUT: api/deliveries/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] DeliveryDto dto)
    {
        var updated = await _deliveryService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound(new
            {
                message = "Delivery not found."
            });
        }

        return Ok(new
        {
            message = "Delivery updated successfully."
        });
    }

    // DELETE: api/deliveries/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _deliveryService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Delivery not found."
            });
        }

        return Ok(new
        {
            message = "Delivery deleted successfully."
        });
    }
}