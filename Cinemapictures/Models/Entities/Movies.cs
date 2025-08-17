using System.ComponentModel.DataAnnotations;

namespace Cinemapictures.Models.Entities
{
    public class Movies
    {
                 [Key]
        public int MoviesId { get; set; }
        [Required, MaxLength(150)]
        public string MovieTitle { get; set; }
        [MaxLength(50)]

        public string Kind { get; set; }
        [MaxLength(150)]
        public int Year { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        [MaxLength(50)]
        public string language { get; set; }
        [MaxLength(100)]
        public List<Invoice> Invoices { get; set; }


    }
}
