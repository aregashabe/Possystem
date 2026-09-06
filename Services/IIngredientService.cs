using POSsystem.DTOs;

namespace POSsystem.Services;

public interface IIngredientService
{
    Task<List<IngredientDto>> GetAllAsync();

    Task<IngredientDto?> GetByIdAsync(int id);

    Task<IngredientDto> CreateAsync(IngredientDto dto);

    Task<bool> UpdateAsync(int id, IngredientDto dto);

    Task<bool> DeleteAsync(int id);
}