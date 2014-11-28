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
            catch (Exception){}   
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
            var firstDay = new DateTime(Date.Year, 1, 1);
            var dateCounter = new DateTime(Date.Year, Date.Month, 1);
            for (var i = 0; i < daysGrid.GetLength(0); i++)
            {
                for (var j = 1; j < daysGrid.GetLength(1); j++)
                {
                    var flag = ((int)dateCounter.DayOfWeek != 0) ? (int)(dateCounter.DayOfWeek) == j : j == 7; //определяет, является ли j днем недели dateCounter
                    if (!flag) continue;
                    daysGrid[i, j] = dateCounter.Day.ToString();                   
                    dateCounter = dateCounter.AddDays(1);
                    if (dateCounter.Month != Date.Month)
                        break;  
                }
                if (dateCounter.DayOfWeek == DayOfWeek.Monday)
                {
                    if (dateCounter.Year.Equals(Date.Year))
                        daysGrid[i, 0] =
                            ((dateCounter.DayOfYear + ((int) firstDay.DayOfWeek != 0 ? (int) (firstDay.DayOfWeek) : 7))/7).ToString();
                    else
                        daysGrid[i, 0] = "53";
                }
                else
                {
                    if (dateCounter.Year.Equals(Date.Year))
                        daysGrid[i, 0] = (int.Parse(daysGrid[i - 1, 0]) + 1).ToString();
                    else
                        daysGrid[i, 0] = "1";
                }
                if (dateCounter.Month != Date.Month)
                    break;  
            }
            return daysGrid;
        }
    }
}