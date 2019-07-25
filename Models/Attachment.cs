using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Attachment : ILoanObject<AttachmentFieldList>
    {
        public string Name { get; set; }
        public string DocumentId { get; set; }
    }

    public class AttachmentFieldList
    {
        public int Name { get; set; }
        public int DocumentId { get; set; }
    }
}
