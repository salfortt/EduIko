using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Data
{
  public class ReportCardData : MongoDocumentsDatabase
    {

 

        private ReportCardData() { }
        private static ReportCardData Instance;
        private const string collectionName = "ReportCard";
        private const string collectionStudentReportCard = "StudentReportCard"; 

        public static ReportCardData GetInstance()
        {
            if (Instance == null)
                Instance = new ReportCardData();

            return Instance;
        }

        public List<StudentReportCard> GetStudentReportCardsBySessonAndWeekAndClassID(string sezonName, int week, ObjectId classID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<StudentReportCard> collection = MongoDB.GetCollection<StudentReportCard>(collectionStudentReportCard);
            return collection.AsQueryable<StudentReportCard>().Where(q => q.Sezon == sezonName && q.FK_ClassID==classID && q.Week == week && q.IsActive == true ).ToList();
        }

        public void InsertStudentReportCard(StudentReportCard src)
        {
            Insert<StudentReportCard>(src, collectionStudentReportCard);
        }

        public StudentReportCard GetStudentReportByReportID(ObjectId reportID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<StudentReportCard> collection = MongoDB.GetCollection<StudentReportCard>(collectionStudentReportCard);
            return collection.AsQueryable<StudentReportCard>().Where(q => q.id  ==reportID).FirstOrDefault();
        }

        public void UpdeteStudentReport(StudentReportCard src)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<StudentReportCard> collection = MongoDB.GetCollection<StudentReportCard>(collectionStudentReportCard);
            var filter = Builders<StudentReportCard>.Filter.Eq(s => s.id, src.id);

            collection.ReplaceOne(filter, src);
        }

        public List< StudentReportCard> GetStudentReportByReportID(string sezonName, int activeWeek, ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<StudentReportCard> collection = MongoDB.GetCollection<StudentReportCard>(collectionStudentReportCard);
            return collection.AsQueryable<StudentReportCard>().Where(q => q.Sezon == sezonName && q.FK_StudentID == id && q.Week == activeWeek  ).ToList();
        }
    }
}
