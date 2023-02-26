namespace agrconclude.Application.Interfaces;

public interface IContractService
{
    Task<TOut> CreateAsync<TIn, TOut>(TIn request);
}