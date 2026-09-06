using POSsystem.DTOs;

namespace POSsystem.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentDto>> GetAllAsync();

    Task<PaymentDto?> GetByIdAsync(int id);

    Task<PaymentDto> CreateAsync(PaymentDto dto);

    Task<bool> UpdateAsync(int id, PaymentDto dto);

    Task<bool> DeleteAsync(int id);
}