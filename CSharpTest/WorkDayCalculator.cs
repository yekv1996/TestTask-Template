using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime EndDate = startDate.AddDays(dayCount - 1);
            if (weekEnds != null)
                foreach (WeekEnd weekEnd in weekEnds)
                {
                    if (startDate > weekEnd.StartDate)
                    {
                        if (startDate <= weekEnd.EndDate)
                        {
                            EndDate = EndDate.AddDays((weekEnd.EndDate - startDate).TotalDays + 1);
                        }
                        continue;
                    }
                    if (EndDate < weekEnd.StartDate)
                    {
                        break;
                    }
                    EndDate = EndDate.AddDays((weekEnd.EndDate - weekEnd.StartDate).TotalDays + 1);
                }
            return EndDate;
        }
    }
}
