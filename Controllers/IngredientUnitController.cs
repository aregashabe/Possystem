using Microsoft.AspNetCore.Mvc;
using POSsystem.Entities;
using POSsystem.Services;
using POSsystem.DTOs;
namespace POSsystem.Controllers;
[ApiController]
[Route("api/ingunit")]
public class IngredientUnitController : ControllerBase
{
    private readonly IIngredientUnitService _ingredientUnitService;

    public IngredientUnitController(IIngredientUnitService ingredientUnitService)
    {
        _ingredientUnitService = ingredientUnitService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllIngredientUnits()
    {
        var ingredientUnits = await _ingredientUnitService.GetAllIngredientUnitsAsync();
        return Ok(ingredientUnits);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredientUnitById(int id)
    {
        try
        {
            var ingredientUnit = await _ingredientUnitService.GetIngredientUnitByIdAsync(id);
            return Ok(ingredientUnit);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateIngredientUnit([FromBody] IngredientUnitDto ingredientUnitDto)
    {
        var createdIngredientUnit = await _ingredientUnitService.CreateIngredientUnitAsync(ingredientUnitDto);
        return CreatedAtAction(nameof(GetIngredientUnitById), new { id = createdIngredientUnit.UnitName }, createdIngredientUnit);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIngredientUnit(int id, [FromBody] IngredientUnitDto ingredientUnitDto)
    {
        try
        {
            var updatedIngredientUnit = await _ingredientUnitService.UpdateIngredientUnitAsync(id, ingredientUnitDto);
            return Ok(updatedIngredientUnit);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredientUnit(int id)
    {
        var deleted = await _ingredientUnitService.DeleteIngredientUnitAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    
}