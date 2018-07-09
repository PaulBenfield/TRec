using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRec.BusinessLayer
{
    public class ValidatableParameter<T>
    {
        public object Source { get; set; }

        public T Value { get; set; }
    }
}
