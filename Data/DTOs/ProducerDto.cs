using System.ComponentModel.DataAnnotations;

namespace ETickets.Data.DTOs
{
    public class ProducerDto
    {
        [Display(Name = "الصوره الشخصيه")]
        [Required(ErrorMessage = "من فضلك ادخل الصوره")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "من فضلك ادخل الاسم ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "الاسم يجب اليكون من 3 احرف ك حد ادني و 50 ك حد اقصي")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "من فضلك ادخل ادخل تعريف المنتج")]
        public string Bio { get; set; }
    }
}
