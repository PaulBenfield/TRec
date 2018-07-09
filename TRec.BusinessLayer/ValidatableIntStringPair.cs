using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class ValidatableIntStringPair
    {
        public Guid Id { get; set; }

        public ValidatableParameter<int> IntValue { get; set; }

        public ValidatableParameter<string> StringValue { get; set; }
    }
}
