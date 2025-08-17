using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinemapictures.Models.Entities
{
    public class Movies
    {
                 [Key]
        public int MoviesId { get; set; }
        [Required, MaxLength(150)]
        public string MovieTitle { get; set; }
        [MaxLength(50)]

        public required string Kind { get; set; }
        public int Year { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        [MaxLength(50)]
        public string language { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DailyRentalCost { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();


    }
}
