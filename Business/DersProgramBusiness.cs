using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using MongoDB.Bson;

namespace Business
{
    public class DersProgramBusiness
    {
        private DersProgramBusiness() { }
        private static DersProgramBusiness Instance;

        public static DersProgramBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new DersProgramBusiness();

            return Instance;
        }



        private DersProgramData _dalc;
        private DersProgramData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = DersProgramData.GetInstance();

                return _dalc;
            }
        }

       

        public void InsertProgram(TimePlan p)
        {
            dalc.InsertProgram(p);
        }

      

        public void InsertDailyProgram(DailyProgram dp)
        {
            dalc.InsertDailyProgram(dp);
        }

        public List<DailyProgram> GetWeekProgram()
        {
            return dalc.GetWeekProgram();
        }

        public List<TimePlan> GetWeekProgramAllClass()
        {
            return dalc.GetWeekProgramAllClass();
        }
    }
}
