using agrconclude.Application.DTOs;
using agrconclude.Application.Interfaces;
using agrconclude.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace agrconclude.Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<TOut> GetUsersAsync<TOut>(string callerId)
    {
        var users = await _userManager.Users
            .Where(u => u.Id != callerId)
            .AsNoTracking()
            .ToListAsync();
        
        return _mapper.Map<TOut>(users);
    }
}