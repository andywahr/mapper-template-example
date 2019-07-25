using System;

namespace Models
{
    public class Loan : ILoanObject
    {
        [LoanObjectChildObject]
        public Person PrimaryBorrower { get; set; }

        [LoanObjectProperty(FieldList.LoanAmount)]
        public double LoanAmount { get; set; }

        [LoanObjectChildObject]
        public Attachment W2 { get; set; }
    }

    public static class FieldList
    {
        public static readonly PersonFieldList PrimaryBorrower = new PersonFieldList()
        {
            FirstName = 1,
            LastName = 2,
            DateOfBirth = 4
        };

        public const int LoanAmount = 3;

        public static readonly AttachmentFieldList W2 = new AttachmentFieldList()
        {
             Name = 10,
             DocumentId = 11
        };
    }
}
