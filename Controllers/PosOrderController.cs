using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/posorders")]
public class PosOrderController : ControllerBase
{
    private readonly IPosOrderService _posOrderService;

    public PosOrderController(IPosOrderService posOrderService)
    {
        _posOrderService = posOrderService;
    }

    // GET: api/posorders
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _posOrderService.GetAllAsync();

        return Ok(orders);
    }

    // GET: api/posorders/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _posOrderService.GetByIdAsync(id);

        if (order == null)
        {
            return NotFound(new
            {
                message = "Order not found."
            });
        }

        return Ok(order);
    }

    // POST: api/posorders
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PosOrderDto dto)
    {
        if (dto.Items == null || !dto.Items.Any())
        {
            return BadRequest(new
            {
                message = "Order must contain at least one item."
            });
        }

        var order = await _posOrderService.CreateAsync(dto);

        return Ok(order);
    }

    // DELETE: api/posorders/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _posOrderService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Order not found."
            });
        }

        return Ok(new
        {
            message = "Order deleted successfully."
        });
    }
}