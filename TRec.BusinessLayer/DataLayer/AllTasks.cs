using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class AllTasks : List<Task>
    {
        private bool m_IsLoaded = false;

        public AllTasks()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTasksFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Task" )
                            orderby xElem.Element( "Description" ).Value
                            select new Task
                            {
                                Id = new Guid( xElem.Element( "TaskId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
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

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTasksFile ];

            if ( string.IsNullOrEmpty( filePath ) )
            {
                filePath = "Tasks.xml";
            }

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<Tasks>" );
                    w.WriteLine( "</Tasks>" );
                }
                finally
                {
                    w.Close();
                }
            }

            this.Sort();

            XElement xml = new XElement( "Tasks",
                            from i in this
                            select new XElement( "Task",
                            new XElement( "TaskId", i.Id ),
                            new XElement( "Description", i.Description ),
                            new XElement( "ProjectId", i.ProjectId ),
                            new XElement( "Active", i.Active ? "1" : "0" )
                            ), new XAttribute( "LastUpdatedOn", DateTime.Now ) );

            xml.Save( filePath );
        }

        public static Task GetForId( Guid taskId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTasksFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Task" )
                            where xElem.Element( "TaskId" ).Value == taskId.ToString()
                            select new Task
                            {
                                Id = new Guid( xElem.Element( "TaskId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
                            };

                return query.SingleOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static List<Task> GetForUserAndProject( Guid userId, Guid projectId, bool activeOnly )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTasksFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Task" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            && xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            && ( activeOnly ? xElem.Element( "Active" ).Value == "1" : true )
                            orderby xElem.Element( "Description" ).Value
                            select new Task
                            {
                                Id = new Guid( xElem.Element( "TaskId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
                            };

                return query.ToList();
            }
            else
            {
                return null;
            }
        }

        public static List<Task> GetForProject( Guid projectId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTasksFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Task" )
                            where xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            orderby xElem.Element( "Description" ).Value
                            select new Task
                            {
                                Id = new Guid( xElem.Element( "TaskId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
                            };

                return query.ToList();
            }
            else
            {
                return null;
            }
        }

        public static Task GetForNameInProject( Guid projectId, string taskName )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTasksFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Task" )
                            where xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            && string.Equals( xElem.Element( "Description" ).Value, taskName, StringComparison.CurrentCultureIgnoreCase )
                            select new Task
                            {
                                Id = new Guid( xElem.Element( "TaskId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
                            };

                return query.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static Task GetForIdAndProject( Guid taskId, Guid projectId, bool activeOnly )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTasksFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Task" )
                            where xElem.Element( "TaskId" ).Value == taskId.ToString()
                            && xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            && ( activeOnly ? xElem.Element( "Active" ).Value == "1" : true )
                            select new Task
                            {
                                Id = new Guid( xElem.Element( "TaskId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
                            };

                return query.SingleOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
