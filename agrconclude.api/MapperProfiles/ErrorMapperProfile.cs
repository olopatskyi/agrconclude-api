using agrconclude.api.DTOs.Response;
using agrconclude.api.MapperProfiles.Converters;
using agrconclude.core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace agrconclude.api.MapperProfiles
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
