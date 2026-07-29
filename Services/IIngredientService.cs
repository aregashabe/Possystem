using POSsystem.DTOs;
namespace POSsystem.Services;
public interface IIngredientUnitService
{
    Task<List<IngredientUnitDto>> GetAllIngredientUnitsAsync();
    Task<IngredientUnitDto> GetIngredientUnitByIdAsync(int id);
    Task<IngredientUnitDto> CreateIngredientUnitAsync(IngredientUnitDto ingredientUnitDto);
    Task<IngredientUnitDto> UpdateIngredientUnitAsync(int id, IngredientUnitDto ingredientUnitDto);
    Task<bool> DeleteIngredientUnitAsync(int id);
}