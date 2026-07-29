using POSsystem.Entities;
using POSsystem.DTOs;
namespace POSsystem.Services;
public interface ICatagoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> CreateCategoryAsync(CategoryDto categoryDto);
    Task<Category?> UpdateCategoryAsync(int id, CategoryDto categoryDto);
    Task<bool> DeleteCategoryAsync(int id);
}