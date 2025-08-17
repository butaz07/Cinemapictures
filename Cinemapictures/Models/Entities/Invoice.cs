using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinemapictures.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int MovieId { get; set; }
        public Movies Movie { get; set; }

        public int RentId { get; set; }
        public Rent Rent { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalTax { get; set; }

        public DateTime Date { get; set; }

        public double TotalAmount { get; set; }
    }
}
