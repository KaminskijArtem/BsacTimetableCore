using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Record = new HashSet<Record>();
        }

        public short IdLecturer { get; set; }
        public string NameLecturer { get; set; }
        public sbyte IdChair { get; set; }

        public Chair IdChairNavigation { get; set; }
        public ICollection<Record> Record { get; set; }
    }
}
