using POSsystem.DTOs;

namespace POSsystem.Services;

public interface IPosOrderService
{
    Task<IEnumerable<PosOrderDto>> GetAllAsync();

    Task<PosOrderDto?> GetByIdAsync(int id);

    Task<PosOrderDto> CreateAsync(PosOrderDto dto);

    Task<bool> DeleteAsync(int id);
}