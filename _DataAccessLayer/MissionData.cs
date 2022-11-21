using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataAccessLayer
{
  public class MissionData : MongoDocumentsDatabase
    {

        private MissionData() { }
        private static MissionData Instance;
        private const string collectionName = "Mission";
        private const string collectionNameMissionTracking = "MissionTracking";
        public static MissionData GetInstance()
        {
            if (Instance == null)
                Instance = new MissionData();

            return Instance;
        }

        public bool InsertMission(Mission Mission)
        {
            bool result = false;
            result = Insert(Mission, collectionName)>0?true:false;

            return result;
        }

        public void CreateMissionRelation(MissionTracking Missiont)
        {
            Insert(Missiont, collectionNameMissionTracking);
        }
    }
}
