namespace agrconclude.Application.Interfaces;

public interface IContractService
{
    Task CreateAsync<TIn>(string userId, TIn request);

    Task<TOut> GetByIdAsync<TOut>(string id);

    Task<TOut> GetAllAsync<TOut>(string userId);
}