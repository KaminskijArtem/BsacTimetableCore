using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class SubjectFor
    {
        public SubjectFor()
        {
            Record = new HashSet<Record>();
        }

        public sbyte Id { get; set; }
        public string Name { get; set; }

        public ICollection<Record> Record { get; set; }
    }
}
