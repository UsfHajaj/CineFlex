using ETickets.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get;set; }
        public DateTime EndDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public List<MovieActors> MovieActors { get; set; }
        public int CinemaId {  get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema {  get; set; }
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }

    }
}
