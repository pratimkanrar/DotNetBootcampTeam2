using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApi.Entities
{
    [Table("LoanRate")]
    public class LoanRate
    {
        [Key]
        public string LoanType { get; set; }
        [Required]
        public double InterestRate { get; set; }
    }
}
