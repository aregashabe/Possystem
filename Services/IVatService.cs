using POSsystem.DTOs;
using POSsystem.Entities;

namespace POSsystem.Services;

public interface IVatService
{
    Task<IEnumerable<Vat>> GetAllVatsAsync();
    Task<Vat?> GetVatByIdAsync(int id);
    Task<Vat> CreateVatAsync(VatDto vatDto);
    Task<Vat?> UpdateVatAsync(int id, VatDto vatDto);
    Task<bool> DeleteVatAsync(int id);
}