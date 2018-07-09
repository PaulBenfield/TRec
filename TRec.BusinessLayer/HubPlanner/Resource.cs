using System;

namespace TRec.BusinessLayer.HubPlanner
{
    public class Resource
    {

        public string _id { get; set; }
        public string email { get; set; }
        public string metadata { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
        public string note { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isProjectManager { get; set; }
        public string status { get; set; }
        public string role { get; set; }
        public bool useCustomAvailability { get; set; }

        //Cut out:
        //customAvailabilities, customFields, links, billing

    }
}
