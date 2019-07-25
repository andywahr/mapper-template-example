using External;
using Models;
using Mapper;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Loan newLoan;
            using (Session s = new Session())
            {
                LoanObject loanObjectFromExternal = s.GetLoan(5);

                newLoan = loanObjectFromExternal.MapFrom();
            }


            using ( Session s2 = new Session() )
            {
                LoanObject externalLoan = s2.CreateLoan();
                newLoan.MapTo(externalLoan);

                s2.Save(externalLoan);
            }
        }
    }
}
