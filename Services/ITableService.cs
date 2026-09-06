using POSsystem.DTOs;

namespace POSsystem.Services;

public interface ITableService
{
    Task<IEnumerable<TableDto>> GetAllAsync();

    Task<TableDto?> GetByIdAsync(int id);

    Task<TableDto> CreateAsync(TableDto dto);

    Task<bool> UpdateAsync(int id, TableDto dto);

    Task<bool> DeleteAsync(int id);
}