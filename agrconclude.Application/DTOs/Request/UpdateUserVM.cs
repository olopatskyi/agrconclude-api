using agrconclude.Domain.Entities;

namespace agrconclude.Application.DTOs.Request;

public class UpdateUserVM
{
    public Gender Gender { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime Birthday { get; set; }

    public string AvatarUrl { get; set; }
}