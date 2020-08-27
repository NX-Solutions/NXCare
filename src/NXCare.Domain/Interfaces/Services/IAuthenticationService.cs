using NXCare.Domain.Responses.Auth;
using System.Threading.Tasks;

namespace NXCare.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(string username, string password);
    }
}
