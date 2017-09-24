using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class SubjectType
    {
        public SubjectType()
        {
            Record = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Record> Record { get; set; }
    }
}
