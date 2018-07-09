using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public static class Constants
    {
        public const string cstrConfigKeyProjectsFile = "ProjectsFile";
        public const string cstrConfigKeyUserFile = "UserFile";
        public const string cstrConfigKeyUserTaskAccessFile = "UserTaskAccessFile";
        public const string cstrConfigKeyTasksFile = "TasksFile";
        public const string cstrConfigKeyTimeEntryFile = "TimeEntryFile";
        public const string cstrConfigKeyGoalsFile = "GoalsFile";
        public const string cstrConfigKeyLocalSettingsFile = "LocalSettingsFile";
        public const string cstrConfigKeyStandardStartTime = "2000-01-01 08:00:00 AM";
        public const string cstrConfigKeyStandardEndTime = "2000-01-01 16:00:00 PM";

        public const string cstrDateFormatDisplay = "HH:mm (dd MMM)";

        public enum AccessLevel
        {
            Any = 1,
            User = 2,
            GroupAdmin = 3,
            GlobalAdmin = 4
        }

    }
}
