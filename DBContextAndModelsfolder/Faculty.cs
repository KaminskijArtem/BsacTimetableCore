using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Faculty
    {
        public Faculty()
        {
            Group = new HashSet<Group>();
        }

        public int IdFaculty { get; set; }
        public string NameFaculty { get; set; }

        public ICollection<Group> Group { get; set; }
    }
}
