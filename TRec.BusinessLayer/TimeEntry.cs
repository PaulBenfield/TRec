using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class TimeEntry : IComparable<TimeEntry>
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

        internal string strProjectName { get; set; }

        public string ProjectName
        {
            get
            {
                if ( string.IsNullOrEmpty( strProjectName ) )
                {
                    Project item = OperationsReadOnly.GetProjectForUser( ProjectId, UserId );
                    strProjectName = item == null ? string.Empty : item.Description;
                }

                return strProjectName;
            }
        }

        internal string strTaskName { get; set; }

        public string TaskName
        {
            get
            {
                if ( string.IsNullOrEmpty( strTaskName ) )
                {
                    Task item = OperationsReadOnly.GetTaskById( TaskId, ProjectId, UserId );
                    strTaskName = item == null ? string.Empty : item.Description;
                }

                return strTaskName;
            }
        }

        public int TotalMinutesMinusExceptions
        {
            get
            {
                int totalMinutes = Convert.ToInt32( EndDateTime.Subtract( StartDateTime ).TotalMinutes );
                return totalMinutes - ExceptionMinutes;
            }
        }

        /// <summary>
        /// Returns an formatted hours:Mins representation of TotalMinutesMinusExceptions
        /// as a string
        /// </summary>
        public string TotalTimeAsTime
        {
            get
            {
                string strHours = (TotalMinutesMinusExceptions / 60).ToString();
                string strMins = (TotalMinutesMinusExceptions % 60).ToString();
                strMins = strMins.Length > 1 ? strMins : "0" + strMins;

                return strHours + ":" + strMins;
            }
        }

        #region IComparable<TimeEntry> Members

        public int CompareTo( TimeEntry other )
        {
            return StartDateTime.CompareTo( other.StartDateTime );
        }

        #endregion
    }
}
