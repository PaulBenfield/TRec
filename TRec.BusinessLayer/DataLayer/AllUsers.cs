using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class AllUsers : List<User>
    {
        private bool m_IsLoaded = false;

        public AllUsers()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "User" )
                            orderby xElem.Element( "DisplayName" ).Value
                            select new User
                            {
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                UserName = xElem.Element( "UserName" ).Value,
                                DisplayName = xElem.Element( "DisplayName" ).Value,
                                ShiftDefaultStartTime = System.Convert.ToDateTime( xElem.Element( "ShiftDefaultStartTime" ).Value ),
                                ShiftDefaultEndTime = System.Convert.ToDateTime( xElem.Element( "ShiftDefaultEndTime" ).Value )
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

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserFile ];

            if ( string.IsNullOrEmpty( filePath ) )
            {
                filePath = "Users.xml";
            }

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<Users>" );
                    w.WriteLine( "</Users>" );
                }
                finally
                {
                    w.Close();
                }
            }

            this.Sort();

            XElement xml = new XElement( "Users",
                            from i in this
                            select new XElement( "User",
                            new XElement( "UserId", i.UserId ),
                            new XElement( "UserName", i.UserName ),
                            new XElement( "DisplayName", i.DisplayName ),
                            new XElement( "ShiftDefaultStartTime", i.ShiftDefaultStartTime ),
                            new XElement( "ShiftDefaultEndTime", i.ShiftDefaultEndTime )
                            ), new XAttribute( "LastUpdatedOn", DateTime.Now ) );

            xml.Save( filePath );
        }

        public static List<User> GetUsers( List<Guid> userIds )
        {
            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyUserFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "User" )
                            where userIds.Contains( new Guid( xElem.Element( "UserId" ).Value ) )
                            orderby xElem.Element( "DisplayName" ).Value
                            select new User
                            {
                                UserId = new Guid( xElem.Element( "UserId" ).Value ),
                                UserName = xElem.Element( "UserName" ).Value,
                                DisplayName = xElem.Element( "DisplayName" ).Value,
                                ShiftDefaultStartTime = System.Convert.ToDateTime( xElem.Element( "ShiftDefaultStartTime" ).Value ),
                                ShiftDefaultEndTime = System.Convert.ToDateTime( xElem.Element( "ShiftDefaultEndTime" ).Value )
                            };

                return query.ToList();
            }
            else
            {
                return new List<User>();
            }
        }
    }
}
