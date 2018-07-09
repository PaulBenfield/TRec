using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TRec.BusinessLayer
{
    [DataObject]
    public class ReportingItemSummary
    {
        public Guid TimeEntryId { get; set; }

        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public Guid TaskId { get; set; }

        public string Details { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int ExceptionMinutes { get; set; }

        public string ExceptionDetails { get; set; }

        public string ProjectName { get; set; }

        public string TaskName { get; set; }

        public string UserDisplayName { get; set; }

        public int TotalMinutes { get; set; }

        public DateTime SingleDay
        {
            get
            {
                //only care about the day, nothing less - for grouping
                return new DateTime( StartDateTime.Year, StartDateTime.Month, StartDateTime.Day, 0, 0, 0 );
            }
        }

    }
}
