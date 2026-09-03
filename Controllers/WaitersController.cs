using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/waiters")]
public class WaitersController : ControllerBase
{
    private readonly IWaiterService _waiterService;

    public WaitersController(IWaiterService waiterService)
    {
        _waiterService = waiterService;
    }

    // GET: api/waiters
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var waiters = await _waiterService.GetAllAsync();

        return Ok(waiters);
    }

    // GET: api/waiters/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var waiter = await _waiterService.GetByIdAsync(id);

        if (waiter == null)
        {
            return NotFound(new
            {
                message = "Waiter not found."
            });
        }

        return Ok(waiter);
    }

    // POST: api/waiters
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WaiterDto dto)
    {
        var waiter = await _waiterService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = waiter.Id },
            waiter
        );
    }

    // PUT: api/waiters/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] WaiterDto dto)
    {
        var updated = await _waiterService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound(new
            {
                message = "Waiter not found."
            });
        }

        return Ok(new
        {
            message = "Waiter updated successfully."
        });
    }

    // DELETE: api/waiters/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _waiterService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Waiter not found."
            });
        }

        return Ok(new
        {
            message = "Waiter deleted successfully."
        });
    }
}