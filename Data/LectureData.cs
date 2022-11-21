using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Data
{
   public class LectureData:MongoDocumentsDatabase
    {
        private LectureData() { }
        private static LectureData Instance;
        private const string collectionName = "Lecture";  
            private const string collectionEarnings = "Earnings";
        private const string collectionLessonProperties = "LessonProperties";

        
        public static LectureData GetInstance()
        {
            if (Instance == null)
                Instance = new LectureData();

            return Instance;
        }

        public void Insert(Lecture l)
        {
            Insert(l,collectionName);
        }
        public void InsertList(List<Lecture> ll)
        {
            InsertList(ll, collectionName);
        }

        public List<Lecture> GetLectures()
        {
            return GetToList<Lecture>(collectionName).Where(q=>q.IsActive ==true).ToList();
        }

        public Lecture GetLectureByID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Lecture> collection = MongoDB.GetCollection<Lecture>(collectionName);
            return collection.AsQueryable<Lecture>().Where(q => q.id.Equals(id) && q.IsActive == true).FirstOrDefault();
        }

        public void InsertEarning(Earnings s)
        {
            Insert<Earnings>(s, "Earnings");
        }

        public LessonProperties GetLessonProperties(int sube)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<LessonProperties> collection = MongoDB.GetCollection<LessonProperties>(collectionLessonProperties);
            return collection.AsQueryable<LessonProperties>().Where(q => q.Grade.Equals(sube) && q.IsActive == true).FirstOrDefault();
        }

        public List<Earnings> GetEarningsByUserId(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
            return collection.AsQueryable<Earnings>().Where(q => q.FK_AddedUserID.Equals(id) && q.IsActive==true).ToList();

        }

        public List<Earnings>
              GetEarnings()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
          //   return collection.AsQueryable<Earnings>().Where(q => q.IsActive == true && q.LectureName.Contains("İnkılap")).ToList().Take(20).ToList();
           return collection.AsQueryable<Earnings>().Where(q => q.IsActive == true ).ToList();

           //  return collection.AsQueryable<Earnings>().Where(q => q.IsActive == true && q.Sube=="6").ToList();
        }

        public List<Earnings> GetEarningByGradeAndLectureName(string grade, string lectureName)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
            return collection.AsQueryable<Earnings>().Where(q => q.IsActive == true && q.Sube==grade && q.LectureName==lectureName).ToList();
        }

         

        //public  byte[] GetEarningsZip()
        //{
        //    var MongoDB = _client.GetDatabase(_databaseName);
        //    IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
        //    return IkoComp.Zip(collection.AsQueryable<Earnings>().Where(q => q.IsActive == true).ToList().ToString());
        //}

        public void InsertLessonProperties(LessonProperties lp)
        {
            Insert<LessonProperties>(lp, collectionLessonProperties);
        }

        public Earnings GetEarningBySubSubjectAndSinif(string subSubject, string sinif)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
            return collection.AsQueryable<Earnings>().Where(q => q.SubSubject == subSubject && q.Sube == sinif).FirstOrDefault();
        }

        public float GetReadTime(ObjectId userID, DateTime createdDate)
        {
            float sure = 0;
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Log> collection = MongoDB.GetCollection<Log>("Log");
         DateTime dt=    collection.AsQueryable<Log>().Where(q => q.CreatedDate > createdDate && q.UserID==userID ).Take(1).FirstOrDefault().CreatedDate;

            if (dt != null)
                sure = (float)(dt - createdDate).TotalSeconds;

                    return sure;

        }

        public void RemoveEarningsById(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
            var filterDef = new FilterDefinitionBuilder<Earnings>();
            var filter = filterDef.Eq(x => x.id, objectId);
            var options = new UpdateOptions { IsUpsert = true };
            var update = new BsonDocument("$set", new BsonDocument("IsActive", false));

            collection.UpdateMany(filter, update, options);
        }

        public List<Earnings> GetEarningsByLectureName(List<string> lst)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
            // Query in intersect

            return collection.AsQueryable<Earnings>().Where(q => lst.Contains(q.LectureName)  &&  q.IsActive == true).ToList();
        }

        public void UpdateEarningsById(Earnings s)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
            var filter = Builders<Earnings>.Filter.Eq(a => a.id, s.id);

            collection.ReplaceOne(filter, s);
        }

        public Earnings GetEarningsById(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Earnings> collection = MongoDB.GetCollection<Earnings>(collectionEarnings);
            return collection.AsQueryable<Earnings>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
        }

    

    }
}
