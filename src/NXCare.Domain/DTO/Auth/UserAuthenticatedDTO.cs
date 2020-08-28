namespace NXCare.Domain.DTO.Auth
{
    public class UserAuthenticatedDTO
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }
    }
}