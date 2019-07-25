using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person : ILoanObject<PersonFieldList>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class PersonFieldList : FieldListBase
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int DateOfBirth { get; set; }
    }
}
