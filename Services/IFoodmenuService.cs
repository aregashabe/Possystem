using POSsystem.DTOs;

namespace POSsystem.Services;

public interface IFoodmenuService
{
    Task<IEnumerable<FoodmenuDto>> GetAllAsync();

    Task<FoodmenuDto?> GetByIdAsync(int id);

    Task<FoodmenuDto> CreateAsync(FoodmenuDto dto);

    Task<bool> DeleteAsync(int id);
}