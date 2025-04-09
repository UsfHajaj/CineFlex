using System.ComponentModel.DataAnnotations;

namespace ETickets.Data.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
