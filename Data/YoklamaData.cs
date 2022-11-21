using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace Data
{
  public  class YoklamaData :MongoDocumentsDatabase
    {


        private YoklamaData() { }
        private static YoklamaData Instance;
        private const string collectionName = "Yoklama";
        public static YoklamaData GetInstance()
        {
            if (Instance == null)
                Instance = new YoklamaData();

            return Instance;
        }

        public int InsertYoklama(Yoklama y)
        {
            return Insert(y, collectionName);
        }

        public Yoklama GetYoklamaById(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Yoklama> collection = MongoDB.GetCollection<Yoklama>(collectionName);
            return collection.AsQueryable<Yoklama>().Where(q => q.id.Equals(id)).FirstOrDefault();

        }

        public List<Yoklama> GetYoklamaList(string gradeDay, string classId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Yoklama> collection = MongoDB.GetCollection<Yoklama>(collectionName);
            return collection.AsQueryable<Yoklama>().Where(q => q.GradeDay.Equals(gradeDay) && q.IsActive==true && q.FK_ClassId.Equals(ObjectId.Parse(classId))).ToList();

        }

        public void UpdateYoklamaByID(Yoklama y)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Yoklama> collection = MongoDB.GetCollection<Yoklama>(collectionName);
            var filter = Builders<Yoklama>.Filter.Eq(s => s.id, y.id);

            collection.ReplaceOne(filter, y);
        }

        public void DeleteYoklamaById(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Yoklama> collection = MongoDB.GetCollection<Yoklama>(collectionName);
            collection.DeleteOne(q=>q.id.Equals(objectId));

        }
    }
}
