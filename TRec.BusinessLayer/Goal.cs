using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class Goal : IComparable<Goal>
    {
        public Guid GoalId { get; set; }

        public Guid UserId { get; set; }

        public string Description { get; set; }

        public string TargetMeasure { get; set; }

        public DateTime TargetCompletionDate { get; set; }

        public bool Completed { get; set; }

        public string ResultMeasure { get; set; }

        public int ResultMeasureRating { get; set; }

        public DateTime ActualCompletionDate { get; set; }

        public int ResultTimelinessRating { get; set; }

        public string Positives { get; set; }

        public string Improvements { get; set; }


        #region IComparable<Goal> Members

        public int CompareTo( Goal other )
        {
            return TargetCompletionDate.CompareTo( other.TargetCompletionDate );
        }

        #endregion
    }
}
