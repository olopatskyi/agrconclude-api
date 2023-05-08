using agrconclude.Domain.Entities;

namespace agrconclude.Application.DTOs.Request;

public class SignContractVM
{
    public ContractStatus Status { get; set; }

    public string? DocumentId { get; set; }
}