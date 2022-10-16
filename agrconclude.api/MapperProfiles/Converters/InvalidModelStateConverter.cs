using agrconclude.api.DTOs.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace agrconclude.api.MapperProfiles.Converters
{
    public class InvalidModelStateConverter : ITypeConverter<ModelStateDictionary, IEnumerable<ErrorResponse>>
    {
        public IEnumerable<ErrorResponse> Convert(ModelStateDictionary source, IEnumerable<ErrorResponse> destination, ResolutionContext context)
        {
            foreach (var keyModelStatePair in source)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    foreach (var error in errors)
                    {
                        yield return new ErrorResponse(error.ErrorMessage, key);
                    }
                }
            }
        }
    }
}
