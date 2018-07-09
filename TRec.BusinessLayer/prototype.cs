using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    /// <summary>
    /// NOTE: This class will be deleted once there is a database!
    /// </summary>
    internal static class prototype
    {
        private static bool m_bHasDummyDataBeenGenerated = false;

        /// <summary>
        /// Generates dummy data for the prototype if it has not already been generated
        /// </summary>
        public static void GenerateDummyData()
        {
            if ( !m_bHasDummyDataBeenGenerated )
            {
                //add the logged in user
                AllUsers = new List<User>();
                System.Security.Principal.IIdentity usr = System.Security.Principal.WindowsIdentity.GetCurrent();
                AllUsers.Add( new User { UserId = Guid.NewGuid(), UserName = usr.Name, DisplayName = usr.Name } );


                //instanciate time entries
                AllTimeEntries = new List<TimeEntry>();
                AllTimeEntryExceptions = new List<TimeEntryException>();


                //set it to true as it has now been done
                m_bHasDummyDataBeenGenerated = true;
            }
        }

        public static List<User> AllUsers { get; set; }


        public static List<TimeEntry> AllTimeEntries { get; set; }

        public static List<TimeEntryException> AllTimeEntryExceptions { get; set; }

    }
}
