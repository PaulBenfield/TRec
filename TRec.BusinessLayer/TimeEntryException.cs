using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class TimeEntryException : IComparable<TimeEntryException>
    {
        public Guid TimeEntryExceptionId { get; set; }

        public Guid TimeEntryId { get; set; }

        public int NumberOfMinutes { get; set; }

        public string ExceptionText { get; set; }


        #region IComparable<TimeEntryException> Members

        public int CompareTo( TimeEntryException other )
        {
            return TimeEntryId.CompareTo( other.TimeEntryId );
        }

        #endregion
    }
}
