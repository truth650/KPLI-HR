using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20180829
{
    public class Holiday
    {
        private string office; // US ,KOR
        private string type;   // Static, Dynamic 
        private string name;   //holiday name
        private int year;   //년
        private int month;     //월
        private int day;       //일
        private int count;     //몇번째
        private string dayofweek; //요일

        public Holiday(string office, string type, string name, int year, int month, int day, int count, string dayofweek)
        {
            this.office = office;
            this.type = type;
            this.name = name;
            this.year = year;
            this.month = month;
            this.day = day;
            this.count = count;
            this.dayofweek = dayofweek;
        }

        public string Office { get { return office; } set { office = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Year { get { return year; } set { year = value; } }
        public int Month { get { return month; } set { month = value; } }
        public int Day { get { return day; } set { day = value; } }
        public int Count { get { return count; } set { count = value; } }
        public string DayofWeek { get { return dayofweek; } set { dayofweek = value; } }
    }
}
