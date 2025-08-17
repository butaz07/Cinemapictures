using System.ComponentModel.DataAnnotations;

namespace Cinemapictures.Models.Entities
{
    public class Kind
    {
        [Key]
        public int KindId { get; set; }
        [Required, MaxLength(150)]
        public string KindName { get; set; }
        [MaxLength(100)]

        public string Description { get; set; }
        [MaxLength(100)]

        public string Movies { get; set; }
        [MaxLength(100)]

        public List<Movies> movies { get; set; }

    }
}
