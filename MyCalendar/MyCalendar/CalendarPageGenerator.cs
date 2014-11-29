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
        private Calendar calendar = new GregorianCalendar();

        public CalendarPageGenerator(string date)
        {
            try 
            {
                this.date = DateTime.Parse(date);
            }
            catch (Exception) { }
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

        public string GetSeason()
        {
            if (date.Month < 3 || date.Month == 12)
                return "Winter";
            if (date.Month >= 3 && date.Month < 6)
                return "Spring";
            if (date.Month >= 6 && date.Month < 9)
                return "Summer";
            return "Autumn";
        }

        public String[][] GenerateDaysGrid()
        {
            for (var i = 0; i < daysGrid.Length; i++)
            {
                for (var j = 1; j < 8; j++)
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