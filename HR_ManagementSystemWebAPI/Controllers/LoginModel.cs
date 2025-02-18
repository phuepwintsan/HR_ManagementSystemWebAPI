namespace HR_ManagementSystemWebAPI.Controllers
{
    public class LoginModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

        public string? Email { get; set; }
    }
}
