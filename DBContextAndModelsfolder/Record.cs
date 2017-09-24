using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Record
    {
        public Record()
        {
            Cancellation = new HashSet<Cancellation>();
        }

        public int IdRecord { get; set; }
        public sbyte WeekNumber { get; set; }
        public sbyte WeekDay { get; set; }
        public sbyte SubjOrdinalNumber { get; set; }
        public int IdGroup { get; set; }
        public short IdSubject { get; set; }
        public short IdLecturer { get; set; }
        public int IdSubjectType { get; set; }
        public sbyte IdSubjectFor { get; set; }
        public short IdClassroom { get; set; }

        public Classroom IdClassroomNavigation { get; set; }
        public Group IdGroupNavigation { get; set; }
        public Lecturer IdLecturerNavigation { get; set; }
        public SubjectFor IdSubjectForNavigation { get; set; }
        public Subject IdSubjectNavigation { get; set; }
        public SubjectType IdSubjectTypeNavigation { get; set; }
        public ICollection<Cancellation> Cancellation { get; set; }
    }
}
