using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Subject
    {
        public Subject()
        {
            Record = new HashSet<Record>();
        }

        public short IdSubject { get; set; }
        public string NameSubject { get; set; }
        public sbyte IdChair { get; set; }
        public sbyte EduLevel { get; set; }
        public string AbnameSubject { get; set; }

        public Chair IdChairNavigation { get; set; }
        public ICollection<Record> Record { get; set; }
    }
}
