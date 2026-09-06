using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public class FoodmenuService : IFoodmenuService
{
    private readonly POSDbContext _context;

    public FoodmenuService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FoodmenuDto>> GetAllAsync()
    {
        return await _context.Foodmenus
            .Select(f => new FoodmenuDto
            {
                Id = f.Id,
                FoodmenuName = f.FoodmenuName,
                CatagoryId = f.CatagoryId,
                FoodingredientId = f.FoodingredientId,
                SalesPrice = f.SalesPrice,
                VatId = f.VatId,
                Description = f.Description,
                VegItem = f.VegItem,
                Beverage = f.Beverage,
                Bar = f.Bar,
                Photo = f.Photo
            })
            .ToListAsync();
    }

    public async Task<FoodmenuDto?> GetByIdAsync(int id)
    {
        return await _context.Foodmenus
            .Where(f => f.Id == id)
            .Select(f => new FoodmenuDto
            {
                Id = f.Id,
                FoodmenuName = f.FoodmenuName,
                CatagoryId = f.CatagoryId,
                FoodingredientId = f.FoodingredientId,
                SalesPrice = f.SalesPrice,
                VatId = f.VatId,
                Description = f.Description,
                VegItem = f.VegItem,
                Beverage = f.Beverage,
                Bar = f.Bar,
                Photo = f.Photo
            })
            .FirstOrDefaultAsync();
    }

    public async Task<FoodmenuDto> CreateAsync(FoodmenuDto dto)
    {
        var foodmenu = new Foodmenu
        {
            FoodmenuName = dto.FoodmenuName,
            CatagoryId = dto.CatagoryId,
            FoodingredientId = dto.FoodingredientId,
            SalesPrice = dto.SalesPrice,
            VatId = dto.VatId,
            Description = dto.Description,
            VegItem = dto.VegItem,
            Beverage = dto.Beverage,
            Bar = dto.Bar,
            Photo = dto.Photo
        };

        _context.Foodmenus.Add(foodmenu);

        await _context.SaveChangesAsync();

        dto.Id = foodmenu.Id;

        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var foodmenu = await _context.Foodmenus.FindAsync(id);

        if (foodmenu == null)
            return false;

        _context.Foodmenus.Remove(foodmenu);

        await _context.SaveChangesAsync();

        return true;
    }
}