using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer.DataLayer
{
    internal class UserTaskAccess : IComparable<UserTaskAccess>
    {
        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public Guid TaskId { get; set; }


        #region IComparable<UserTaskAccess> Members

        public int CompareTo( UserTaskAccess other )
        {
            int result = 0;
            result = UserId.CompareTo( other.UserId );
            if ( result == 0 )
            {
                result = ProjectId.CompareTo( other.ProjectId );
            }
            if ( result == 0 )
            {
                result = TaskId.CompareTo( other.TaskId );
            }
            return result;
        }

        #endregion
    }
}
