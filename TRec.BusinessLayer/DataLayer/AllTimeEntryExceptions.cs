using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class AllTimeEntryExceptions : List<TimeEntryException>
    {
        private bool m_IsLoaded = false;

        public AllTimeEntryExceptions()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryExceptionsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Exception" )
                            select new TimeEntryException
                            {
                                TimeEntryExceptionId = new Guid( xElem.Element( "ExceptionId" ).Value ),
                                TimeEntryId = new Guid( xElem.Element( "TimeEntryId" ).Value ),
                                NumberOfMinutes = Convert.ToInt32( xElem.Element( "Mins" ).Value ),
                                ExceptionText = xElem.Element( "Description" ).Value
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

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryExceptionsFile ];

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<Exceptions>" );
                    w.WriteLine( "</Exceptions>" );
                }
                finally
                {
                    w.Close();
                }
            }

            this.Sort();

            XElement xml = new XElement( "Exceptions",
                            from i in this
                            select new XElement( "Exception",
                            new XElement( "ExceptionId", i.TimeEntryExceptionId ),
                            new XElement( "TimeEntryId", i.TimeEntryId ),
                            new XElement( "Mins", i.NumberOfMinutes ),
                            new XElement( "Description", i.ExceptionText )
                            ), new XAttribute( "LastUpdatedOn", DateTime.Now ) );

            xml.Save( filePath );
        }

        public static List<TimeEntryException> GetForTimeEntry( Guid timeEntryId )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyTimeEntryExceptionsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Exception" )
                            where xElem.Element( "TimeEntryId" ).Value == timeEntryId.ToString()
                            select new TimeEntryException
                            {
                                TimeEntryExceptionId = new Guid( xElem.Element( "ExceptionId" ).Value ),
                                TimeEntryId = new Guid( xElem.Element( "TimeEntryId" ).Value ),
                                NumberOfMinutes = Convert.ToInt32( xElem.Element( "Mins" ).Value ),
                                ExceptionText = xElem.Element( "Description" ).Value
                            };

                return query.ToList();
            }
            else
            {
                return new List<TimeEntryException>();
            }
        }
    }
}
