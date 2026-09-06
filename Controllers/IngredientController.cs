using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    // GET: api/Ingredient
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IngredientDto>>> GetAll()
    {
        var ingredients = await _ingredientService.GetAllAsync();

        return Ok(ingredients);
    }

    // GET: api/Ingredient/1
    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientDto>> GetById(int id)
    {
        var ingredient = await _ingredientService.GetByIdAsync(id);

        if (ingredient == null)
            return NotFound();

        return Ok(ingredient);
    }

    // POST: api/Ingredient
    [HttpPost]
    public async Task<ActionResult<IngredientDto>> Create(
        IngredientDto ingredientDto)
    {
        var ingredient =
            await _ingredientService.CreateAsync(ingredientDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = ingredient.Id },
            ingredient
        );
    }

    // PUT: api/Ingredient/1
    [HttpPut("{id}")]
    public async Task<ActionResult<IngredientDto>> Update(
        int id,
        IngredientDto ingredientDto)
    {
        var updated =
            await _ingredientService.UpdateAsync(id, ingredientDto);

        if (!updated)
            return NotFound();

        ingredientDto.Id = id;

        return Ok(ingredientDto);
    }

    // DELETE: api/Ingredient/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted =
            await _ingredientService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}