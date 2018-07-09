using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class AllGoals : List<Goal>
    {
        private bool m_IsLoaded = false;

        public AllGoals()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyGoalsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Goal" )
                            select new Goal
                            {
                                GoalId = new Guid( xElem.Element( "GoalId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                TargetMeasure = xElem.Element( "TargetMeasure" ).Value,
                                TargetCompletionDate = DateTime.Parse( xElem.Element( "TargetCompletionDate" ).Value ),
                                Completed = bool.Parse( xElem.Element( "Completed" ).Value ),
                                ResultMeasure = xElem.Element( "ResultMeasure" ).Value,
                                ResultMeasureRating = int.Parse( xElem.Element( "ResultMeasureRating" ).Value ),
                                ActualCompletionDate = DateTime.Parse( xElem.Element( "ActualCompletionDate" ).Value ),
                                ResultTimelinessRating = int.Parse( xElem.Element( "ResultTimelinessRating" ).Value ),
                                Positives = xElem.Element( "Positives" ).Value,
                                Improvements = xElem.Element( "Improvements" ).Value
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

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyGoalsFile ];
            if ( string.IsNullOrEmpty( filePath ) )
            {
                filePath = "Goals.xml";
            }

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<Goals>" );
                    w.WriteLine( "</Goals>" );
                }
                finally
                {
                    w.Close();
                }
            }

            this.Sort();

            XElement xml = new XElement( "Goals",
                            from i in this
                            select new XElement( "Goal",
                            new XElement( "GoalId", i.GoalId ),
                            new XElement( "UserId", i.UserId ),
                            new XElement( "Description", i.Description ),
                            new XElement( "TargetMeasure", i.TargetMeasure ),
                            new XElement( "TargetCompletionDate", i.TargetCompletionDate ),
                            new XElement( "Completed", i.Completed ),
                            new XElement( "ResultMeasure", i.ResultMeasure ),
                            new XElement( "ResultMeasureRating", i.ResultMeasureRating ),
                            new XElement( "ActualCompletionDate", i.ActualCompletionDate ),
                            new XElement( "ResultTimelinessRating", i.ResultTimelinessRating ),
                            new XElement( "Positives", i.Positives ),
                            new XElement( "Improvements", i.Improvements )
                            ), new XAttribute( "LastUpdatedOn", DateTime.Now ) );

            xml.Save( filePath );
        }


        public static List<Goal> GetAllIncomplete()
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyGoalsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Goal" )
                            where string.Equals( xElem.Element( "Completed" ).Value, bool.FalseString, StringComparison.CurrentCultureIgnoreCase )
                            select new Goal
                            {
                                GoalId = new Guid( xElem.Element( "GoalId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                TargetMeasure = xElem.Element( "TargetMeasure" ).Value,
                                TargetCompletionDate = DateTime.Parse( xElem.Element( "TargetCompletionDate" ).Value ),
                                Completed = bool.Parse( xElem.Element( "Completed" ).Value ),
                                ResultMeasure = xElem.Element( "ResultMeasure" ).Value,
                                ResultMeasureRating = int.Parse( xElem.Element( "ResultMeasureRating" ).Value ),
                                ActualCompletionDate = DateTime.Parse( xElem.Element( "ActualCompletionDate" ).Value ),
                                ResultTimelinessRating = int.Parse( xElem.Element( "ResultTimelinessRating" ).Value ),
                                Positives = xElem.Element( "Positives" ).Value,
                                Improvements = xElem.Element( "Improvements" ).Value
                            };

                List<Goal> results = query.ToList();
                results.Sort();
                return results;
            }
            else
            {
                return new List<Goal>();
            }
        }

        public static List<Goal> GetAllComplete()
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyGoalsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Goal" )
                            where string.Equals( xElem.Element( "Completed" ).Value, bool.TrueString, StringComparison.CurrentCultureIgnoreCase )
                            select new Goal
                            {
                                GoalId = new Guid( xElem.Element( "GoalId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                TargetMeasure = xElem.Element( "TargetMeasure" ).Value,
                                TargetCompletionDate = DateTime.Parse( xElem.Element( "TargetCompletionDate" ).Value ),
                                Completed = bool.Parse( xElem.Element( "Completed" ).Value ),
                                ResultMeasure = xElem.Element( "ResultMeasure" ).Value,
                                ResultMeasureRating = int.Parse( xElem.Element( "ResultMeasureRating" ).Value ),
                                ActualCompletionDate = DateTime.Parse( xElem.Element( "ActualCompletionDate" ).Value ),
                                ResultTimelinessRating = int.Parse( xElem.Element( "ResultTimelinessRating" ).Value ),
                                Positives = xElem.Element( "Positives" ).Value,
                                Improvements = xElem.Element( "Improvements" ).Value
                            };

                List<Goal> results = query.ToList();
                results.Sort();
                return results;
            }
            else
            {
                return new List<Goal>();
            }
        }

        public static List<Goal> GetAllCompleteBetween( string filePath, DateTime startDate, DateTime endDate )
        {
            DateTime minDate = new DateTime( startDate.Year, startDate.Month, startDate.Day );
            DateTime maxDate = new DateTime( endDate.Year, endDate.Month, endDate.Day );

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Goal" )
                            where string.Equals( xElem.Element( "Completed" ).Value, bool.TrueString, StringComparison.CurrentCultureIgnoreCase )
                            && ( ( DateTime.Parse( xElem.Element( "ActualCompletionDate" ).Value ) >= minDate ) && ( DateTime.Parse( xElem.Element( "ActualCompletionDate" ).Value ) <= maxDate ) )
                            select new Goal
                            {
                                GoalId = new Guid( xElem.Element( "GoalId" ).Value ),
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                TargetMeasure = xElem.Element( "TargetMeasure" ).Value,
                                TargetCompletionDate = DateTime.Parse( xElem.Element( "TargetCompletionDate" ).Value ),
                                Completed = bool.Parse( xElem.Element( "Completed" ).Value ),
                                ResultMeasure = xElem.Element( "ResultMeasure" ).Value,
                                ResultMeasureRating = int.Parse( xElem.Element( "ResultMeasureRating" ).Value ),
                                ActualCompletionDate = DateTime.Parse( xElem.Element( "ActualCompletionDate" ).Value ),
                                ResultTimelinessRating = int.Parse( xElem.Element( "ResultTimelinessRating" ).Value ),
                                Positives = xElem.Element( "Positives" ).Value,
                                Improvements = xElem.Element( "Improvements" ).Value
                            };

                List<Goal> results = query.ToList();
                results.Sort();
                return results;
            }
            else
            {
                return new List<Goal>();
            }
        }

    }
}
