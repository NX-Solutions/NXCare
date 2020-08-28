using NXCare.Domain.Interfaces.Services;
using NXCare.Domain.Responses.Auth;
using System;
using System.Threading.Tasks;

namespace NXCare.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<AuthenticationResponse> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}