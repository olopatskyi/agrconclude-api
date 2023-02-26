namespace agrconclude.Application.DTOs;

public class AppUserDTO
{
    public Guid Id { get; set; }

    public string AvatarUrl { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }
}