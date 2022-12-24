using agrconclude.core;
using agrconclude.core.Entities;
using agrconclude.core.Exceptions;
using agrconclude.core.Interfaces;
using agrconclude.core.Models;
using agrconclude.core.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace agrconclude.services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthSettings _authSettings;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper, IAuthSettings authSettings)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authSettings = authSettings;
        }

        public async Task<TOut> LoginAsync<TIn, TOut>(TIn request)
        {
            var loginModel = _mapper.Map<LoginRequestModel>(request);
            var payload = await ValidateTokenAsync(loginModel.TokenId);

            var user = await _userManager.FindByEmailAsync(payload.Email);
            if (user is null)
            {
                user = new AppUser()
                {
                    UserName = payload.Email,
                    AvatarUrl = payload.Picture,
                    NormalizedUserName = payload.Name.ToUpper(),
                    Email = payload.Email,
                    NormalizedEmail = payload.Email.ToUpper(),
                    EmailConfirmed = true,
                    ConcurrencyStamp = "25d733fa-b5ce-41fe-a868-beea7723a3e5",
                    SecurityStamp = "25d733fa-b5ce-41fe-a868-beea7723a3e5",
                    FirstName = payload.GivenName,
                    LastName = payload.FamilyName,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                };

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                {
                    throw new AppException(_mapper.Map<IEnumerable<ErrorMessage>>(createResult.Errors));
                }
            }

            string token = GenerateJwtToken(user);
            var response = new LoginResponseModel
            {
                Token = token
            };

            return _mapper.Map<TOut>(response);
        }

        private string GenerateJwtToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
                new Claim(AppConstants.JwtAvatarUrl, user.AvatarUrl),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            string s = _authSettings.Key;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    issuer: _authSettings.Issuer,
                    audience: _authSettings.Audience,
                    claims: claims,
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<Payload> ValidateTokenAsync(string tokenId)
        {
            var payload = await ValidateAsync(tokenId, new ValidationSettings());
            return payload;
        }
    }
}
