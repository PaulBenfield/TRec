using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class Task : IComparable<Task>
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        #region IComparable<Task> Members

        public int CompareTo( Task other )
        {
            return Description.CompareTo( other.Description );
        }

        #endregion
    }
}
