using POSsystem.Entities;
using POSsystem.Services;


namespace POSsystem;
public static class AdminInitializer
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var userService = services.GetRequiredService<IUserService>();

        var adminEmail = "admin@pos.com";
        var adminPassword = "Admin@123";

        var existingUsers = await userService.GetAllUsersAsync();

        if (existingUsers.Any(u => u.Email == adminEmail))
        {
            return;
        }

        var admin = new User
        {
            Email = adminEmail,
            UserRole = "Admin",
            Password = adminPassword
        };

        await userService.createUserAsync(admin);
    }
}