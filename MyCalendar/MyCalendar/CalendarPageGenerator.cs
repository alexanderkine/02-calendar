using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar
{
    public class CalendarPageGenerator
    {
        private DateTime Date;

        public CalendarPageGenerator(string date)
        {
            try
            {
                Date = DateTime.Parse(date);       
            }
            catch (Exception) {}   
        }

        public DateTime GetDate()
        {
            return Date;
        }
        public CalendarPageGenerator(DateTime date)
        {
            Date = date;
        }

        public String[,] GenerateDaysGrid()
        {
            var daysGrid = new String[6, 8];
            var dateCounter = new DateTime(Date.Year, Date.Month, 1);
            for (var i = 0; i < daysGrid.GetLength(0); i++)
            {
                for (var j = 1; j < daysGrid.GetLength(1); j++)
                {
                    var flag = ((int)dateCounter.DayOfWeek != 0) ? (int)(dateCounter.DayOfWeek) == j : j == 7;
                    if (!flag) continue;
                    daysGrid[i, j] = dateCounter.Day.ToString();
                    dateCounter = dateCounter.AddDays(1);
                    if (dateCounter.Month != Date.Month)
                        break;  
                }                
                daysGrid[i, 0] = (dateCounter.DayOfYear / 7).ToString();
                if (dateCounter.Month != Date.Month)
                    break;  
            }
            return daysGrid;
        }
    }
}