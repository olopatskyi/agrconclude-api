using agrconclude.API.DTOs.Response;
using agrconclude.Application.DTOs.Request;
using agrconclude.Application.Interfaces;
using agrconclude.Domain.Entities;
using agrconclude.Infrastructure.Repositories;
using AutoMapper;

namespace agrconclude.Application.Services;

public class ContractService : IContractService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Contract> _repository;
    
    public ContractService(IRepository<Contract> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task CreateAsync<TIn>(string userId, TIn request)
    {
        var model = _mapper.Map<Contract>(request);
        model.CreatorId = userId;
        await _repository.AddAsync(model);
        await _repository.SaveAsync();
    }

    public async Task<TOut> GetByIdAsync<TOut>(string id)
    {
        var contract = await _repository.GetByIdAsync(id, "Client", "Creator");

        return _mapper.Map<TOut>(contract);
    }

    public async Task<TOut> GetAllAsync<TOut>(string userId, bool isMine)
    {
        var result = isMine 
            ? await _repository.GetAllAsync(x => x.CreatorId == userId, "Client", "Creator")
            : await _repository.GetAllAsync(x => x.ClientId == userId, "Client", "Creator");
        
        return _mapper.Map<TOut>(result);
    }

    public async Task SignContractAsync(SignContractVM model)
    {
        var entity = await _repository.GetByIdAsync(model.ContractId);
        if (entity is null)
        {
            throw new Exception("Contract not found");
        }

        entity.Status = model.Status;
        if (model.DocumentId is not null)
        {
            entity.DocumentId = model.DocumentId;
        }

        _repository.Update(entity);
        await _repository.SaveAsync();
    }
}