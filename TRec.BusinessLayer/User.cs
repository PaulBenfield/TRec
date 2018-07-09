using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class User : IComparable<User>
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public DateTime ShiftDefaultStartTime { get; set; }

        public DateTime ShiftDefaultEndTime { get; set; }

        #region IComparable<User> Members

        public int CompareTo( User other )
        {
            return UserName.CompareTo( other.UserName );
        }

        #endregion
    }
}
