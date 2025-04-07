using System.ComponentModel.DataAnnotations;

namespace ETickets.Data.DTOs
{
    public class CinemaDto
    {
        [Display(Name = "الصوره الشخصيه")]
        [Required(ErrorMessage = "من فضلك ادخل الصوره")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "من فضلك ادخل الاسم ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "الاسم يجب اليكون من 3 احرف ك حد ادني و 50 ك حد اقصي")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "من فضلك ادخل ادخل تعريف المنتج")]
        public string Description { get; set; }
    }
}
