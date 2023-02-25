using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace agrconclude.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<TOut> LoginAsync<TIn, TOut>(TIn request);
    }
}
