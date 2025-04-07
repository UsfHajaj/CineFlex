using System.ComponentModel.DataAnnotations;

namespace ETickets.Data.DTOs
{
    public class ActorDto
    {
        [Display(Name = "الصوره الشخصيه")]
        [Required(ErrorMessage = "من فضلك ادخل الصوره")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "من فضلك ادخل اسم الممثل")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "الاسم يجب اليكون من 3 احرف ك حد ادني و 50 ك حد اقصي")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "من فضلك ادخل ادخل تعريف الممثل")]
        public string Bio { get; set; }
    }
}
