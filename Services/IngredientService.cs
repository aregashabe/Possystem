using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public class IngredientService : IIngredientService
{
    private readonly POSDbContext _context;

    public IngredientService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<List<IngredientDto>> GetAllAsync()
    {
        return await _context.Ingredients
            .Select(i => new IngredientDto
            {
                Id = i.Id,
                Name = i.Name,
                CategoryId = i.CategoryId,
                IngredientUnitId = i.IngredientUnitId,
                AlertQuantity = i.AlertQuantity,
                Description = i.Description
            })
            .ToListAsync();
    }

    public async Task<IngredientDto?> GetByIdAsync(int id)
    {
        return await _context.Ingredients
            .Where(i => i.Id == id)
            .Select(i => new IngredientDto
            {
                Id = i.Id,
                Name = i.Name,
                CategoryId = i.CategoryId,
                IngredientUnitId = i.IngredientUnitId,
                AlertQuantity = i.AlertQuantity,
                Description = i.Description
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IngredientDto> CreateAsync(IngredientDto dto)
    {
        var ingredient = new Ingredient
        {
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            IngredientUnitId = dto.IngredientUnitId,
            AlertQuantity = dto.AlertQuantity,
            Description = dto.Description
        };

        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();

        dto.Id = ingredient.Id;

        return dto;
    }

    public async Task<bool> UpdateAsync(int id, IngredientDto dto)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);

        if (ingredient == null)
            return false;

        ingredient.Name = dto.Name;
        ingredient.CategoryId = dto.CategoryId;
        ingredient.IngredientUnitId = dto.IngredientUnitId;
        ingredient.AlertQuantity = dto.AlertQuantity;
        ingredient.Description = dto.Description;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);

        if (ingredient == null)
            return false;

        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();

        return true;
    }
}