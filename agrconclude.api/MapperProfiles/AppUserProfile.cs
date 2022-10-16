using agrconclude.api.DTOs.Request;
using agrconclude.api.DTOs.Response;
using agrconclude.core.Models;
using AutoMapper;

namespace agrconclude.api.MapperProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<LoginResponseModel, LoginResponse>();

            CreateMap<LoginRequest, LoginRequestModel>();
        }
    }
}
