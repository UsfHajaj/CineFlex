using System.ComponentModel.DataAnnotations;

namespace ETickets.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAdress { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تذكرني")]
        public bool RememberMe { get; set; }
    }
}
