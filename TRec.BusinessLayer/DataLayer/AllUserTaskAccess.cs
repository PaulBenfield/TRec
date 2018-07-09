using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class AllUserTaskAccess : List<UserTaskAccess>
    {
        private bool m_IsLoaded = false;

        public AllUserTaskAccess()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserTaskAccessFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "UserTaskAccess" )
                            select new UserTaskAccess
                            {
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value )
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

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserTaskAccessFile ];

            if ( string.IsNullOrEmpty( filePath ) )
            {
                filePath = "UserTaskAccess.xml";
            }

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<UserProjectTask>" );
                    w.WriteLine( "</UserProjectTask>" );
                }
                finally
                {
                    w.Close();
                }
            }

            this.Sort();

            XElement xml = new XElement( "UserProjectTask",
                            from i in this
                            select new XElement( "UserTaskAccess",
                            new XElement( "UserId", i.UserId ),
                            new XElement( "ProjectId", i.ProjectId ),
                            new XElement( "TaskId", i.TaskId )
                            ), new XAttribute( "LastUpdatedOn", DateTime.Now ) );

            xml.Save( filePath );
        }

        public static List<Guid> GetProjectIdsForUser( Guid userId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserTaskAccessFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "UserTaskAccess" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            select new Guid( xElem.Element( "ProjectId" ).Value );

                return query.Distinct().ToList();
            }
            else
            {
                return new List<Guid>();
            }
        }

        public static List<Guid> GetTaskIdsForUserAndProject( Guid userId, Guid projectId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserTaskAccessFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "UserTaskAccess" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            && xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            select new Guid( xElem.Element( "TaskId" ).Value );

                return query.Distinct().ToList();
            }
            else
            {
                return new List<Guid>();
            }
        }

        public static UserTaskAccess GetForUserAndProjectAndTask( Guid userId, Guid projectId, Guid taskId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserTaskAccessFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "UserTaskAccess" )
                            where xElem.Element( "UserId" ).Value == userId.ToString()
                            && xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            && xElem.Element( "TaskId" ).Value == taskId.ToString()
                            select new UserTaskAccess
                            {
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                ProjectId = new Guid( xElem.Element( "ProjectId" ).Value ),
                                TaskId = new Guid( xElem.Element( "TaskId" ).Value )
                            };

                return query.SingleOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static List<Guid> GetUserIdsForProjectAndTask( Guid projectId, Guid taskId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserTaskAccessFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "UserTaskAccess" )
                            where xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            && xElem.Element( "TaskId" ).Value == taskId.ToString()
                            select new Guid( xElem.Element( "UserId" ).Value );

                return query.Distinct().ToList();
            }
            else
            {
                return new List<Guid>();
            }
        }
    }
}
