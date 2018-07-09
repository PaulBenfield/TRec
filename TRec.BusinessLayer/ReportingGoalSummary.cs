using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TRec.BusinessLayer
{
    [DataObject]
    public class ReportingGoalSummary : Goal
    {

        public string UserDisplayName { get; set; }
    }
}
