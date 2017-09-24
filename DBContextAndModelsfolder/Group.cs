using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Group
    {
        public Group()
        {
            Record = new HashSet<Record>();
        }

        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
        public int? IdFlow { get; set; }
        public int IdFaculty { get; set; }
        public int EduLevel { get; set; }

        public Faculty IdFacultyNavigation { get; set; }
        public Flow IdFlowNavigation { get; set; }
        public ICollection<Record> Record { get; set; }
    }
}
