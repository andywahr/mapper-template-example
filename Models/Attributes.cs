using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LoanObjectPropertyAttribute : Attribute
    {
        public LoanObjectPropertyAttribute(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }

    public class LoanObjectChildObjectAttribute : Attribute
    {
    }

    public interface ILoanObject
    {

    }

    public interface ILoanObject<T>
    {

    }
}
