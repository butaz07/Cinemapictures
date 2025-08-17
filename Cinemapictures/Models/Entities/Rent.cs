using System.ComponentModel.DataAnnotations;

namespace Cinemapictures.Models.Entities
{
    public class Rent
    {
        [Key]
        public int RentId { get; set; }
        [Required, MaxLength(150)]

        public int Cost { get; set; }

        public int Period_of_time { get; set; }

        public List<Movies> Movies { get; set; } = new List<Movies>();



    }
}
