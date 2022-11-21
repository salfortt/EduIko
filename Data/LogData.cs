using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class LogData : MongoDocumentsDatabase
    {


        private LogData() { }
        private static LogData Instance;
        private const string collectionName = "Log";
        public static LogData GetInstance()
        {
            if (Instance == null)
                Instance = new LogData();

            return Instance;
        }
        public int InsertLog(Log l)
        {
            return Insert(l, collectionName);
        }

        public int InsertLogError(Log l)
        {
            return Insert(l, "LogError");
        }

        public List<Log> GetLastHour()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Log> collection = MongoDB.GetCollection<Log>(collectionName);
            return collection.AsQueryable<Log>().Where(q => q.CreatedDate > DateTime.Now.AddHours(-1) ).ToList();
        }

        public List<Log> GetDateTime(DateTime today)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Log> collection = MongoDB.GetCollection<Log>(collectionName);
            return collection.AsQueryable<Log>().Where(q => q.CreatedDate >= today.AddDays(-1)).ToList();
        }
    }
}
