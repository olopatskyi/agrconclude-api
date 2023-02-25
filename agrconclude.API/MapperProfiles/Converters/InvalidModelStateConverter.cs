using agrconclude.API.DTOs.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace agrconclude.API.MapperProfiles.Converters
{
    public class InvalidModelStateConverter : ITypeConverter<ModelStateDictionary, IEnumerable<ErrorResponse>>
    {
        public IEnumerable<ErrorResponse> Convert(ModelStateDictionary source, IEnumerable<ErrorResponse> dest,
            ResolutionContext context)
        {
            var result = new List<ErrorResponse>();

            foreach (var keyModelStatePair in source)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    foreach (var error in errors)
                    {
                        result.Add(new ErrorResponse(error.ErrorMessage, key));
                    }
                }
            }

            return result;
        }
    }
}