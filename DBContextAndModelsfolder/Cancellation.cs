using System;
using System.Collections.Generic;

namespace BsacTimetableCore.DBContextAndModelsfolder
{
    public partial class Cancellation
    {
        public int IdCancellation { get; set; }
        public int IdRecord { get; set; }

        public Record IdRecordNavigation { get; set; }
    }
}
