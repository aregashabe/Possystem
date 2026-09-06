using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public class PaymentService : IPaymentService
{
    private readonly POSDbContext _context;

    public PaymentService(POSDbContext context)
    {
        _context = context;
    }

    // GET ALL
    public async Task<IEnumerable<PaymentDto>> GetAllAsync()
    {
        return await _context.Payments
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                BillNumber = p.BillNumber,
                OrderId = p.OrderId,
                Total = p.Total,
                GrandTotal = p.GrandTotal,
                VatAmount = p.VatAmount,
                PaymentType = p.PaymentType,
                AddedById = p.AddedById,
                Date = p.Date,
                Status = p.Status
            })
            .ToListAsync();
    }

    // GET BY ID
    public async Task<PaymentDto?> GetByIdAsync(int id)
    {
        return await _context.Payments
            .Where(p => p.Id == id)
            .Select(p => new PaymentDto
            {
                Id = p.Id,
                BillNumber = p.BillNumber,
                OrderId = p.OrderId,
                Total = p.Total,
                GrandTotal = p.GrandTotal,
                VatAmount = p.VatAmount,
                PaymentType = p.PaymentType,
                AddedById = p.AddedById,
                Date = p.Date,
                Status = p.Status
            })
            .FirstOrDefaultAsync();
    }

    // CREATE
    public async Task<PaymentDto> CreateAsync(PaymentDto dto)
    {
        // Check order
        var order = await _context.PosOrders
            .FirstOrDefaultAsync(o => o.Id == dto.OrderId);

        if (order == null)
            throw new Exception("Order not found.");

        // Check user
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == dto.AddedById);

        if (user == null)
            throw new Exception("User not found.");

        var payment = new Payment
        {
            BillNumber = dto.BillNumber,
            OrderId = dto.OrderId,
            Total = dto.Total,
            GrandTotal = dto.GrandTotal,
            VatAmount = dto.VatAmount,
            PaymentType = dto.PaymentType,
            AddedById = dto.AddedById,
            Date = dto.Date,
            Status = dto.Status
        };

        _context.Payments.Add(payment);

        await _context.SaveChangesAsync();

        dto.Id = payment.Id;

        return dto;
    }

    // UPDATE
    public async Task<bool> UpdateAsync(int id, PaymentDto dto)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
            return false;

        payment.BillNumber = dto.BillNumber;
        payment.OrderId = dto.OrderId;
        payment.Total = dto.Total;
        payment.GrandTotal = dto.GrandTotal;
        payment.VatAmount = dto.VatAmount;
        payment.PaymentType = dto.PaymentType;
        payment.AddedById = dto.AddedById;
        payment.Date = dto.Date;
        payment.Status = dto.Status;

        await _context.SaveChangesAsync();

        return true;
    }

    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
            return false;

        _context.Payments.Remove(payment);

        await _context.SaveChangesAsync();

        return true;
    }
}