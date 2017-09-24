using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Chair
    {
        public Chair()
        {
            Lecturer = new HashSet<Lecturer>();
            Subject = new HashSet<Subject>();
        }

        public sbyte IdChair { get; set; }
        public string NameChair { get; set; }

        public ICollection<Lecturer> Lecturer { get; set; }
        public ICollection<Subject> Subject { get; set; }
    }
}
