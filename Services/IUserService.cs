using POSsystem.Entities;
using POSsystem.DTOs;

namespace POSsystem.Services;

public interface IUserService{
    Task<User>  createUserAsync(User user);
    Task<LoginResponseDto?> LoginAsync(
        string email,
        string password);
        Task<List<User>> GetAllUsersAsync();
}