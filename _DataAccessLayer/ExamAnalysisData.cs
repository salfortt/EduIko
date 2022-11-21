using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace DataAccessLayer
{
  public  class ExamAnalysisData : MongoDocumentsDatabase
    {


        private ExamAnalysisData() { }
        private static ExamAnalysisData Instance;
        private const string collectionName = "ExamaAnalysis";
        public static ExamAnalysisData GetInstance()
        {
            if (Instance == null)
                Instance = new ExamAnalysisData();

            return Instance;
        }

        public int InsertExamAnalysis(ExamaAnalysis y)
        {
            return Insert(y, collectionName);
        }

        public ExamaAnalysis GetExamAnalysisById(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamaAnalysis> collection = MongoDB.GetCollection<ExamaAnalysis>(collectionName);
            return collection.AsQueryable<ExamaAnalysis>().Where(q => q.id.Equals(id)).FirstOrDefault();

        }
        public List<ExamaAnalysis> GetExamAnalysisByUserId(ObjectId userId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamaAnalysis> collection = MongoDB.GetCollection<ExamaAnalysis>(collectionName);
            return collection.AsQueryable<ExamaAnalysis>().Where(q => q.FK_UserId.Equals(userId)).ToList();

        }


        public List<ExamaAnalysis> GetExamReplyByUserId(ObjectId userId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamaAnalysis> collection = MongoDB.GetCollection<ExamaAnalysis>(collectionName);
            return collection.AsQueryable<ExamaAnalysis>().Where(q => q.FK_UserId.Equals(userId)).ToList();

        }
        //public List<ExamaAnalysis> GetExamaAnalysisList(string gradeDay, string classId)
        //{
        //    var MongoDB = _client.GetDatabase(_databaseName);
        //    IMongoCollection<ExamaAnalysis> collection = MongoDB.GetCollection<ExamaAnalysis>(collectionName);
        //    return collection.AsQueryable<ExamaAnalysis>().Where(q => q.GradeDay.Equals(gradeDay) && q.FK_ClassId.Equals(ObjectId.Parse(classId))).ToList();

        //}

        public void DeleteExamAnalysisById(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamaAnalysis> collection = MongoDB.GetCollection<ExamaAnalysis>(collectionName);
            collection.DeleteOne(q=>q.id.Equals(objectId));

        }
    }
}
