namespace NXCare.Domain.Enums.Auth
{
    public enum AuthReturnCodes
    {
        Success                 = 0,
        UserNotFound            = 1,
        WrongUserNameOrPassword = 2,
        UsernameEmpty           = 3,
        PasswordEmpty           = 4
    }
}