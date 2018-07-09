using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{

    public class Project : IComparable<Project>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        #region IComparable<Project> Members

        public int CompareTo( Project other )
        {
            return Description.CompareTo( other.Description );
        }

        #endregion

    }
}
