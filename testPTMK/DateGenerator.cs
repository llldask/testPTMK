using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPTMK
{
    public class DateGenerator
    {
        private DateTime startDate;
        private DateTime endDate;

        public DateGenerator(DateTime start, DateTime end)
        {
            startDate = start;
            endDate = end;
        }

        public DateTime GetRandomDate()
        {
            Random rnd = new Random();
            int range = (endDate - startDate).Days;
            int randomDays = rnd.Next(range);
            return startDate.AddDays(randomDays);
            
        }

    }
}
