using System.ComponentModel.DataAnnotations;

namespace Cinemapictures.Models.Entities
{
    public class Rent
    {
        [Key]
        public int RentId { get; set; }
        [Required, MaxLength(150)]

        public int Cost { get; set; }
        [MaxLength(100)]

        public int Period_of_time { get; set; }
        [MaxLength(100)]

        public List<Movies> Movies { get; set; }



    }
}
