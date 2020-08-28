using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NXCare.Domain.Constants.Responses;
using NXCare.Domain.DTO.Auth;
using NXCare.Domain.Interfaces.Services;
using NXCare.Domain.Options.Auth;
using NXCare.Domain.Responses.Auth;

namespace NXCare.Mock.Services
{
    public class MockAuthenticationService : IAuthenticationService
    {
        private readonly IOptions<JwtOptions> jwtOptions;

        public MockAuthenticationService(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(string username, string password)
        {
            await Task.Delay(5);

            if (!EnsureAuthData(username, password, out var authenticationResponse)) return authenticationResponse;

            var token = GenerateJwtToken(username);
            return new AuthenticationResponse()
            {
                User = new UserAuthenticatedDTO
                {
                    Firstname = "Toto",
                    Lastname  = "Lasticot",
                    Username  = "Toto",
                    Token     = token
                }
            };
        }

        private bool EnsureAuthData(string username, string password, out AuthenticationResponse authenticationResponse)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                authenticationResponse = AuthResponsesConstants.UsernameEmpty;
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                authenticationResponse = AuthResponsesConstants.PasswordEmpty;
                return false;
            }

            if (username != "toto" || password != "toto")
            {
                authenticationResponse = AuthResponsesConstants.WrongUsernameOrPassword;
                return false;
            }

            authenticationResponse = null;
            return true;
        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes(jwtOptions.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha512Signature),
                Issuer = jwtOptions.Value.Issuer,
                Audience = jwtOptions.Value.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private void CreatePasswordHashAndSalt(string password, out string passwordHash, out string passwordSalt)
        {
            if (password == null) throw new ArgumentNullException($"{nameof(MockAuthenticationService)}: {nameof(CreatePasswordHashAndSalt)}: {nameof(password)} can not be null ");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException($"{nameof(MockAuthenticationService)}: {nameof(CreatePasswordHashAndSalt)}: {nameof(password)} can not contains only whitespaces");

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            passwordSalt = Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            passwordHash = GenerateHash(password, passwordSalt);
        }

        private static string GenerateHash(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        private bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            return storedHash == GenerateHash(password, storedSalt);
        }
    }
}