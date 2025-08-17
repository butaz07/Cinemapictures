using System.ComponentModel.DataAnnotations;

namespace Cinemapictures.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required, MaxLength(150)]

        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Sex { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]

        public double Salary { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]

        public string Country { get; set; }
        [MaxLength(50)]

        public string DNI { get; set; }
        [MaxLength(50)]

        public List<Invoice> Invoices { get; set; }
    }
}
