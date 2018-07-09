using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;
using TRec.BusinessLayer.DataLayer;

namespace TRec.BusinessLayer
{
    public static class OperationsReadWrite
    {
        public static List<ValidationMessage> SaveTimeEntry(
            ValidatableParameter<Guid> timeEntryId,
            ValidatableParameter<Guid> userId,
            ValidatableParameter<Guid> projectId,
            ValidatableParameter<Guid> taskId,
            ValidatableParameter<string> details,
            ValidatableParameter<DateTime?> startTime,
            ValidatableParameter<DateTime?> endTime,
            ValidatableParameter<int> exceptionMinutes,
            ValidatableParameter<string> exceptionDetail,
            out TimeEntry savedItem
            )
        {
            savedItem = null;

            List<ValidationMessage> errors = new List<ValidationMessage>();

            //check if user exists
            User usr = OperationsReadOnly.GetUser( userId.Value );
            if ( usr == null )
            {
                errors.Add( new ValidationMessage { MessageText = string.Format( "User with id '{0}' was not found", userId.Value.ToString() ), Source = userId.Source } );
            }
            else
            {
                //check if project exists
                if ( projectId.Value == Guid.Empty )
                {
                    errors.Add( new ValidationMessage { MessageText = string.Format( "Project must be selected" ), Source = projectId.Source } );
                }
                else if ( OperationsReadOnly.GetProjectForUser( projectId.Value, usr.UserId ) == null )
                {
                    //check if project exists for user
                    errors.Add( new ValidationMessage { MessageText = string.Format( "Project with id '{0}' is not associated with User '{1}'", projectId.Value.ToString(), userId.Value.ToString() ), Source = projectId.Source } );
                }

                //check if task exists
                if ( taskId.Value == Guid.Empty )
                {
                    errors.Add( new ValidationMessage { MessageText = string.Format( "Task must be selected" ), Source = taskId.Source } );
                }
                else if ( OperationsReadOnly.GetTaskById( taskId.Value, projectId.Value, usr.UserId ) == null )
                {
                    //check if project exists for user
                    errors.Add( new ValidationMessage { MessageText = string.Format( "Task with id '{0}' is not associated with Project '{1}' and/or User '{2}'", taskId.Value.ToString(), projectId.Value.ToString(), userId.Value.ToString() ), Source = taskId.Source } );
                }
            }

            //check dates
            if ( startTime.Value == null || !startTime.Value.HasValue )
            {
                errors.Add( new ValidationMessage { MessageText = string.Format( "Start time must be supplied" ), Source = startTime.Source } );
            }
            else if ( endTime.Value == null || !endTime.Value.HasValue )
            {
                errors.Add( new ValidationMessage { MessageText = string.Format( "End time was not supplied" ), Source = endTime.Source } );
            }
            else
            {
                //we have both dates, compare
                if ( startTime.Value >= endTime.Value )
                {
                    errors.Add( new ValidationMessage { MessageText = string.Format( "Start time must be before End time" ), Source = startTime.Source } );
                    errors.Add( new ValidationMessage { MessageText = string.Format( "End time must be after Start time" ), Source = endTime.Source } );
                }
                else
                {

                    //check for overlaps
                    List<TimeEntry> overlaps = OperationsReadOnly.GetTimeEntryForDateTimesRange( startTime.Value.Value, endTime.Value.Value, userId.Value );
                    if ( overlaps != null && overlaps.Count > 0 )
                    {
                        foreach ( TimeEntry currItem in overlaps )
                        {
                            if ( currItem.TimeEntryId != timeEntryId.Value )
                            {

                                if ( currItem.StartDateTime < startTime.Value.Value )
                                {
                                    errors.Add( new ValidationMessage { MessageText = string.Format( "Start time overlaps with another item, Project: {0}, Task: {1} with start time {2} and end time {3}", currItem.ProjectName, currItem.TaskName, currItem.StartDateTime.ToString( Constants.cstrDateFormatDisplay ), currItem.EndDateTime.ToString( Constants.cstrDateFormatDisplay ) ), Source = startTime.Source } );
                                }

                                if ( currItem.EndDateTime > endTime.Value.Value )
                                {
                                    errors.Add( new ValidationMessage { MessageText = string.Format( "End time overlaps with another item, Project: {0}, Task: {1} with start time {2} and end time {3}", currItem.ProjectName, currItem.TaskName, currItem.StartDateTime.ToString( Constants.cstrDateFormatDisplay ), currItem.EndDateTime.ToString( Constants.cstrDateFormatDisplay ) ), Source = endTime.Source } );
                                }

                            }

                        }
                    }

                    if ( exceptionMinutes.Value > 0 && exceptionDetail.Value.Trim().Length == 0 )
                    {
                        errors.Add( new ValidationMessage { MessageText = string.Format( "Subtract description text must be entered if period in minutes is to be recorded" ), Source = exceptionDetail.Source } );
                    }

                    //check for minutes empty but text not
                    if ( exceptionMinutes.Value <= 0 && exceptionDetail.Value.Trim().Length > 0 )
                    {
                        errors.Add( new ValidationMessage { MessageText = string.Format( "Subtract period in minutes must be entered if text is be recorded" ), Source = exceptionMinutes.Source } );
                    }

                    int timeDifferenceMinutes = Convert.ToInt32( endTime.Value.Value.Subtract( startTime.Value.Value ).TotalMinutes );
                    if ( exceptionMinutes.Value > timeDifferenceMinutes )
                    {
                        errors.Add( new ValidationMessage { MessageText = string.Format( "Subtract period in minutes must be less than the total number of minutes spent on the task" ), Source = exceptionMinutes.Source } );
                    }


                    //if ( exceptionEntries != null && exceptionEntries.Count > 0 )
                    //{
                    //    //we have both dates, we can check exceptions
                    //    int timeDifferenceMinutes = Convert.ToInt32( endTime.Value.Value.Subtract( startTime.Value.Value ).TotalMinutes );

                    //    bool hadOneGreater = false;
                    //    int totalExceptionMinutes = 0;

                    //    foreach ( ValidatableIntStringPair currEx in exceptionEntries )
                    //    {
                    //        //Check for text empty but minutes not
                    //        if ( currEx.IntValue.Value > 0 && currEx.StringValue.Value.Trim().Length == 0 )
                    //        {
                    //            errors.Add( new ValidationMessage { MessageText = string.Format( "Exception text must be entered if period in minutes is to be recorded" ), Source = currEx.StringValue.Source } );
                    //        }

                    //        //check for minutes empty but text not
                    //        if ( currEx.IntValue.Value <= 0 && currEx.StringValue.Value.Trim().Length > 0 )
                    //        {
                    //            errors.Add( new ValidationMessage { MessageText = string.Format( "Exception period in minutes must be entered if text is be recorded" ), Source = currEx.IntValue.Source } );
                    //        }

                    //        //check if any one is greater then the actual task number of minutes
                    //        if ( currEx.IntValue.Value > 0 && currEx.IntValue.Value > timeDifferenceMinutes )
                    //        {
                    //            errors.Add( new ValidationMessage { MessageText = string.Format( "An exception period must be less than than the total time spent on the task" ), Source = currEx.IntValue.Source } );
                    //            hadOneGreater = true;
                    //        }

                    //        if ( !hadOneGreater && ( currEx.IntValue.Value > 0 ) )
                    //        {
                    //            //if not one single one was greater than the tiem difference, check if the total minutes is greater 
                    //            //than the actual task number of minutes - If so attach error to it (any any after it)
                    //            totalExceptionMinutes += currEx.IntValue.Value;
                    //            if ( totalExceptionMinutes >= timeDifferenceMinutes )
                    //            {
                    //                errors.Add( new ValidationMessage { MessageText = string.Format( "The total exception period of all exceptions together must be less than the total time spent on the task" ), Source = currEx.IntValue.Source } );
                    //            }
                    //        }
                    //    }
                    //}
                }

            }

            if ( errors.Count == 0 )
            {
                AllTimeEntry dataItems = new AllTimeEntry();

                TimeEntry item = new TimeEntry { EndDateTime = endTime.Value.Value, Details = details.Value, ProjectId = projectId.Value, StartDateTime = startTime.Value.Value, TaskId = taskId.Value, TimeEntryId = timeEntryId.Value, UserId = userId.Value, ExceptionDetails = exceptionDetail.Value, ExceptionMinutes = exceptionMinutes.Value };
                if ( timeEntryId.Value != Guid.Empty )
                {
                    //update
                    TimeEntry updItem = dataItems.Where( i => i.TimeEntryId == item.TimeEntryId ).SingleOrDefault();

                    if ( updItem == null )
                    {
                        throw new ApplicationException( string.Format( "Time entry with id '{0}' not found", timeEntryId.Value.ToString() ) );
                    }
                    else
                    {
                        //save it
                        dataItems.Remove( updItem );
                        dataItems.Add( item );
                    }
                }
                else
                {
                    //add time entry
                    item.TimeEntryId = Guid.NewGuid();  //set id
                    dataItems.Add( item );
                }

                dataItems.Save();
                savedItem = item; //set the saved item
            }

            return errors;
        }

        /// <summary>
        /// TODO: Delete this when admin screens done!
        /// </summary>
        public static void TempInit()
        {
            AllProjects t3 = new AllProjects();
            if ( t3.Count == 0 )
            {
                t3.Add( new Project { Id = Guid.NewGuid(), Description = "Test Project", Active = true } );
                t3.Save();
            }

            AllTasks t1 = new AllTasks();
            if ( t1.Count == 0 )
            {
                t1.Add( new Task { Id = Guid.NewGuid(), ProjectId = t3[ 0 ].Id, Description = "Test Task 1", Active = true } );
                t1.Save();
            }

            AllUserTaskAccess t5 = new AllUserTaskAccess();
            if ( t5.Count == 0 )
            {
                t5.Add( new UserTaskAccess { ProjectId = t3[ 0 ].Id, TaskId = t1[ 0 ].Id, UserId = new AllUsers()[ 0 ].UserId } );
                t5.Save();
            }
        }

        public static List<ValidationMessage> SaveProject(
            ValidatableParameter<string> projectId,
            ValidatableParameter<string> details,
            ValidatableParameter<bool> active
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            Guid projId = Guid.Empty;
            try
            {
                projId = new Guid( projectId.Value );
            }
            catch ( FormatException )
            {
                errors.Add( new ValidationMessage { MessageText = "Project Id must be in the format dddddddd-dddd-dddd-dddd-dddddddddddd", Source = projectId.Source } );
            }

            if ( string.IsNullOrEmpty( details.Value ) || details.Value.Trim().Length == 0 )
            {
                errors.Add( new ValidationMessage { MessageText = "Project Name must be supplied", Source = details.Source } );
            }
            else
            {
                //check for existing name with different id (name already in use)
                Project existItem = AllProjects.GetForName( details.Value );
                if ( existItem != null && existItem.Id != projId )
                {
                    errors.Add( new ValidationMessage { MessageText = string.Format( "Project Name is already in use by project with Id {0}", existItem.Id.ToString() ), Source = details.Source } );
                }
            }

            //perform update if no errors
            if ( errors.Count == 0 )
            {
                AllProjects items = new AllProjects();
                Project newItem = new Project { Id = projId, Description = details.Value, Active = active.Value };
                if ( projId == Guid.Empty )
                {
                    newItem.Id = Guid.NewGuid(); //set id
                    items.Add( newItem );
                }
                else
                {
                    Project existItem = items.Where( i => i.Id == projId ).Single();
                    items.Remove( existItem );
                    items.Add( newItem );
                }

                items.Save();
            }

            return errors;
        }


        public static List<ValidationMessage> SaveTask(
            ValidatableParameter<string> projectId,
            ValidatableParameter<string> taskId,
            ValidatableParameter<string> details,
            ValidatableParameter<bool> active
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            Guid projId = Guid.Empty;
            Guid tskId = Guid.Empty;
            try
            {
                projId = new Guid( projectId.Value );
            }
            catch ( FormatException )
            {
                errors.Add( new ValidationMessage { MessageText = "Project Id must be in the format dddddddd-dddd-dddd-dddd-dddddddddddd", Source = projectId.Source } );
            }

            try
            {
                tskId = new Guid( taskId.Value );
            }
            catch ( FormatException )
            {
                errors.Add( new ValidationMessage { MessageText = "Task Id must be in the format dddddddd-dddd-dddd-dddd-dddddddddddd", Source = taskId.Source } );
            }

            if ( string.IsNullOrEmpty( details.Value ) || details.Value.Trim().Length == 0 )
            {
                errors.Add( new ValidationMessage { MessageText = "Task Name must be supplied", Source = details.Source } );
            }
            else
            {
                //check for existing name with different id (name already in use)
                Task existItem = AllTasks.GetForNameInProject( projId, details.Value );
                if ( existItem != null && existItem.Id != tskId )
                {
                    errors.Add( new ValidationMessage { MessageText = string.Format( "Task Name is already in use by project with Id {0}, Task Id in use is {1}", existItem.ProjectId.ToString(), existItem.Id.ToString() ), Source = details.Source } );
                }
            }

            //perform update if no errors
            if ( errors.Count == 0 )
            {
                AllTasks items = new AllTasks();
                Task newItem = new Task { Id = tskId, ProjectId = projId, Description = details.Value, Active = active.Value };
                if ( tskId == Guid.Empty )
                {
                    newItem.Id = Guid.NewGuid(); //set id
                    items.Add( newItem );
                }
                else
                {
                    Task existItem = items.Where( i => i.Id == tskId ).Single();
                    items.Remove( existItem );
                    items.Add( newItem );
                }

                items.Save();
            }

            return errors;
        }


        public static List<ValidationMessage> AddUserAccess(
            ValidatableParameter<string> projectId,
            ValidatableParameter<string> taskId,
            ValidatableParameter<Guid> userId
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            Guid projId = Guid.Empty;
            Guid tskId = Guid.Empty;
            try
            {
                projId = new Guid( projectId.Value );
            }
            catch ( FormatException )
            {
                errors.Add( new ValidationMessage { MessageText = "Project Id must be in the format dddddddd-dddd-dddd-dddd-dddddddddddd", Source = projectId.Source } );
            }

            try
            {
                tskId = new Guid( taskId.Value );
            }
            catch ( FormatException )
            {
                errors.Add( new ValidationMessage { MessageText = "Task Id must be in the format dddddddd-dddd-dddd-dddd-dddddddddddd", Source = taskId.Source } );
            }

            if ( userId.Value == Guid.Empty )
            {
                errors.Add( new ValidationMessage { MessageText = "User must be supplied", Source = userId.Source } );
            }
            else
            {
                //check for existing relationship
                UserTaskAccess existItem = AllUserTaskAccess.GetForUserAndProjectAndTask( userId.Value, projId, tskId );
                if ( existItem != null )
                {
                    errors.Add( new ValidationMessage { MessageText = string.Format( "User already has access to Task with Id {0}", existItem.TaskId.ToString() ), Source = userId.Source } );
                }
            }

            //perform add if no errors
            if ( errors.Count == 0 )
            {
                AllUserTaskAccess items = new AllUserTaskAccess();
                UserTaskAccess newItem = new UserTaskAccess { ProjectId = projId, TaskId = tskId, UserId = userId.Value };
                items.Add( newItem );

                items.Save();
            }

            return errors;
        }

        public static List<ValidationMessage> RemoveTimeEntry(
            ValidatableParameter<Guid> timeEntryId
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            if ( timeEntryId.Value == Guid.Empty )
            {
                errors.Add( new ValidationMessage { MessageText = "Time Entry must be supplied", Source = timeEntryId.Source } );
            }

            //perform add if no errors
            if ( errors.Count == 0 )
            {
                AllTimeEntry items = new AllTimeEntry();
                TimeEntry existItem = items.Where( i => i.TimeEntryId == timeEntryId.Value ).Single();

                if ( existItem != null )
                {
                    items.Remove( existItem );
                }

                items.Save();
            }

            return errors;
        }

        public static List<ValidationMessage> RemoveUserAccess(
            ValidatableParameter<string> projectId,
            ValidatableParameter<string> taskId,
            ValidatableParameter<Guid> userId
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            Guid projId = Guid.Empty;
            Guid tskId = Guid.Empty;
            try
            {
                projId = new Guid( projectId.Value );
            }
            catch ( FormatException )
            {
                errors.Add( new ValidationMessage { MessageText = "Project Id must be in the format dddddddd-dddd-dddd-dddd-dddddddddddd", Source = projectId.Source } );
            }

            try
            {
                tskId = new Guid( taskId.Value );
            }
            catch ( FormatException )
            {
                errors.Add( new ValidationMessage { MessageText = "Task Id must be in the format dddddddd-dddd-dddd-dddd-dddddddddddd", Source = taskId.Source } );
            }

            if ( userId.Value == Guid.Empty )
            {
                errors.Add( new ValidationMessage { MessageText = "User must be supplied", Source = userId.Source } );
            }
            else
            {
                //check for existing relationship
                UserTaskAccess existItem = AllUserTaskAccess.GetForUserAndProjectAndTask( userId.Value, projId, tskId );
                if ( existItem == null )
                {
                    errors.Add( new ValidationMessage { MessageText = string.Format( "User does not have access to Task with Id {0}", existItem.TaskId.ToString() ), Source = userId.Source } );
                }
            }

            //perform add if no errors
            if ( errors.Count == 0 )
            {
                AllUserTaskAccess items = new AllUserTaskAccess();
                UserTaskAccess existItem = items.Where( i => i.ProjectId == projId && i.TaskId == tskId && i.UserId == userId.Value ).Single();
                if ( existItem != null )
                {
                    items.Remove( existItem );
                }

                items.Save();
            }

            return errors;
        }

        public static List<ValidationMessage> SaveUserDetails(
            ValidatableParameter<Guid> userId,
            ValidatableParameter<string> userName,
            ValidatableParameter<string> displayName
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            if ( displayName == null || string.IsNullOrEmpty( displayName.Value ) || displayName.Value.Trim().Length == 0 )
            {
                errors.Add( new ValidationMessage { MessageText = "Display Name must be supplied", Source = displayName.Source } );
            }

            if ( errors.Count == 0 )
            {
                AllUsers items = new AllUsers();
                User existItem = items.Where( i => i.UserId == userId.Value ).Single();
                existItem.DisplayName = displayName.Value;

                items.Save();
            }

            return errors;
        }

        public static void SaveLocalSettings( LocalSettings item )
        {
            LocalSettingsStore updItem = new LocalSettingsStore();
            if ( item == null )
            {
                throw new ApplicationException( string.Format( "Invalid or missing 'LocalSettingsFile' at {0}", ConfigurationManager.AppSettings[Constants.cstrConfigKeyLocalSettingsFile] ) );
            }
            updItem.LastTimeEntryId = item.LastTimeEntryId;
            updItem.LastReminderPeriodInMilliseconds = item.LastReminderPeriodInMilliseconds;
            updItem.Save();
        }



        public static List<ValidationMessage> RemoveGoal(
            ValidatableParameter<Guid> goalId
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            if ( goalId.Value == Guid.Empty )
            {
                errors.Add( new ValidationMessage { MessageText = "Goal must be supplied", Source = goalId.Source } );
            }

            //perform add if no errors
            if ( errors.Count == 0 )
            {
                AllGoals items = new AllGoals();
                Goal existItem = items.Where( i => i.GoalId == goalId.Value ).Single();

                if ( existItem != null )
                {
                    items.Remove( existItem );
                }

                items.Save();
            }

            return errors;
        }

        public static List<ValidationMessage> SaveGoal(
            ValidatableParameter<Guid> goalId,
            ValidatableParameter<Guid> userId,
            ValidatableParameter<string> description,
            ValidatableParameter<string> targetMeasure,
            ValidatableParameter<DateTime> targetCompletionDate,
            ValidatableParameter<bool> isCompleted,
            ValidatableParameter<string> resultMeasure,
            ValidatableParameter<int> resultMeasureRating,
            ValidatableParameter<DateTime> resultCompletionDate,
            ValidatableParameter<int> resultCompletionDateRating,
            ValidatableParameter<string> positives,
            ValidatableParameter<string> improvements
            )
        {
            List<ValidationMessage> errors = new List<ValidationMessage>();

            if ( description == null || string.IsNullOrEmpty( description.Value ) || description.Value.Trim().Length == 0 )
            {
                errors.Add( new ValidationMessage { MessageText = "Description must be supplied", Source = description.Source } );
            }

            if ( errors.Count == 0 )
            {
                AllGoals items = new AllGoals();
                Goal existItem = new Goal();

                existItem.ActualCompletionDate = resultCompletionDate.Value;
                existItem.Completed = isCompleted.Value;
                existItem.Description = description.Value;
                existItem.GoalId = goalId.Value;
                existItem.Improvements = improvements.Value;
                existItem.Positives = positives.Value;
                existItem.ResultMeasure = resultMeasure.Value;
                existItem.ResultMeasureRating = resultMeasureRating.Value;
                existItem.ResultTimelinessRating = resultCompletionDateRating.Value;
                existItem.TargetCompletionDate = targetCompletionDate.Value;
                existItem.TargetMeasure = targetMeasure.Value;
                existItem.UserId = userId.Value;

                if ( existItem.GoalId == Guid.Empty )
                {
                    existItem.GoalId = Guid.NewGuid();
                    items.Add(existItem);
                }
                else
                {
                    Goal updItem = items.Where( i => i.GoalId == goalId.Value ).Single();
                    if ( updItem == null )
                    {
                        throw new ApplicationException( string.Format( "Goal with id '{0}' not found", goalId.Value.ToString() ) );
                    }
                    else
                    {
                        //save it
                        items.Remove( updItem );
                        items.Add( existItem );
                    }
                }

                items.Save();
            }

            return errors;
        }

    }
}
