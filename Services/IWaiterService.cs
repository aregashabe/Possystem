using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public interface IWaiterService
{
    Task<List<Waiter>> GetAllAsync();

    Task<Waiter?> GetByIdAsync(int id);

    Task<Waiter> CreateAsync(WaiterDto dto);

    Task<bool> UpdateAsync(int id, WaiterDto dto);

    Task<bool> DeleteAsync(int id);
}