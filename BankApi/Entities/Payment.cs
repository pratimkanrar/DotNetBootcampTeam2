using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApi.Entities
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int ReceiptId { get; set; }
        [Required]
        public int CustId { get; set; }
        [Required]
        public DateTime ReceiptDate { get; set; }
        [Required]
        public DateTime EmiDate { get; set; }
        [Required]
        public double EmiAmount { get; set; }
        public double? LateFineCharge { get; set; }
        [Required]
        public double TotalAmount { get; set; }
    }
}
