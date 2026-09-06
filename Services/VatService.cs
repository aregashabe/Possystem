using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public class VatService : IVatService
{
    private readonly POSDbContext _context;

    public VatService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vat>> GetAllVatsAsync()
    {
        return await _context.Vats.ToListAsync();
    }

    public async Task<Vat?> GetVatByIdAsync(int id)
    {
        return await _context.Vats.FindAsync(id);
    }

    public async Task<Vat> CreateVatAsync(VatDto vatDto)
    {
        var vat = new Vat
        {
            VatName = vatDto.VatName,
            Percentage = vatDto.Percentage
        };

        _context.Vats.Add(vat);

        await _context.SaveChangesAsync();

        return vat;
    }

    public async Task<Vat?> UpdateVatAsync(int id, VatDto vatDto)
    {
        var vat = await _context.Vats.FindAsync(id);

        if (vat == null)
        {
            return null;
        }

        vat.VatName = vatDto.VatName;
        vat.Percentage = vatDto.Percentage;

        await _context.SaveChangesAsync();

        return vat;
    }

    public async Task<bool> DeleteVatAsync(int id)
    {
        var vat = await _context.Vats.FindAsync(id);

        if (vat == null)
        {
            return false;
        }

        _context.Vats.Remove(vat);

        await _context.SaveChangesAsync();

        return true;
    }
}