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
  public class ClassesData : MongoDocumentsDatabase
    {

 

        private ClassesData() { }
        private static ClassesData Instance;
        private const string collectionName = "ClassRoom";
        private const string collectionGrade = "Grade";
        private const string collectionOnlineLecture = "OnlineLecture";
        private const string collectionOnlineLectureTracking = "OnlineLectureTracking";
        private const string collectionOnlineServerInfo= "ServerInfo";
        public static ClassesData GetInstance()
        {
            if (Instance == null)
                Instance = new ClassesData();

            return Instance;
        }

        public int InsertClassRoom(ClassRoom cr)
        {
            return Insert(cr, collectionName);
        }

        public List<Grade> GetGradeis(string sezon)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Grade> collection = MongoDB.GetCollection<Grade>(collectionGrade);
            return collection.AsQueryable<Grade>().Where(q => q.Sezon.Equals(sezon) && q.IsActive == true).ToList();
        }

        public int InsertGrade(Grade g)
        {
            return Insert(g, collectionGrade);
        }


        public void UpdateBlog(BlogPost gal)
        {
          
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<BlogPost> collection = MongoDB.GetCollection<BlogPost> (collectionName);
            var filter = Builders<BlogPost> .Filter.Eq(s => s.id, gal.id);

            collection.ReplaceOne(filter, gal);
            //typeof(T).Name
        
    }

        public Grade GetGradeByMeetingID(string meetingID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Grade> collection = MongoDB.GetCollection<Grade>(collectionGrade);
            return collection.AsQueryable<Grade>().Where(q => q.OnlineLectures.Any(sq=>sq.meetingID== meetingID)).FirstOrDefault();
        }

        public long  GetOnlineLectureTrackingByUserIdAndWeekAndLectureId(ObjectId userId, int activeWeek, ObjectId lectureId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLectureTracking> collection = MongoDB.GetCollection<OnlineLectureTracking>(collectionOnlineLectureTracking);

            var filterDef = new FilterDefinitionBuilder<OnlineLectureTracking>();
            var filter = filterDef.Eq(x => x.FK_UserID, userId);

            return collection.Count(
                Builders<OnlineLectureTracking>.Filter.Eq(s => s.FK_UserID, userId) & 
                Builders<OnlineLectureTracking>.Filter.Eq(s => s.Week, activeWeek) &
                Builders<OnlineLectureTracking>.Filter.Eq(s => s.FK_DersID, lectureId))  ;
        }

        public long GetOnlineLectureTrackingByUserIdAndWeekAndOnlineLectureIds(ObjectId userId, /*int activeWeek,*/ List<ObjectId> onlineLectureIds)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLectureTracking> collection = MongoDB.GetCollection<OnlineLectureTracking>(collectionOnlineLectureTracking);

            var filterDef = new FilterDefinitionBuilder<OnlineLectureTracking>();
            var filter = filterDef.Eq(x => x.FK_UserID, userId);

            return collection.Count(
                Builders<OnlineLectureTracking>.Filter.Eq(s => s.FK_UserID, userId) &
                //Builders<OnlineLectureTracking>.Filter.Eq(s => s.Week, activeWeek) &
                Builders<OnlineLectureTracking>.Filter.In(s => s.FK_LectureID, onlineLectureIds));
        }

        public List<OnlineLecture> GetOnlineLectureByClassIdAndWeek(ObjectId id, int activeWeek)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLecture> collection = MongoDB.GetCollection<OnlineLecture>(collectionOnlineLecture);
            return collection.AsQueryable<OnlineLecture>().Where(q => q.FK_GradeID == id && q.Week == activeWeek  ).ToList();
        }

        public List<OnlineServerInfo> GetOnlineServersInfo()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineServerInfo> collection = MongoDB.GetCollection<OnlineServerInfo>(collectionOnlineServerInfo);
            return collection.AsQueryable<OnlineServerInfo>().Where(q=>q.IsActive==true).ToList();
        }
        public void InsertOnlineServerInfo(OnlineServerInfo server)
        {
              Insert(server, collectionOnlineServerInfo); 
        }

        public List<OnlineLecture> GetOnlineLectureByClassIdAndWeek(ObjectId id, int activeWeek, OnlineClassStatusEnum status)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLecture> collection = MongoDB.GetCollection<OnlineLecture>(collectionOnlineLecture);
            return collection.AsQueryable<OnlineLecture>().Where(q => q.FK_GradeID == id && q.Week==activeWeek && q.OnlineClassStatus ==status ).ToList();
        }

     

        public List<OnlineLectureTracking> GetTrackingsData()
        {
          
            return GetToList<OnlineLectureTracking>(collectionOnlineLectureTracking);
        }

        public List<OnlineLectureTracking> GetTrackingDataByLectureId(ObjectId lectureId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLectureTracking> collection = MongoDB.GetCollection<OnlineLectureTracking>(collectionOnlineLectureTracking);
            return collection.AsQueryable<OnlineLectureTracking>().Where(q => q.FK_LectureID == lectureId).ToList();
        }

        public void InsertTrackingData(OnlineLectureTracking onlineLectureTracking)
        {
            Insert(onlineLectureTracking, collectionOnlineLectureTracking);
        }
        public List<OnlineLecture> GetOnlineLectures( )
        {
            
            return GetToList<OnlineLecture>(collectionOnlineLecture );
        }

        public List<OnlineLecture> GetOnlineActiveLecturesByClassID(ObjectId classId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLecture> collection = MongoDB.GetCollection<OnlineLecture>(collectionOnlineLecture);
            return collection.AsQueryable<OnlineLecture>().Where(q => q.FK_GradeID == classId && q.IsActive && q.OnlineClassStatus != OnlineClassStatusEnum.DidEnd).ToList();
        }

        public void UpdateOnlineLectureTracking(OnlineLectureTracking item)
        {
            Update<OnlineLectureTracking>(item, collectionOnlineLectureTracking);
        }

        public List<OnlineLecture> GetOnlineEndedLecturesByClassID(ObjectId classId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLecture> collection = MongoDB.GetCollection<OnlineLecture>(collectionOnlineLecture);
            return collection.AsQueryable<OnlineLecture>().Where(q => q.FK_GradeID == classId && q.IsActive && q.OnlineClassStatus == OnlineClassStatusEnum.DidEnd).ToList();
        }
        public void UpdateOnlineLecture(OnlineLecture ol)
        {
            Update<OnlineLecture>(ol, collectionOnlineLecture);
        }

        public OnlineLecture GetOnlineLectureByID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLecture> collection = MongoDB.GetCollection<OnlineLecture>(collectionOnlineLecture);
            return collection.AsQueryable<OnlineLecture>().Where(q => q.id == id && q.IsActive).FirstOrDefault();
        }
        public long GetOnlineActiveLectureCountByClassID(ObjectId classId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLecture> collection = MongoDB.GetCollection<OnlineLecture>(collectionOnlineLecture);
             

            return collection.Count(
                Builders<OnlineLecture>.Filter.Eq(s => s.FK_GradeID, classId) 
                & Builders<OnlineLecture>.Filter.Eq(s => s.IsActive, true) 
                & Builders<OnlineLecture>.Filter.Ne(s => s.OnlineClassStatus, OnlineClassStatusEnum.DidEnd) //not equal
                );


        }
        public long GetOnlineFinishedLectureCountByClassID(ObjectId classId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<OnlineLecture> collection = MongoDB.GetCollection<OnlineLecture>(collectionOnlineLecture);


            return collection.Count(
                Builders<OnlineLecture>.Filter.Eq(s => s.FK_GradeID, classId)
                & Builders<OnlineLecture>.Filter.Eq(s => s.IsActive, true)
                & Builders<OnlineLecture>.Filter.Eq(s => s.OnlineClassStatus, OnlineClassStatusEnum.DidEnd)//Equal
                );


        }
        public void InsertOnlineLecture(OnlineLecture onlineLecture)
        {
            Insert(onlineLecture, collectionOnlineLecture);
        }

        public List<Grade> GetGradeByUserID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Grade> collection = MongoDB.GetCollection<Grade>(collectionGrade);
            return collection.AsQueryable<Grade>().Where(q => q.FK_TeacherID.Equals(id) && q.IsActive == true).ToList();
        }

        public void UpdateGradeByID(Grade g)
        {
            Update<Grade>(g, collectionGrade);
        }

        public Grade GetGradeByID(ObjectId classId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Grade> collection = MongoDB.GetCollection<Grade>(collectionGrade);
            return collection.AsQueryable<Grade>().Where(q => q.id.Equals(classId) /*&& q.IsActive == true*/).FirstOrDefault();
        }

        public List<BlogPost> getGetBlogByUserID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<BlogPost> collection = MongoDB.GetCollection<BlogPost>(collectionName);
            return collection.AsQueryable<BlogPost>().Where(q => q.UserId.Equals(id)).ToList();

        }


  
    }
}
