using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "الصوره")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }
        [Display(Name = "التعريف")]
        public string Bio { get; set; }
        public List<MovieActors> MovieActors { get; set; }
    }
}
