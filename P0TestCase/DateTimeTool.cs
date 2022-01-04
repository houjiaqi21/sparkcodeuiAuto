using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P0TestCase
{
    class DateTimeTool
    {
        public static string DateTimeToStamp(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            int s = (int)(time - startTime).TotalSeconds;
            return s.ToString();
        }
    }
}
