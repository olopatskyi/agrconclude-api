using agrconclude.Domain;
using agrconclude.Domain.Entities;
using agrconclude.Domain.Exceptions;
using agrconclude.Domain.Interfaces;
using agrconclude.Domain.Models;
using agrconclude.Domain.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace agrconclude.Application
{
    public class AuthService : IAuthService
    {
        private readonly IJwtOptions _jwtOptions;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(IJwtOptions jwtOptions, IMapper mapper, UserManager<AppUser> userManager)
        {
            _jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<TOut> LoginAsync<TIn, TOut>(TIn request)
        {
            var loginModel = _mapper.Map<LoginRequestModel>(request);
            var payload = await ValidateGoogleTokenAsync(loginModel.TokenId);


            var user = await _userManager.FindByEmailAsync(payload.Email);
            if (user is null)
            {
                user = _mapper.Map<AppUser>(payload);

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                {
                    throw new AppException(_mapper.Map<IEnumerable<ErrorMessage>>(createResult.Errors));
                }
            }

            await _userManager.UpdateSecurityStampAsync(user);
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
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
                new Claim(AppConstants.JwtAvatarUrl, user.AvatarUrl),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtOptions.ExpireMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<Payload> ValidateGoogleTokenAsync(string tokenId)
        {
            var payload = await ValidateAsync(tokenId, new ValidationSettings());
            return payload;
        }
    }
}