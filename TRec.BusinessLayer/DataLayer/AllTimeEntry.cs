using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class AllTimeEntry : List<TimeEntry>
    {
        private bool m_IsLoaded = false;

        public AllTimeEntry()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Entry" )
                            select new TimeEntry
                            {
                                TimeEntryId = new Guid( xElem.Element( "EntryId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value ),
                                Details = xElem.Element( "Details" ).Value,
                                StartDateTime = DateTime.Parse( xElem.Element( "Start" ).Value ),
                                EndDateTime = DateTime.Parse( xElem.Element( "End" ).Value ),
                                ExceptionMinutes = Convert.ToInt32( xElem.Element( "ExcMins" ).Value ),
                                ExceptionDetails = xElem.Element( "ExcDetails" ).Value
                            };

                this.Clear();
                AddRange( query );
            }
        }



        public void Save()
        {
            if ( !m_IsLoaded )
            {
                Reload();
            }

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];

            if ( string.IsNullOrEmpty( filePath ) )
            {
                filePath = "TimeEntry.xml";
            }

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<TimeEntries>" );
                    w.WriteLine( "</TimeEntries>" );
                }
                finally
                {
                    w.Close();
                }
            }

            this.Sort();

            XElement xml = new XElement( "TimeEntries",
                            from i in this
                            select new XElement( "Entry",
                            new XElement( "EntryId", i.TimeEntryId ),
                            new XElement( "UserId", i.UserId ),
                            new XElement( "ProjectId", i.ProjectId ),
                            new XElement( "TaskId", i.TaskId ),
                            new XElement( "Details", i.Details ),
                            new XElement( "Start", i.StartDateTime ),
                            new XElement( "End", i.EndDateTime ),
                            new XElement( "ExcMins", i.ExceptionMinutes ),
                            new XElement( "ExcDetails", i.ExceptionDetails )
                            ), new XAttribute( "LastUpdatedOn", DateTime.Now ) );

            xml.Save( filePath );
        }

        public static List<TimeEntry> GetForUserRecentReverse( Guid userId, int maxNumber )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Entry" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            select new TimeEntry
                            {
                                TimeEntryId = new Guid( xElem.Element( "EntryId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value ),
                                Details = xElem.Element( "Details" ).Value,
                                StartDateTime = DateTime.Parse( xElem.Element( "Start" ).Value ),
                                EndDateTime = DateTime.Parse( xElem.Element( "End" ).Value ),
                                ExceptionMinutes = Convert.ToInt32( xElem.Element( "ExcMins" ).Value ),
                                ExceptionDetails = xElem.Element( "ExcDetails" ).Value
                            };
                List<TimeEntry> results = query.ToList();
                results.Sort();
                results.Reverse();
                return new List<TimeEntry>( results.Take<TimeEntry>( maxNumber ) );
            }
            else
            {
                return new List<TimeEntry>();
            }
        }

        public static List<TimeEntry> GetForUserAndDateReverse( Guid userId, DateTime dte )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];

            DateTime minDate = new DateTime( dte.Year, dte.Month, dte.Day );
            DateTime maxDate = minDate.AddDays( 1 );

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Entry" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            && ( ( DateTime.Parse( xElem.Element( "End" ).Value ) >= minDate && DateTime.Parse( xElem.Element( "End" ).Value ) < maxDate )
                            || ( DateTime.Parse( xElem.Element( "Start" ).Value ) >= minDate && DateTime.Parse( xElem.Element( "Start" ).Value ) < maxDate )
                            || ( DateTime.Parse( xElem.Element( "Start" ).Value ) <= minDate && DateTime.Parse( xElem.Element( "End" ).Value ) >= maxDate ) )
                            select new TimeEntry
                            {
                                TimeEntryId = new Guid( xElem.Element( "EntryId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value ),
                                Details = xElem.Element( "Details" ).Value,
                                StartDateTime = DateTime.Parse( xElem.Element( "Start" ).Value ),
                                EndDateTime = DateTime.Parse( xElem.Element( "End" ).Value ),
                                ExceptionMinutes = Convert.ToInt32( xElem.Element( "ExcMins" ).Value ),
                                ExceptionDetails = xElem.Element( "ExcDetails" ).Value
                            };

                List<TimeEntry> results = query.ToList();
                results.Sort();
                results.Reverse();
                return results;
            }
            else
            {
                return new List<TimeEntry>();
            }
        }

        public static TimeEntry GetLatestForUser( Guid userId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Entry" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            select new TimeEntry
                            {
                                TimeEntryId = new Guid( xElem.Element( "EntryId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value ),
                                Details = xElem.Element( "Details" ).Value,
                                StartDateTime = DateTime.Parse( xElem.Element( "Start" ).Value ),
                                EndDateTime = DateTime.Parse( xElem.Element( "End" ).Value ),
                                ExceptionMinutes = Convert.ToInt32( xElem.Element( "ExcMins" ).Value ),
                                ExceptionDetails = xElem.Element( "ExcDetails" ).Value
                            };

                return query.LastOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static TimeEntry GetEntryByIdForUser( Guid userId, Guid timeEntryId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Entry" )
                            where xElem.Element( "EntryId" ).Value == timeEntryId.ToString()
                            && xElem.Element( "UserId" ).Value == userId.ToString()
                            select new TimeEntry
                            {
                                TimeEntryId = new Guid( xElem.Element( "EntryId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value ),
                                Details = xElem.Element( "Details" ).Value,
                                StartDateTime = DateTime.Parse( xElem.Element( "Start" ).Value ),
                                EndDateTime = DateTime.Parse( xElem.Element( "End" ).Value ),
                                ExceptionMinutes = Convert.ToInt32( xElem.Element( "ExcMins" ).Value ),
                                ExceptionDetails = xElem.Element( "ExcDetails" ).Value
                            };

                return query.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static List<TimeEntry> GetForUserAndBetween( Guid userId, DateTime start, DateTime end, bool ignoreTime )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryFile ];

            if ( File.Exists( filePath ) )
            {
                DateTime minDate = ignoreTime ? new DateTime( start.Year, start.Month, start.Day ) : start;
                DateTime maxDate = ignoreTime ? new DateTime( end.Year, end.Month, end.Day ).AddDays( 1 ) : end;

                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Entry" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            && ( ( DateTime.Parse( xElem.Element( "End" ).Value ) > minDate && DateTime.Parse( xElem.Element( "End" ).Value ) < maxDate )
                            || ( DateTime.Parse( xElem.Element( "Start" ).Value ) > minDate && DateTime.Parse( xElem.Element( "Start" ).Value ) < maxDate )
                            || ( DateTime.Parse( xElem.Element( "Start" ).Value ) < minDate && DateTime.Parse( xElem.Element( "End" ).Value ) > maxDate ) )
                            select new TimeEntry
                            {
                                TimeEntryId = new Guid( xElem.Element( "EntryId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value ),
                                Details = xElem.Element( "Details" ).Value,
                                StartDateTime = DateTime.Parse( xElem.Element( "Start" ).Value ),
                                EndDateTime = DateTime.Parse( xElem.Element( "End" ).Value ),
                                ExceptionMinutes = Convert.ToInt32( xElem.Element( "ExcMins" ).Value ),
                                ExceptionDetails = xElem.Element( "ExcDetails" ).Value
                            };

                List<TimeEntry> results = query.ToList();
                results.Sort();
                return results;
            }
            else
            {
                return new List<TimeEntry>();
            }
        }

        public static List<TimeEntry> GetBetween( DateTime start, DateTime end, bool ignoreTime, string fileName )
        {
            string filePath = fileName;

            if ( File.Exists( filePath ) )
            {
                DateTime minDate = ignoreTime ? new DateTime( start.Year, start.Month, start.Day ) : start;
                DateTime maxDate = ignoreTime ? new DateTime( end.Year, end.Month, end.Day ).AddDays( 1 ) : end;

                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Entry" )
                            where ( ( DateTime.Parse( xElem.Element( "End" ).Value ) > minDate && DateTime.Parse( xElem.Element( "End" ).Value ) < maxDate )
                            || ( DateTime.Parse( xElem.Element( "Start" ).Value ) > minDate && DateTime.Parse( xElem.Element( "Start" ).Value ) < maxDate )
                            || ( DateTime.Parse( xElem.Element( "Start" ).Value ) < minDate && DateTime.Parse( xElem.Element( "End" ).Value ) > maxDate ) )
                            select new TimeEntry
                            {
                                TimeEntryId = new Guid( xElem.Element( "EntryId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value ),
                                Details = xElem.Element( "Details" ).Value,
                                StartDateTime = DateTime.Parse( xElem.Element( "Start" ).Value ),
                                EndDateTime = DateTime.Parse( xElem.Element( "End" ).Value ),
                                ExceptionMinutes = Convert.ToInt32( xElem.Element( "ExcMins" ).Value ),
                                ExceptionDetails = xElem.Element( "ExcDetails" ).Value
                            };

                List<TimeEntry> results = query.ToList();
                results.Sort();
                return results;
            }
            else
            {
                return new List<TimeEntry>();
            }
        }
    }
}
