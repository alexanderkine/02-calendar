using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar
{
    public class ZodiacSignInfo
    {
        public Image Image { get; private set; }
        public string Name { get; private set; }
        public string BeginDate { get; private set; }
        public string EndDate { get; private set; }

        public ZodiacSignInfo(Image image, string name, string beginDate, string endDate)
        {
            Image = image;
            Name = name;
            BeginDate = beginDate;
            EndDate = endDate;          
        }

        public static string[][] ZodiacSigns =
        {
            new[] {"Aries","21.03","19.04"}, 
            new[] {"Taurus","20.04","20.05"}, 
            new[] {"Gemini","21.05","20.06"}, 
            new[] {"Cancer","21.06","22.07"}, 
            new[] {"Leo","23.07","22.08"}, 
            new[] {"Virgo","23.08","22.09"}, 
            new[] {"Libra","23.09","22.10"}, 
            new[] {"Scorpio","23.10","21.11"}, 
            new[] {"Sagittarius","22.11","21.12"}, 
            new[] {"Capricorn","22.12 ","19.01"}, 
            new[] {"Aquarius","20.01","18.02"}, 
            new[] {"Pisces","19.02 ","20.03"}, 
        };
    }
}
