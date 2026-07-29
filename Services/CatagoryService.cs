using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using POSsystem.Entities;
using POSsystem.DTOs;
namespace POSsystem.Services;
public class CatagoryService : ICatagoryService
{
    private readonly POSDbContext _context;

    public CatagoryService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = new Category
        {
            CategoryName = categoryDto.CategoryName,
            Description = categoryDto.Description
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var existingCategory = await _context.Categories.FindAsync(id);
        if (existingCategory == null)
        {
            return null;
        }

        existingCategory.CategoryName = categoryDto.CategoryName;
        existingCategory.Description = categoryDto.Description;

        await _context.SaveChangesAsync();
        return existingCategory;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}