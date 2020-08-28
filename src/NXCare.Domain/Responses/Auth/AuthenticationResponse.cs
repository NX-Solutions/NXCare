using NXCare.Domain.DTO.Auth;
using NXCare.Domain.Responses.Base;

namespace NXCare.Domain.Responses.Auth
{
    public class AuthenticationResponse : BaseResponse
    {
        public UserAuthenticatedDTO User { get; set; }
    }
}