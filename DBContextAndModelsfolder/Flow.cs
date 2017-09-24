using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Flow
    {
        public Flow()
        {
            Group = new HashSet<Group>();
        }

        public int IdFlow { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Group { get; set; }
    }
}
