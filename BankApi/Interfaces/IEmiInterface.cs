using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Entities;
namespace BankApi.Interfaces
{
    public interface IEmiInterface
    {
        double CalculateEmi(int loanamount, double interestrate, int tenure);
    }
}