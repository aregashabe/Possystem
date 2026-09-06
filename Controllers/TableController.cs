using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/tables")]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }

    // GET: api/tables
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tables = await _tableService.GetAllAsync();

        return Ok(tables);
    }

    // GET: api/tables/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var table = await _tableService.GetByIdAsync(id);

        if (table == null)
        {
            return NotFound(new
            {
                message = "Table not found."
            });
        }

        return Ok(table);
    }

    // POST: api/tables
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TableDto dto)
    {
        var table = await _tableService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = table.Id },
            table
        );
    }

    // PUT: api/tables/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] TableDto dto)
    {
        var updated = await _tableService.UpdateAsync(id, dto);

        if (!updated)
        {
            return NotFound(new
            {
                message = "Table not found."
            });
        }

        return Ok(new
        {
            message = "Table updated successfully."
        });
    }

    // DELETE: api/tables/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _tableService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound(new
            {
                message = "Table not found."
            });
        }

        return Ok(new
        {
            message = "Table deleted successfully."
        });
    }
}