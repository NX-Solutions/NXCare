using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using NXCare.Domain.Interfaces.Services;
using NXCare.Domain.Responses.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NXCare.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private static readonly AuthenticationResponse WrongUsernameOrPasswordAuthenticationResponse = new AuthenticationResponse { StatusCode = HttpStatusCode.BadRequest, ResponseMessage = "Wrong username or password" };


        public AuthenticationService()
        {
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return new AuthenticationResponse { StatusCode = HttpStatusCode.BadRequest, ResponseMessage = "Username or password missing" };


            if (!username.Equals("toto") || !password.Equals("toto"))
            {
                return new AuthenticationResponse { StatusCode = HttpStatusCode.Unauthorized, ResponseMessage = "Username or password invalid" };
            }

            var token = GenerateJwtToken(username, password);
            return new AuthenticationResponse()
            {
                Firstname = "Toto",
                Lastname = "Lasticot",
                Username = "Toto",
                Token = token,
                StatusCode = HttpStatusCode.OK
            };
        }

        private string GenerateJwtToken(string username, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ToTo1234ToTo1234ToTo1234ToTo1234ToTo1234ToTo1234ToTo1234ToTo1234");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "Toto")
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
                Issuer = "NXCare",
                Audience = "NXCare.API"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private void CreatePasswordHashAndSalt(string password, out string passwordHash, out string passwordSalt)
        {
            if (password == null) throw new ArgumentNullException($"{nameof(AuthenticationService)}: {nameof(CreatePasswordHashAndSalt)}: {nameof(password)} can not be null ");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException($"{nameof(AuthenticationService)}: {nameof(CreatePasswordHashAndSalt)}: {nameof(password)} can not contains only whitespaces");

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
