using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public interface IDeliveryService
{
    Task<List<Delivery>> GetAllAsync();

    Task<Delivery?> GetByIdAsync(int id);

    Task<Delivery> CreateAsync(DeliveryDto dto);

    Task<bool> UpdateAsync(int id, DeliveryDto dto);

    Task<bool> DeleteAsync(int id);
}