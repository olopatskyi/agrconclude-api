using agrconclude.API.DTOs.Response;
using agrconclude.Application.DTOs.Request;
using agrconclude.Domain.Entities;
using AutoMapper;

namespace agrconclude.API.MapperProfiles;

public class ContractProfile : Profile
{
    public ContractProfile()
    {
        CreateMap<CreateContractVM, Contract>(MemberList.None)
            .AfterMap((src, dest) =>
            {
                dest.Id = Guid.NewGuid().ToString();
                dest.Label = src.Label;
                dest.Description = src.Description;
                dest.ClientId = src.ClientId;
                dest.DocumentId = src.DocumentId;
                dest.Status = ContractStatus.Pending;
                dest.CreatedAt = DateTime.UtcNow;
                dest.ExpireAt = src.ExpireAt;
            });

        CreateMap<Contract, ContractResponse>(MemberList.None);
    }
}