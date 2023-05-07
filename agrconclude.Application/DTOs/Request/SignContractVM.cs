using agrconclude.Domain.Entities;

namespace agrconclude.Application.DTOs.Request;

public class SignContractVM
{
    public string ContractId { get; set; }

    public ContractStatus Status { get; set; }

    public string? DocumentId { get; set; }
}