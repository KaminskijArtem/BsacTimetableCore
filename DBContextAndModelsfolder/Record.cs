﻿using System;
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
        public int WeekNumber { get; set; }
        public int WeekDay { get; set; }
        public int SubjOrdinalNumber { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public int IdGroup { get; set; }
        public short IdSubject { get; set; }
        public short IdLecturer { get; set; }
        public int IdSubjectType { get; set; }
        public int IdSubjectFor { get; set; }
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
