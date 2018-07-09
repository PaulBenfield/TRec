using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class LocalSettings 
    {
        public Guid LastTimeEntryId { get; set; }

        public int LastReminderPeriodInMilliseconds { get; set; }
    }
}
