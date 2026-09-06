using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public class TableService : ITableService
{
    private readonly POSDbContext _context;

    public TableService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TableDto>> GetAllAsync()
    {
        return await _context.Tables
            .Select(t => new TableDto
            {
                Id = t.Id,
                TableName = t.TableName,
                Position = t.Position,
                SeatCapacity = t.SeatCapacity,
                Description = t.Description
            })
            .ToListAsync();
    }

    public async Task<TableDto?> GetByIdAsync(int id)
    {
        return await _context.Tables
            .Where(t => t.Id == id)
            .Select(t => new TableDto
            {
                Id = t.Id,
                TableName = t.TableName,
                Position = t.Position,
                SeatCapacity = t.SeatCapacity,
                Description = t.Description
            })
            .FirstOrDefaultAsync();
    }

    public async Task<TableDto> CreateAsync(TableDto dto)
    {
        var table = new Table
        {
            TableName = dto.TableName,
            Position = dto.Position,
            SeatCapacity = dto.SeatCapacity,
            Description = dto.Description
        };

        _context.Tables.Add(table);

        await _context.SaveChangesAsync();

        dto.Id = table.Id;

        return dto;
    }

    public async Task<bool> UpdateAsync(int id, TableDto dto)
    {
        var table = await _context.Tables
            .FirstOrDefaultAsync(t => t.Id == id);

        if (table == null)
            return false;

        table.TableName = dto.TableName;
        table.Position = dto.Position;
        table.SeatCapacity = dto.SeatCapacity;
        table.Description = dto.Description;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var table = await _context.Tables
            .FirstOrDefaultAsync(t => t.Id == id);

        if (table == null)
            return false;

        _context.Tables.Remove(table);

        await _context.SaveChangesAsync();

        return true;
    }
}