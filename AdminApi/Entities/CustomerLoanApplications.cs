using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminApi.Entities
{

    public class CustomerLoanApplications
    {
       
        public int Id { get; set; }
     
        public string LoanType { get; set; }

        public double LoanAmount { get; set; }
        public string CustomerName { get; set; }
        public int MonthlyIncome { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
     
        public string Number { get; set; }
 
        public string Email { get; set; }
        public bool IsApproved { get; set; }   
    }
}
