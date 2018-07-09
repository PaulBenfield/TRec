using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.IO;

namespace TRec.BusinessLayer.DataLayer
{
    internal class LocalSettingsStore : LocalSettings
    {
        private bool m_IsLoaded = false;

        public LocalSettingsStore()
        {
            Reload();
        }

        public void Reload()
        {
            m_IsLoaded = true;

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyLocalSettingsFile ];

            if ( File.Exists( filePath ) )
            {
                XDocument doc = XDocument.Load( filePath );
                var query = from xElem in doc.Descendants( "Setting" )
                            select new LocalSettings
                            {
                                LastTimeEntryId = new Guid( xElem.Element( "LastTimeEntryId" ).Value ),
                                LastReminderPeriodInMilliseconds = xElem.Element( "LastReminderPeriodInMilliseconds" ) != null ? Convert.ToInt32( xElem.Element( "LastReminderPeriodInMilliseconds" ).Value ) : 60000
                            };

                LocalSettings item = query.SingleOrDefault();
                if ( item != null )
                {
                    LastTimeEntryId = item.LastTimeEntryId;
                    LastReminderPeriodInMilliseconds = item.LastReminderPeriodInMilliseconds;
                }
            }
        }

        public void Save()
        {
            if ( !m_IsLoaded )
            {
                Reload();
            }

            string filePath = ConfigurationManager.AppSettings[ Constants.cstrConfigKeyLocalSettingsFile ];

            if ( string.IsNullOrEmpty( filePath ) )
            {
                filePath = "Settings.xml";
            }

            if ( !File.Exists( filePath ) )
            {
                StreamWriter w = null;
                try
                {
                    w = File.CreateText( filePath );
                    w.WriteLine( "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" );
                    w.WriteLine( "<Settings>" );
                    w.WriteLine( "</Settings>" );
                }
                finally
                {
                    w.Close();
                }
            }

            XElement xml = new XElement( "Setting",
                            new XElement( "LastTimeEntryId", LastTimeEntryId ),
                            new XElement( "LastReminderPeriodInMilliseconds", LastReminderPeriodInMilliseconds ) );

            xml.Save( filePath );
        }

    }
}
