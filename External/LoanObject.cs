using System;
using System.Collections.Generic;

namespace External
{
    /*
     *  FirstName of Primary Borrrower is Field #1 
     *  LastName of Primary Borrrower is Field #2
     *  LoanAmount is Field #3
     * 
     *  LoanObject lo;
     *  lo.Properties[1] == FirstName of Primary Borrrower
     *  
     *  Loan l;
     *  
     *  l.PrimaryBorrower.FirstName == lo.Properties[1]
     * 
    */

    public class LoanObject
    {
        public Dictionary<int, LoanProperty> Properties { get; set; }
    }

    public class LoanProperty
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
