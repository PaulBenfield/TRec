using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

using TRec.BusinessLayer.DataLayer;
using System.ComponentModel;

namespace TRec.BusinessLayer
{
    [DataObject]
    public static class OperationsReadOnly
    {

        /// <summary>
        /// Get the User object for the current identity
        /// </summary>
        /// <param name="usr">The identity of the user</param>
        /// <returns>Populated User if it exists, otherwise null</returns>
        public static User CreateOrGetUser( IIdentity usr )
        {
            AllUsers items = new AllUsers();
            User item = null;
            try
            {
                item = items.Where( i => String.Equals( i.UserName, usr.Name, StringComparison.CurrentCultureIgnoreCase ) ).SingleOrDefault();
            }
            catch ( InvalidOperationException ex )
            {
                throw new Exceptions.UIMessageException( string.Format( "Corrupt Data: Multiple User records with User Name '{0}' found.", usr.Name ), ex );
            }

            if ( item == null )
            {
                item = new User { UserId = Guid.NewGuid(), UserName = usr.Name, DisplayName = usr.Name, ShiftDefaultStartTime = System.Convert.ToDateTime( Constants.cstrConfigKeyStandardStartTime ), ShiftDefaultEndTime = System.Convert.ToDateTime( Constants.cstrConfigKeyStandardEndTime ) };
                items.Add( item );
                items.Save();
            }
            return item;
        }

        /// <summary>
        /// Get the User object for the id
        /// </summary>
        /// <param name="userId">The internal system id of the user</param>
        /// <returns>Populated User if it exists, otherwise null</returns>
        public static User GetUser( Guid userId )
        {
            AllUsers items = new AllUsers();
            User item = null;
            try
            {
                item = items.Where( i => i.UserId == userId ).SingleOrDefault();
            }
            catch ( InvalidOperationException ex )
            {
                throw new Exceptions.UIMessageException( string.Format( "Corrupt Data: Multiple User records with User Id '{0}' found.", userId.ToString() ), ex );
            }

            return item;
        }

        /// <summary>
        /// Get the User object for the name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static User GetUser( string userName )
        {
            AllUsers items = new AllUsers();
            User item = null;
            try
            {
                item = items.Where( i => String.Equals( i.UserName, userName, StringComparison.CurrentCultureIgnoreCase ) ).SingleOrDefault();
            }
            catch ( InvalidOperationException ex )
            {
                throw new Exceptions.UIMessageException( string.Format( "Corrupt Data: Multiple User records with User Name '{0}' found.", userName ), ex );
            }

            return item;
        }

        /// <summary>
        /// Gets the list of projects for a user
        /// </summary>
        /// <param name="usr">The user with access to the projects</param>
        /// <param name="activeOnly">Indicator of active projects or not</param>
        /// <returns>Populated List of Projects if there are any, otherwise an empty list<Project></returns>
        public static List<Project> GetProjectsForUser( Guid userId, bool activeOnly )
        {
            List<Project> items = new List<Project>();

            foreach ( Guid currItem in AllUserTaskAccess.GetProjectIdsForUser( userId ) )
            {
                Project currProj = AllProjects.GetForId( currItem, activeOnly );

                if ( currProj != null )
                {
                    items.Add( currProj );
                }
            }

            items.Sort();
            return items;
        }

        /// <summary>
        /// Gets the list of tasks for a project and a user
        /// </summary>
        /// <param name="projectId">The project which the tasks belong to</param>
        /// <param name="userId">The user with access to the tasks</param>
        /// <param name="activeOnly">Indicator of active tasks or not</param>
        /// <returns>Populated list of tasks if there are any, otherwise an empty list</returns>
        public static List<Task> GetTasksForProjectAndUser( Guid projectId, Guid userId, bool activeOnly )
        {
            List<Task> items = new List<Task>();

            foreach ( Guid currItem in AllUserTaskAccess.GetTaskIdsForUserAndProject( userId, projectId ) )
            {
                Task currTask = AllTasks.GetForIdAndProject( currItem, projectId, activeOnly );

                if ( currTask != null )
                {
                    items.Add( currTask );
                }
            }

            items.Sort();
            return items;
        }

        public static Task GetTaskById( Guid taskId, Guid projectId, Guid userId )
        {
            Task item = null;
            UserTaskAccess access = AllUserTaskAccess.GetForUserAndProjectAndTask( userId, projectId, taskId );

            //check if user has access to this task, if so, retrieve it
            if ( access != null )
            {
                item = AllTasks.GetForId( taskId );
            }

            return item;
        }

        public static List<TimeEntry> GetRecentTimeEntry( int maxNumber, User usr )
        {
            return AllTimeEntry.GetForUserRecentReverse( usr.UserId, maxNumber );
        }

        public static List<TimeEntry> GetTimeEntryForDate( DateTime selectedDate, User usr )
        {
            return AllTimeEntry.GetForUserAndDateReverse( usr.UserId, selectedDate );
        }

        public static List<TimeEntry> GetTimeEntryForDateRange( DateTime startDate, DateTime endDate, User usr )
        {
            return AllTimeEntry.GetForUserAndBetween( usr.UserId, startDate, endDate, true );
        }

        //public static List<TimeEntry> GetTimeEntryForDateRange( DateTime startDate, DateTime endDate, string fileName )
        //{
        //    return AllTimeEntry.GetBetween( startDate, endDate, true, fileName );
        //}

        [DataObjectMethod( DataObjectMethodType.Select )]
        public static List<ReportingItemSummary> GetReportingItems( DateTime startDate, DateTime endDate, IEnumerable<string> fileNames )
        {
            //get all projects, tasks and users for efficiency (rather than looking each one up from file each time)
            List<Project> projs = OperationsReadOnly.GetAllProjects();
            List<Task> tasks = OperationsReadOnly.GetAllTasks();
            List<User> users = OperationsReadOnly.GetAllUsers();

            List<ReportingItemSummary> results = new List<ReportingItemSummary>();

            foreach ( string currFile in fileNames )
            {
                List<TimeEntry> entries = AllTimeEntry.GetBetween( startDate, endDate, true, currFile );

                foreach ( TimeEntry currEntry in entries )
                {
                    ReportingItemSummary item = new ReportingItemSummary();
                    item.Details = currEntry.Details;
                    item.EndDateTime = currEntry.EndDateTime;
                    item.ExceptionDetails = currEntry.ExceptionDetails;
                    item.ExceptionMinutes = currEntry.ExceptionMinutes;
                    item.ProjectId = currEntry.ProjectId;
                    Project prj = projs.Where( i => i.Id == currEntry.ProjectId ).FirstOrDefault();
                    item.ProjectName = prj == null ? string.Empty : prj.Description;
                    item.StartDateTime = currEntry.StartDateTime;
                    item.TaskId = currEntry.TaskId;
                    Task tsk = tasks.Where( i => i.Id == currEntry.TaskId ).FirstOrDefault();
                    item.TaskName = tsk == null ? string.Empty : tsk.Description;
                    item.TimeEntryId = currEntry.TimeEntryId;
                    item.TotalMinutes = currEntry.TotalMinutesMinusExceptions;
                    User usr = users.Where( i => i.UserId == currEntry.UserId ).FirstOrDefault();
                    item.UserDisplayName = usr == null ? string.Empty : usr.DisplayName;
                    item.UserId = currEntry.UserId;

                    results.Add( item );
                }
            }

            return results;

        }

        [DataObjectMethod( DataObjectMethodType.Select )]
        public static List<ReportingGoalSummary> GetReportingGoals( DateTime startDate, DateTime endDate, IEnumerable<string> fileNames )
        {
            //get all users for efficiency (rather than looking each one up from file each time)
            List<User> users = OperationsReadOnly.GetAllUsers();

            List<ReportingGoalSummary> results = new List<ReportingGoalSummary>();

            foreach ( string currFile in fileNames )
            {
                List<Goal> entries = AllGoals.GetAllCompleteBetween( currFile, startDate, endDate );

                foreach ( Goal currEntry in entries )
                {
                    ReportingGoalSummary item = new ReportingGoalSummary();

                    item.ActualCompletionDate = currEntry.ActualCompletionDate;
                    item.Completed = currEntry.Completed;
                    item.Description = currEntry.Description;
                    item.GoalId = currEntry.GoalId;
                    item.Improvements = currEntry.Improvements;
                    item.Positives = currEntry.Positives;
                    item.ResultMeasure = currEntry.ResultMeasure;
                    item.ResultMeasureRating = currEntry.ResultMeasureRating;
                    item.ResultTimelinessRating = currEntry.ResultTimelinessRating;
                    item.TargetCompletionDate = currEntry.TargetCompletionDate;
                    item.TargetMeasure = currEntry.TargetMeasure;
                    User usr = users.Where( i => i.UserId == currEntry.UserId ).FirstOrDefault();
                    item.UserDisplayName = usr == null ? string.Empty : usr.DisplayName;
                    item.UserId = currEntry.UserId;

                    results.Add( item );
                }
            }

            return results;

        }

        public static List<TimeEntry> GetTimeEntryForDateTimesRange( DateTime startDate, DateTime endDate, Guid userId )
        {
            return AllTimeEntry.GetForUserAndBetween( userId, startDate, endDate, false );
        }

        public static TimeEntry GetLatestTimeEntry( User usr )
        {
            return AllTimeEntry.GetLatestForUser( usr.UserId );
        }

        public static TimeEntry GetTimeEntryById( Guid timeEntryId, User usr )
        {
            return AllTimeEntry.GetEntryByIdForUser( usr.UserId, timeEntryId );
        }

        public static Project GetProjectForUser( Guid projectId, Guid userId )
        {
            Project item = null;

            List<Guid> access = AllUserTaskAccess.GetTaskIdsForUserAndProject( userId, projectId );

            //check if user has access to this project, if so, retrieve it
            if ( access != null && access.Count > 0 )
            {
                item = AllProjects.GetForId( projectId, false );
            }

            return item;
        }

        public static List<User> GetAllUsers()
        {
            return new AllUsers();
        }

        public static List<Project> GetAllProjects()
        {
            return new AllProjects();
        }

        public static List<Task> GetAllTasksForProject( Guid projectId )
        {
            return AllTasks.GetForProject( projectId );
        }

        public static List<Task> GetAllTasks()
        {
            return new AllTasks();
        }

        public static List<User> GetAllUsersForTask( Guid projectId, Guid taskId )
        {
            List<Guid> userIds = AllUserTaskAccess.GetUserIdsForProjectAndTask( projectId, taskId );
            if ( userIds != null && userIds.Count > 0 )
            {
                return AllUsers.GetUsers( userIds );
            }
            else
            {
                return new List<User>();
            }
        }

        public static List<TimeEntry> GetAllTimeEntry()
        {
            AllTimeEntry entries = new AllTimeEntry();
            return entries;
        }

        public static LocalSettings GetLocalSettings()
        {
            LocalSettings item = new LocalSettingsStore();
            if ( item == null )
            {
                item = new LocalSettings();
                item.LastTimeEntryId = Guid.Empty;
            }
            return item;
        }

        public static List<Goal> GetAllGoals( bool completeOnly )
        {
            if ( completeOnly )
            {
                return AllGoals.GetAllComplete();
            }
            else
            {
                return AllGoals.GetAllIncomplete();
            }
        }

        public static DateTime RoundToMinute( DateTime item )
        {
            return new DateTime( item.Year, item.Month, item.Day, item.Hour, item.Minute, 0 );
        }

    }
}
