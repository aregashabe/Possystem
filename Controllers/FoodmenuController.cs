using Microsoft.AspNetCore.Mvc;
using POSsystem.DTOs;
using POSsystem.Services;

namespace POSsystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodmenuController : ControllerBase
{
    private readonly IFoodmenuService _foodmenuService;

    public FoodmenuController(IFoodmenuService foodmenuService)
    {
        _foodmenuService = foodmenuService;
    }

    // GET: api/foodmenu
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodmenuDto>>> GetFoodmenus()
    {
        var foodmenus = await _foodmenuService.GetAllAsync();

        return Ok(foodmenus);
    }

    // GET: api/foodmenu/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FoodmenuDto>> GetFoodmenu(int id)
    {
        var foodmenu = await _foodmenuService.GetByIdAsync(id);

        if (foodmenu == null)
        {
            return NotFound();
        }

        return Ok(foodmenu);
    }

    // POST: api/foodmenu
    [HttpPost]
    public async Task<ActionResult<FoodmenuDto>> CreateFoodmenu(
        FoodmenuDto dto)
    {
        var foodmenu = await _foodmenuService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetFoodmenu),
            new { id = foodmenu.Id },
            foodmenu
        );
    }

    // DELETE: api/foodmenu/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoodmenu(int id)
    {
        var deleted = await _foodmenuService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}