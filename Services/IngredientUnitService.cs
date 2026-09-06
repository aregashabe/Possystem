using POSsystem.DTOs;
using POSsystem.Data;
using POSsystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace POSsystem.Services;

public class IngredientUnitService : IIngredientUnitService
{
    private readonly POSDbContext _context;
    private readonly ILogger<IngredientUnitService> _logger;

    public IngredientUnitService(
        POSDbContext context,
        ILogger<IngredientUnitService> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET ALL
    public async Task<List<IngredientUnitDto>> GetAllIngredientUnitsAsync()
    {
        var ingredientUnits =
            await _context.IngredientUnits.ToListAsync();

        return ingredientUnits.Select(iu => new IngredientUnitDto
        {
            Id = iu.Id,
            UnitName = iu.UnitName,
            Description = iu.Description
        }).ToList();
    }

    // GET BY ID
    public async Task<IngredientUnitDto> GetIngredientUnitByIdAsync(int id)
    {
        var ingredientUnit =
            await _context.IngredientUnits.FindAsync(id);

        if (ingredientUnit == null)
        {
            throw new KeyNotFoundException(
                $"Ingredient unit with ID {id} not found."
            );
        }

        return new IngredientUnitDto
        {
            Id = ingredientUnit.Id,
            UnitName = ingredientUnit.UnitName,
            Description = ingredientUnit.Description
        };
    }

    // CREATE
    public async Task<IngredientUnitDto> CreateIngredientUnitAsync(
        IngredientUnitDto ingredientUnitDto)
    {
        var ingredientUnit = new IngredientUnit
        {
            UnitName = ingredientUnitDto.UnitName,
            Description = ingredientUnitDto.Description
        };

        _context.IngredientUnits.Add(ingredientUnit);

        await _context.SaveChangesAsync();

        return new IngredientUnitDto
        {
            Id = ingredientUnit.Id,
            UnitName = ingredientUnit.UnitName,
            Description = ingredientUnit.Description
        };
    }

    // UPDATE
    public async Task<IngredientUnitDto> UpdateIngredientUnitAsync(
        int id,
        IngredientUnitDto ingredientUnitDto)
    {
        var existingIngredientUnit =
            await _context.IngredientUnits.FindAsync(id);

        if (existingIngredientUnit == null)
        {
            throw new KeyNotFoundException(
                $"Ingredient unit with ID {id} not found."
            );
        }

        existingIngredientUnit.UnitName =
            ingredientUnitDto.UnitName;

        existingIngredientUnit.Description =
            ingredientUnitDto.Description;

        await _context.SaveChangesAsync();

        return new IngredientUnitDto
        {
            Id = existingIngredientUnit.Id,
            UnitName = existingIngredientUnit.UnitName,
            Description = existingIngredientUnit.Description
        };
    }

    // DELETE
    public async Task<bool> DeleteIngredientUnitAsync(int id)
    {
        var ingredientUnit =
            await _context.IngredientUnits.FindAsync(id);

        if (ingredientUnit == null)
        {
            return false;
        }

        _context.IngredientUnits.Remove(ingredientUnit);

        await _context.SaveChangesAsync();

        return true;
    }
}