using Microsoft.EntityFrameworkCore;
using POSsystem.DTOs;
using POSsystem.Entities;
using POSsystem.Data;

namespace POSsystem.Services;

public class DeliveryService : IDeliveryService
{
    private readonly POSDbContext _context;

    public DeliveryService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<List<Delivery>> GetAllAsync()
    {
        return await _context.Deliveries
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Delivery?> GetByIdAsync(int id)
    {
        return await _context.Deliveries
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Delivery> CreateAsync(DeliveryDto dto)
    {
        var delivery = new Delivery
        {
            DeliveryName = dto.DeliveryName,
            DeliveryMobile = dto.DeliveryMobile
        };

        _context.Deliveries.Add(delivery);

        await _context.SaveChangesAsync();

        return delivery;
    }

    public async Task<bool> UpdateAsync(int id, DeliveryDto dto)
    {
        var delivery = await _context.Deliveries.FindAsync(id);

        if (delivery == null)
        {
            return false;
        }

        delivery.DeliveryName = dto.DeliveryName;
        delivery.DeliveryMobile = dto.DeliveryMobile;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delivery = await _context.Deliveries.FindAsync(id);

        if (delivery == null)
        {
            return false;
        }

        _context.Deliveries.Remove(delivery);

        await _context.SaveChangesAsync();

        return true;
    }
}