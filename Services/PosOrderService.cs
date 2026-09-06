using Microsoft.EntityFrameworkCore;
using POSsystem.Data;
using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public class PosOrderService : IPosOrderService
{
    private readonly POSDbContext _context;

    public PosOrderService(POSDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PosOrderDto>> GetAllAsync()
    {
        return await _context.PosOrders
            .Include(o => o.Items)
            .Select(o => new PosOrderDto
            {
                CustomerId = o.CustomerId,
                TableId = o.TableId,
                WaiterId = o.WaiterId,
                DeliveryId = o.DeliveryId,

                Options = o.Options,

                Total = o.Total,
                VatAmount = o.VatAmount,
                GrandTotal = o.GrandTotal,

                PaymentStatus = o.PaymentStatus,
                PaymentType = o.PaymentType,
                Hold = o.Hold,

                Items = o.Items.Select(i => new PosOrderItemDto
                {
                    FoodMenuId = i.FoodMenuId,
                    SalesPrice = i.SalesPrice,
                    Quantity = i.Quantity
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<PosOrderDto?> GetByIdAsync(int id)
    {
        return await _context.PosOrders
            .Include(o => o.Items)
            .Where(o => o.Id == id)
            .Select(o => new PosOrderDto
            {
                CustomerId = o.CustomerId,
                TableId = o.TableId,
                WaiterId = o.WaiterId,
                DeliveryId = o.DeliveryId,

                Options = o.Options,

                Total = o.Total,
                VatAmount = o.VatAmount,
                GrandTotal = o.GrandTotal,

                PaymentStatus = o.PaymentStatus,
                PaymentType = o.PaymentType,
                Hold = o.Hold,

                Items = o.Items.Select(i => new PosOrderItemDto
                {
                    FoodMenuId = i.FoodMenuId,
                    SalesPrice = i.SalesPrice,
                    Quantity = i.Quantity
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<PosOrderDto> CreateAsync(PosOrderDto dto)
    {
        var foodMenuIds = dto.Items
            .Select(i => i.FoodMenuId)
            .ToList();

        var foodmenus = await _context.Foodmenus
            .Include(f => f.Vat)
            .Where(f => foodMenuIds.Contains(f.Id))
            .ToListAsync();

        decimal total = 0;
        decimal vatAmount = 0;

        var order = new PosOrder
        {
            CustomerId = dto.CustomerId,
            TableId = dto.TableId,
            WaiterId = dto.WaiterId,
            DeliveryId = dto.DeliveryId,

            Options = dto.Options,

            PaymentStatus = dto.PaymentStatus,
            PaymentType = dto.PaymentType,
            Hold = dto.Hold,

            Date = DateTime.UtcNow
        };

        foreach (var itemDto in dto.Items)
        {
            var foodmenu = foodmenus
                .FirstOrDefault(f => f.Id == itemDto.FoodMenuId);

            if (foodmenu == null)
                throw new Exception(
                    $"Food menu with ID {itemDto.FoodMenuId} not found."
                );

            var itemTotal = foodmenu.SalesPrice * itemDto.Quantity;

            decimal vatPercentage = 0;

            decimal.TryParse(
                foodmenu.Vat.Percentage,
                out vatPercentage
            );

            var itemVat =
                itemTotal * vatPercentage / 100;

            total += itemTotal;
            vatAmount += itemVat;

            var orderItem = new PosOrderItem
            {
                FoodMenuId = foodmenu.Id,
                SalesPrice = foodmenu.SalesPrice,
                Quantity = itemDto.Quantity
            };

            order.Items.Add(orderItem);
        }

        order.Total = total;
        order.VatAmount = vatAmount;
        order.GrandTotal = total + vatAmount;

        _context.PosOrders.Add(order);

        await _context.SaveChangesAsync();

        dto.Total = order.Total;
        dto.VatAmount = order.VatAmount;
        dto.GrandTotal = order.GrandTotal;

        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _context.PosOrders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return false;

        _context.PosOrders.Remove(order);

        await _context.SaveChangesAsync();

        return true;
    }
}