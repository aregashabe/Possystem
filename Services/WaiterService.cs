using Microsoft.EntityFrameworkCore;
using POSsystem.DTOs;
using POSsystem.Entities;
using POSsystem.Data;

namespace POSsystem.Services;

public class WaiterService : IWaiterService
{
    private readonly POSDbContext _context;

    public WaiterService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<List<Waiter>> GetAllAsync()
    {
        return await _context.Waiters
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Waiter?> GetByIdAsync(int id)
    {
        return await _context.Waiters
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Waiter> CreateAsync(WaiterDto dto)
    {
        var waiter = new Waiter
        {
            WaiterName = dto.WaiterName,
            Designation = dto.Designation,
            Mobile = dto.Mobile,
            Description = dto.Description
        };

        _context.Waiters.Add(waiter);

        await _context.SaveChangesAsync();

        return waiter;
    }

    public async Task<bool> UpdateAsync(int id, WaiterDto dto)
    {
        var waiter = await _context.Waiters.FindAsync(id);

        if (waiter == null)
        {
            return false;
        }

        waiter.WaiterName = dto.WaiterName;
        waiter.Designation = dto.Designation;
        waiter.Mobile = dto.Mobile;
        waiter.Description = dto.Description;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var waiter = await _context.Waiters.FindAsync(id);

        if (waiter == null)
        {
            return false;
        }

        _context.Waiters.Remove(waiter);

        await _context.SaveChangesAsync();

        return true;
    }
}