using System;
using System.Globalization;
using System.Linq;

namespace MyCalendar
{
    public class CalendarPageGenerator
    {
        private DateTime date;
        private DateTime dateCounter;
        private String[][] daysGrid;
        private readonly Calendar calendar = new GregorianCalendar();

        public CalendarPageGenerator(string date)
        {
            this.date = DateTime.Parse(date);
            dateCounter = new DateTime(this.date.Year, this.date.Month, 1);
            daysGrid = new String[6][].Select(x => new String[8]).ToArray();
        }

        public CalendarPageGenerator(DateTime date)
        {
            this.date = date;
            dateCounter = new DateTime(this.date.Year, this.date.Month, 1);
            daysGrid = new String[6][].Select(x => new String[8]).ToArray();
        }

        public DateTime GetDate()
        {
            return date;
        }

        public String[][] GenerateDaysGrid()
        {
            for (var i = 0; i < daysGrid.Length; i++)
            {
                for (var j = 1; j < daysGrid[i].Length; j++)
                {
                    if (((int) dateCounter.DayOfWeek != 0) ?  j != (int)(dateCounter.DayOfWeek) : j != 7) continue;
                    daysGrid[i][j] = dateCounter.Day.ToString();
                    dateCounter = dateCounter.AddDays(1);
                    if (dateCounter.Month == date.Month) continue;
                    daysGrid[i][0] = calendar.GetWeekOfYear(GetCorrectDateCounter(ref dateCounter), CalendarWeekRule.FirstDay, DayOfWeek.Monday).ToString();
                    return daysGrid;
                }
                daysGrid[i][0] = calendar.GetWeekOfYear(GetCorrectDateCounter(ref dateCounter), CalendarWeekRule.FirstDay,DayOfWeek.Monday).ToString();
            }
            return daysGrid;
        }

        private DateTime GetCorrectDateCounter(ref DateTime dateCounter)
        {
            return (dateCounter.Year == date.Year || dateCounter.DayOfWeek == DayOfWeek.Monday) ? dateCounter.AddDays(-1) : dateCounter;
        }
    }
}