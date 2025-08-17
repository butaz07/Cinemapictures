using System.ComponentModel.DataAnnotations;

namespace Cinemapictures.Models.Entities
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        public int Quantity { get; set; }
        public decimal Taxes { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
