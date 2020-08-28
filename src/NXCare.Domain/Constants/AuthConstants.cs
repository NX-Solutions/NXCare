using NXCare.Domain.Enums.Auth;
using NXCare.Domain.Responses.Auth;

namespace NXCare.Domain.Constants.Responses
{
    public static class AuthResponsesConstants
    {
        public static AuthenticationResponse WrongUsernameOrPassword => new AuthenticationResponse {ResponseCode  = (int) AuthReturnCodes.WrongUserNameOrPassword, ResponseMessage = "Wrong username or password"};

        public static AuthenticationResponse UserNotFound => new AuthenticationResponse {ResponseCode  = (int) AuthReturnCodes.UserNotFound, ResponseMessage = "User could not be found"};

        public static AuthenticationResponse UsernameEmpty => new AuthenticationResponse {ResponseCode =  (int) AuthReturnCodes.UsernameEmpty, ResponseMessage = "Username can not be empty"};

        public static AuthenticationResponse PasswordEmpty => new AuthenticationResponse {ResponseCode = (int) AuthReturnCodes.PasswordEmpty, ResponseMessage = "Password can not be empty"};
    }
}