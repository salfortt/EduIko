using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class LogBusiness
    {
        private LogBusiness() { }
        private static LogBusiness Instance;

        public static LogBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new LogBusiness();

            return Instance;
        }



        private LogData _dalc;
        private LogData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = LogData.GetInstance();

                return _dalc;
            }
        }

        public int InsertLog(Log l)
        {
            return dalc.InsertLog(l);
        }
        public int InsertLogError(Log l)
        {
            return dalc.InsertLogError(l);
        }

        public List<Log> GetLastHour()
        {
            return dalc.GetLastHour();
        }

        public List<Log> GetDateTime(DateTime today)
        {
            return dalc.GetDateTime(today);
        }
    }
}
