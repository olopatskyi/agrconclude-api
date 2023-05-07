using agrconclude.Domain.Entities;

namespace agrconclude.API.DTOs.Response;

public class ContractResponse
{
    public string Id { get; set; }
    
    public string DocumentId { get; set; }
    
    public AppUser Creator { get; set; }

    public AppUser Client { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Description { get; set; }

    public string Label { get; set; }

    public DateTime ExpireAt { get; set; }
    
    public ContractStatus Status { get; set; }
}