using System.ComponentModel.DataAnnotations;
namespace POSsystem.Entities;
public class Customer{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;
    [Required]
    [MaxLength(250)]
    public string Address { get; set; } = string.Empty;

}


// protected override void OnModelCreating(ModelBuilder modelBuilder)
// {
//     modelBuilder.Entity<Customer>()
//         .HasIndex(c => c.Name)
//         .IsUnique();

//     modelBuilder.Entity<Customer>()
//         .HasIndex(c => c.Email)
//         .IsUnique();

//     modelBuilder.Entity<Customer>()
//         .HasIndex(c => c.Phone)
//         .IsUnique();
// }