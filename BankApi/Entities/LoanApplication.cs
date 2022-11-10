using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApi.Entities
{
    [Table("LoanApplications")]
    public class LoanApplications
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LoanType { get; set; }
        [Required]
        public double LoanAmount { get; set; }
        [Required]
        public int CustId { get; set; }
        [Required]
        public int IsApproved { get; set; }
    }
}
