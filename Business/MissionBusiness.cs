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
    public class MissionBusiness
    {
        private MissionBusiness() { }
        private static MissionBusiness Instance;

        public static MissionBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new MissionBusiness();

            return Instance;
        }



        private MissionData _dalc;
        private MissionData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = MissionData.GetInstance();

                return _dalc;
            }
        }

        public bool InsertMission(Mission Mission) {
            return dalc.InsertMission(Mission);
        }

        internal void CreateMissionRelation(MissionTracking Missiont)
        {
              dalc.CreateMissionRelation(Missiont);
        }
    }
}
