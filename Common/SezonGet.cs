using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public   class SezonGet
    {
        private SezonGet() { }
        private static SezonGet Instance;

        public static SezonGet GetInstance()
        {
            if (Instance == null)
                Instance = new SezonGet();

            return Instance;
        }

        private   string sezonName;
        public string SezonName
        {
            get
            {
                this.sezonName = string.Empty;
                DateTime sezonControl = new System.DateTime(DateTime.Now.Year, 7, 1, 0, 0, 0);//15 hazirana al.
                 
                if (DateTime.Now < sezonControl)
                {
                    this.sezonName = (DateTime.Now.Year -1 ) + " - " + DateTime.Now.Year;
                }
                else
                {
                    this.sezonName = DateTime.Now.Year +" - " + (DateTime.Now.Year + 1);
                }

                return this.sezonName;
            }
            
        }

        public string SezonNameByDate (DateTime dt)
        {
            
                this.sezonName = string.Empty;
                DateTime sezonControl = new System.DateTime(dt.Year, 7, 1, 0, 0, 0);//15 hazirana al.

                if (dt < sezonControl)
                {
                    this.sezonName = (dt.Year - 1) + " - " +dt.Year;
                }
                else
                {
                    this.sezonName = dt.Year + " - " + (dt.Year + 1);
                }

                return this.sezonName;
            

        }
        public int GetWeekOrderBySeasonStartDay(DateTime StartDay)
        {

            int result = 0;
            var currentWeek = DateTime.Today;
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            var NowWeekNumber = cal.GetWeekOfYear(currentWeek, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            var SezonStartWeekNumber = cal.GetWeekOfYear(StartDay, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

           
            if (StartDay.Year == DateTime.Now.Year)
            {
                result = (NowWeekNumber - SezonStartWeekNumber) + 1;// +1 
            }
            else if (StartDay.Year < DateTime.Now.Year)
            {
                result = ((52 + NowWeekNumber) - SezonStartWeekNumber) + 1;
            }

            return   result;


        }
        public int GetWeekOrderBySeasonStartDayByDate(DateTime SessonStartDay,DateTime date)
        {

            int result = 0;
          
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            var NowWeekNumber = cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            var SezonStartWeekNumber = cal.GetWeekOfYear(SessonStartDay, CalendarWeekRule.FirstDay, DayOfWeek.Monday);


            if (SessonStartDay.Year == date.Year)
            {
                result = (NowWeekNumber - SezonStartWeekNumber) +1;// +1 
            }
            else if (SessonStartDay.Year < date.Year)
            {
                result = ((52 + NowWeekNumber) - SezonStartWeekNumber)+1 ;
            }

            return result;


        }

        public DateTime GetWeekDatesBySeasonStartDayAndWeek(DateTime SessonStartDay, int week)
        {

            DateTime result=DateTime.Now;

            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            var NowWeekNumber = cal.GetWeekOfYear(DateTime.Now.AddMonths(1), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            var SezonStartWeekNumber = cal.GetWeekOfYear(SessonStartDay, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            week = week - 1;
             
            result = SessonStartDay.AddDays(week * 7);
            return result;


        }
    }
}
