using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerApi.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
           [Phone]
        public string Number { get; set; }
     
        public string Address { get; set; }
        public int? LoanId { get; set; }
        public string Pan { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public int MonthlyIncome { get; set; }
    }
}
