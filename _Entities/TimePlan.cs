using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class TimePlan
    {
        //public int TimeSection { get; set; }
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public string ClassName { get; set; }
        public ObjectId FK_ClassID { get; set; }
        public string FirstDate { get; set; }
      
        public List<LectureDay> WeekProgram { get; set; }
    }

    public class DailyProgram
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public DayOfWeek DayOfTheWeek { get; set; }
        public List<DayPlan> Plan { get; set; }
    }
    public class DayPlan
    {
        //public int TimeSection { get; set; }
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public int Order { get; set; }
        public TimeSpan LectureTime { get; set; }
        public bool IsItDone { get; set; } = false;
        
    }



}
