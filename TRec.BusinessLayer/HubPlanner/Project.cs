using System;
using System.Collections.Generic;

namespace TRec.BusinessLayer.HubPlanner
{
    public class Project
    {
        public string _id { get; set; }
        public bool filterGrid { get; set; }
        public bool deleted { get; set; }
        public int company { get; set; }
        public string label { get; set; }
        public string instructions { get; set; }
        public string defaultValue { get; set; }
        public string defaultRadioId { get; set; }
        public string placeholderText { get; set; }
        public DateTime createdDate { get; set; }
        public List<Choice> choices { get; set; }
        public bool canResourceEdit { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string status { get; set; }
        public int __v { get; set; }
        public bool allowMultipleValues { get; set; }
        public int characterLimit { get; set; }
        public int maxValue { get; set; }
        public int minValue { get; set; }
        public int order { get; set; }
        public int stepValue { get; set; }
        public DateTime updatedDate { get; set; }
        public int weekStartOn { get; set; }
    }
}
