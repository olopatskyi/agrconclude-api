using agrconclude.API.DTOs.Response;
using agrconclude.Application.DTOs;
using agrconclude.Application.DTOs.Request;
using agrconclude.Domain.Entities;
using agrconclude.Domain.Models;
using AutoMapper;
using Google.Apis.Auth;

namespace agrconclude.API.MapperProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<LoginResponseModel, LoginResponse>();

            CreateMap<LoginRequest, LoginRequestModel>();

            CreateMap<GoogleJsonWebSignature.Payload, AppUser>(MemberList.None)
                .AfterMap((src, dest) =>
                {
                    dest.UserName = src.Email;
                    dest.AvatarUrl = src.Picture;
                    dest.NormalizedUserName = src.Name.ToUpper();
                    dest.Email = src.Email;
                    dest.NormalizedEmail = src.Email.ToUpper();
                    dest.EmailConfirmed = true;
                    dest.ConcurrencyStamp = Guid.NewGuid().ToString();
                    dest.SecurityStamp = Guid.NewGuid().ToString();
                    dest.FirstName = src.GivenName;
                    dest.LastName = src.FamilyName;
                    dest.TwoFactorEnabled = false;
                    dest.LockoutEnabled = false;
                });

            CreateMap<AppUser, AppUserDTO>(MemberList.Destination);
        }
    }
}
