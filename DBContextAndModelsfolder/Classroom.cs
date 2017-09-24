using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Classroom
    {
        public Classroom()
        {
            Record = new HashSet<Record>();
        }

        public short IdClassroom { get; set; }
        public string Name { get; set; }
        public sbyte Building { get; set; }

        public ICollection<Record> Record { get; set; }
    }
}
