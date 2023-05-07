namespace agrconclude.Application.DTOs.Request;

public class CreateContractVM
{
    public string Label { get; set; }

    public string Description { get; set; }
    
    public string ClientId { get; set; }

    public string DocumentId { get; set; }
    
    public DateTime ExpireAt { get; set; }
}