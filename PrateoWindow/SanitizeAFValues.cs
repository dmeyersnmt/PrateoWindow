﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSIsoft.AF.Asset;

namespace PrateoWindow
{
    /// <summary>
    /// Class that takes the recorded values and returns a list of values that are of good quality
    /// </summary>
    public class SanitizeAFValues
    {
        public List<AFValue> afValues;

        public SanitizeAFValues(List<AFValue> _afValues)
        {
            afValues = new List<AFValue>();
            foreach (AFValue val in _afValues)
            {
                if (val.IsGood)
                {
                    afValues.Add(val);
                }
            }
        }
    }
}
