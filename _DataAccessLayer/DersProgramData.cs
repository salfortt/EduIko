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
  public class DersProgramData :MongoDocumentsDatabase
    {

        private DersProgramData() { }
        private static DersProgramData Instance;
        private const string collectionName = "TimePlan";
        private const string collectionNameDailyProgram = "DailyProgram";
        public static DersProgramData GetInstance()
        {
            if (Instance == null)
                Instance = new DersProgramData();

            return Instance;
        }

       
 
        public void UpdateBlog(TimePlan p)
        {
          
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<TimePlan> collection = MongoDB.GetCollection<TimePlan> (collectionName);
            var filter = Builders<TimePlan> .Filter.Eq(s => s.id, p.id);

            collection.ReplaceOne(filter, p);
            //typeof(T).Name
        
    }

        public void InsertProgram(TimePlan p)
        {
              Insert(p, collectionName);
        }

        public List<DailyProgram> GetWeekProgram()
        {
          return  GetToList<DailyProgram>(collectionNameDailyProgram);
        }

        public List<TimePlan> GetWeekProgramAllClass()
        {
            return GetToList<TimePlan>(collectionName);
        }

        public void InsertDailyProgram(DailyProgram dp)
        {
            Insert<DailyProgram>(dp, collectionNameDailyProgram);
        }
    }
}
