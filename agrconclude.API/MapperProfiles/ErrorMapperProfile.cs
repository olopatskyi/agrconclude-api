using agrconclude.API.DTOs.Response;
using agrconclude.API.MapperProfiles.Converters;
using agrconclude.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace agrconclude.API.MapperProfiles
{
    public class ErrorMapperProfile : Profile
    {
        public ErrorMapperProfile()
        {
            CreateMap<ErrorMessage, ErrorResponse>()
           .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
           .ForMember(dest => dest.PropertyName, opt => opt.MapFrom(src => src.PropertyName));

            CreateMap<ModelStateDictionary, IEnumerable<ErrorResponse>>()
                .ConvertUsing<InvalidModelStateConverter>();

            CreateMap<IdentityError, ErrorMessage>()
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.PropertyName, opt => opt.Ignore());
        }
    }
}
