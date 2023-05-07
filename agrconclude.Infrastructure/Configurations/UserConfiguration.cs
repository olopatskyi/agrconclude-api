using agrconclude.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agrconclude.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(u => u.Id);

        builder.HasData(new AppUser()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            AvatarUrl = Guid.NewGuid().ToString(),
            UserName = Guid.NewGuid().ToString(),
            NormalizedUserName = Guid.NewGuid().ToString().ToUpper(),
            Email = $"{Guid.NewGuid()}@example.com",
            NormalizedEmail = $"{Guid.NewGuid()}@EXAMPLE.COM".ToUpper(),
            EmailConfirmed = true,
            PhoneNumber = $"555-{Guid.NewGuid().ToString().Substring(0, 7)}",
            PhoneNumberConfirmed = true,
            PasswordHash = Guid.NewGuid().ToString("N"),
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("N")
        });
        
        builder.HasData(new AppUser()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = Guid.NewGuid().ToString(),
            LastName = Guid.NewGuid().ToString(),
            AvatarUrl = Guid.NewGuid().ToString(),
            UserName = Guid.NewGuid().ToString(),
            NormalizedUserName = Guid.NewGuid().ToString().ToUpper(),
            Email = $"{Guid.NewGuid()}@example.com",
            NormalizedEmail = $"{Guid.NewGuid()}@EXAMPLE.COM".ToUpper(),
            EmailConfirmed = true,
            PhoneNumber = $"555-{Guid.NewGuid().ToString().Substring(0, 7)}",
            PhoneNumberConfirmed = true,
            PasswordHash = Guid.NewGuid().ToString("N"),
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("N")
        });
    }
}