namespace ETickets.Data.ViewModels
{
    public class AuthViewModel
    {
        public LoginVM Login { get; set; } = new LoginVM();
        public RegisterVM Register { get; set; } = new RegisterVM();
    }
}
