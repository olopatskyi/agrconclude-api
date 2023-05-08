using agrconclude.Application.DTOs.Request;
using agrconclude.Domain.Entities;

namespace agrconclude.Application.Interfaces;

public interface IUserService
{
    Task<TOut> GetUsersAsync<TOut>(string callerId);

    Task UpdateAsync(string userId, UpdateUserVM model);

    Task<AppUser> GetProfile(string id);
}