using ETickets.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Data.ViewModels
{
    public class MovieVM
    {
        public int ID { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Movie Name is reqired")]
        public string Title { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Movie Description is reqired")]
        public string Description { get; set; }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Movie Start date is reqired")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie Release Date")]
        [Required(ErrorMessage = "Movie Release date is reqired")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "Movie End date is reqired")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Price")]
        [Required(ErrorMessage = "Movie Price is reqired")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster")]
        [Required(ErrorMessage = "Movie Poster is reqired")]
        public string ImageURL { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Movie Category is reqired")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select  Actor(s)")]
        [Required(ErrorMessage = "Movie Actor(s) is reqired")]
        public List<int> ActorIDs { get; set; }

        [Display(Name = "Select a Cinema")]
        [Required(ErrorMessage = "Movie Cinema is reqired")]
        public int CinemaID { get; set; }

        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Movie Producer is reqired")]
        public int ProdcerID { get; set; }

    }
}
