using Models;
using ExternalMapping;

namespace Mapper
{

    public static class AttachmentExtension
    {
        public static void MapTo(this Models.Attachment attachment, External.LoanObject loanObject, AttachmentFieldList fields)
        {
            loanObject.MapValue(fields.Name, attachment.Name);
            loanObject.MapValue(fields.DocumentId, attachment.DocumentId);
        }

        public static Models.Attachment MapFrom(this External.LoanObject loanObject, AttachmentFieldList fields, Models.Attachment attachment = null)
        {
			bool changed = false;

			changed = changed || loanObject.ContainsValues(fields.Name,fields.DocumentId);
			

			if (changed)
            {
                if (attachment == null)
                {
                    attachment = new Attachment();
                }

				MappingUtil.SetValue(loanObject, fields.Name, (val) => attachment.Name = val, attachment.Name);
				MappingUtil.SetValue(loanObject, fields.DocumentId, (val) => attachment.DocumentId = val, attachment.DocumentId);
            }

            return attachment;
        }

	}


    public static class LoanExtension
    {
        public static void MapTo(this Models.Loan loan, External.LoanObject loanObject)
        {
            loanObject.MapValue(3, loan.LoanAmount);
            loan.PrimaryBorrower?.MapTo(loanObject, FieldList.PrimaryBorrower);
            loan.W2?.MapTo(loanObject, FieldList.W2);
        }

        public static Models.Loan MapFrom(this External.LoanObject loanObject, Models.Loan loan = null)
        {
			bool changed = false;

			var _primaryborrower = PersonExtension.MapFrom(loanObject, FieldList.PrimaryBorrower, loan?.PrimaryBorrower);
			changed = changed || (_primaryborrower != null);

			var _w2 = AttachmentExtension.MapFrom(loanObject, FieldList.W2, loan?.W2);
			changed = changed || (_w2 != null);

            changed = changed || loanObject.ContainsValues(FieldList.LoanAmount);

			if (changed)
            {
                if (loan == null)
                {
                    loan = new Loan();
                }

				loan.PrimaryBorrower = _primaryborrower;
				loan.W2 = _w2;
				MappingUtil.SetValue(loanObject, FieldList.LoanAmount, (val) => loan.LoanAmount = val, loan.LoanAmount);
            }

            return loan;
        }
	}


    public static class PersonExtension
    {
        public static void MapTo(this Models.Person person, External.LoanObject loanObject, PersonFieldList fields)
        {
            loanObject.MapValue(fields.FirstName, person.FirstName);
            loanObject.MapValue(fields.LastName, person.LastName);
            loanObject.MapValue(fields.DateOfBirth, person.DateOfBirth);
        }

        public static Models.Person MapFrom(this External.LoanObject loanObject, PersonFieldList fields, Models.Person person = null)
        {
			bool changed = false;

			changed = changed || loanObject.ContainsValues(fields.FirstName,fields.LastName,fields.DateOfBirth);
			

			if (changed)
            {
                if (person == null)
                {
                    person = new Person();
                }

				MappingUtil.SetValue(loanObject, fields.FirstName, (val) => person.FirstName = val, person.FirstName);
				MappingUtil.SetValue(loanObject, fields.LastName, (val) => person.LastName = val, person.LastName);
				MappingUtil.SetValue(loanObject, fields.DateOfBirth, (val) => person.DateOfBirth = val, person.DateOfBirth);
            }

            return person;
        }

	}

}
