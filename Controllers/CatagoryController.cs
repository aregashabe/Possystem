using Microsoft.AspNetCore.Mvc;
using POSsystem.Entities;
using POSsystem.Services;
using POSsystem.DTOs;
namespace POSsystem.Controllers;
[ApiController]
[Route("/api/category")]
public class CatagoryController:ControllerBase
{
    private readonly ICatagoryService _catagoryService;

    public CatagoryController(ICatagoryService catagoryService)
    {
        _catagoryService = catagoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _catagoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _catagoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
public async Task<IActionResult> CreateCategory([FromBody] CategoryDto category)
{
    var createdCategory = await _catagoryService.CreateCategoryAsync(category);

    return CreatedAtAction(nameof(GetCategoryById),
        new { id = createdCategory.Id },
        createdCategory);
}

   [HttpPut("{id}")]
public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
{
    var updatedCategory = await _catagoryService.UpdateCategoryAsync(id, categoryDto);

    if (updatedCategory == null)
    {
        return NotFound();
    }

    return Ok(updatedCategory);
}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var deleted = await _catagoryService.DeleteCategoryAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}