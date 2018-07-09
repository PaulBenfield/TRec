using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class AllProjects : List<Project>
    {
        private bool m_IsLoaded = false;

        private string m_xmlFile = Constants.cstrConfigKeyProjectsFile;

        public AllProjects()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ m_xmlFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Project" )
                            orderby xElem.Element( "Description" ).Value
                            select new Project
                            {
                                Id = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
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

            string filePath = ConfigurationManager.AppSettings[ m_xmlFile ];

            if ( string.IsNullOrEmpty( filePath ) )
            {
                filePath = "Projects.xml";
            }

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<Projects>" );
                    w.WriteLine( "</Projects>" );
                }
                finally
                {
                    w.Close();
                }
            }

            this.Sort();

            XElement xml = new XElement( "Projects",
                            from i in this
                            select new XElement( "Project",
                            new XElement( "ProjectId", i.Id ),
                            new XElement( "Description", i.Description ),
                            new XElement( "Active", i.Active ? "1" : "0" )
                            ), new XAttribute( "LastUpdatedOn", DateTime.Now ) );

            xml.Save( filePath );
        }

        public static DateTime GetLastUpdatedOn()
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyProjectsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Projects" )
                            select DateTime.Parse( xElem.Attribute( "LastUpdatedOn" ).Value );
                return query.Single();
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static Project GetForId( Guid projectId, bool activeOnly )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyProjectsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Project" )
                            where xElem.Element( "ProjectId" ).Value == projectId.ToString()
                            && ( activeOnly ? xElem.Element( "Active" ).Value == "1" : true )
                            select new Project
                            {
                                Id = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
                            };

                return query.SingleOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static Project GetForName( string projectName )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyProjectsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Project" )
                            where string.Equals( xElem.Element( "Description" ).Value, projectName, StringComparison.CurrentCultureIgnoreCase )
                            select new Project
                            {
                                Id = new Guid( xElem.Element( "ProjectId" ).Value ),
                                Description = xElem.Element( "Description" ).Value,
                                Active = xElem.Element( "Active" ).Value == "1" ? true : false
                            };

                return query.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
