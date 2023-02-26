namespace agrconclude.Application.Interfaces;

public interface IUserService
{
    Task<TOut> GetUsersAsync<TOut>(Guid callerId);
}