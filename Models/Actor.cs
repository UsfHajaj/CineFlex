using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "picture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        public List<MovieActors> MovieActors { get; set; }
    }
}
