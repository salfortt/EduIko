using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataAccessLayer
{
   public class OdevData:MongoDocumentsDatabase
    {
        private OdevData() { }
        private static OdevData Instance;
        private const string collectionName = "Exam";
        private const string collectionNameOpenExam = "OpenExam";
        private const string collectionNameStudentFile = "StudentFile";
        public static OdevData GetInstance()
        {
            if (Instance == null)
                Instance = new OdevData();

            return Instance;
        }

        public bool  Insert(Exam e)
        {
           int  result = 0;
          result = Insert(e,collectionName);

            return result == 1 ? true : false;
        }

        public List<Exam> GetExam(ObjectId fK_ClassId,  ExamType eType)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q =>  q.FK_ClassID.Equals(fK_ClassId) && q.IsActive==true && q.IsDeleted == false && q.EndDate > DateTime.Now && q.ExamType == eType).ToList();

        }
    
        public void UpdateByUserLookedUp(Exam e)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            var filter = Builders<Exam>.Filter.Eq(s => s.id, e.id);

            collection.ReplaceOne(filter, e);
        }

        public List<Exam> GetExamsByType(ExamType type)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.ExamType.Equals(type) && q.IsActive == true && q.IsDeleted == false && q.EndDate > DateTime.Now && q.StartDate < DateTime.Now  ).OrderBy(o => o.EndDate).ToList();

        }

        public List<Exam> GetExams()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.IsActive == true ).ToList();
 
        }
        public List<Exam> GetExamQuizies( int page, int pageSize,string search)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);

            int skip = 0;
            skip = page * pageSize;

            if (!string.IsNullOrEmpty(search))
                return collection.AsQueryable<Exam>().Where(q => q.ProjectTitle.ToLower().Contains(search.ToLower()) && q.IsActive == true
                           && (q.ExamType.Equals(ExamType.Quiz) || q.ExamType.Equals(ExamType.GenelDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSayisal) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSozel))
                           ).OrderByDescending(o => o.CreatedDate).Skip(page * pageSize).Take(pageSize).ToList();
            else
                return collection.AsQueryable<Exam>().Where(q =>  q.IsActive == true
           && (q.ExamType.Equals(ExamType.Quiz) || q.ExamType.Equals(ExamType.GenelDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSayisal) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSozel))
           ).OrderByDescending(o => o.CreatedDate).Skip(skip).Take(pageSize).ToList();

        }

        public List<Exam> GetActiveExamClassOrPersonal(ObjectId studentID, ObjectId classID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.EndDate > DateTime.Now && ((q.FK_ClassID == classID && q.ExamToUsersByID == null) || (q.ExamToUsersByID != null && q.ExamToUsersByID.Contains(studentID))) && q.ExamType == ExamType.Ödev && q.IsActive == true).OrderByDescending(o => o.EndDate).ToList();
            //leexam.Where(q =>  ).ToList();
        
        }
   

        public List<Exam> GetOldExamClassOrPersonal(ObjectId studentID, ObjectId classID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.EndDate < DateTime.Now && ((q.FK_ClassID == classID && q.ExamToUsersByID == null) || (q.ExamToUsersByID != null && q.ExamToUsersByID.Contains(studentID))) && q.ExamType == ExamType.Ödev && q.IsActive == true).OrderByDescending(o => o.EndDate).ToList();
            //leexam.Where(q =>  ).ToList();

        }
        public long GetExamsByClassIDGetCount( ObjectId fK_ClassId)
        {

            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);

            return collection.Count(Builders<Exam>.Filter.Ne(s => s.ExamType, ExamType.Ödev) & Builders<Exam>.Filter.Ne(s => s.ExamType, ExamType.Anket) &Builders<Exam>.Filter.Ne(s => s.ExamType, ExamType.Rehberlik)   & Builders<Exam>.Filter.Eq(s => s.FK_ClassID, fK_ClassId) & Builders<Exam>.Filter.Eq(s => s.IsActive, true) & Builders<Exam>.Filter.Eq(s => s.IsPublished, true)  ) ;

        }

        public List<Exam> GetAllActiveExamClassOrPersonal()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.EndDate > DateTime.Now   && q.ExamType == ExamType.Ödev && q.IsActive == true).OrderByDescending(o => o.EndDate).ThenBy(q => q.FK_ClassID).ToList();

        
        }

        public void InsertStudentFiles(List<StudentFile> LSF)
        {
            InsertList<StudentFile>(LSF, collectionNameStudentFile); 
        }

      

        public List<Exam> GetAllOldExamClassOrPersonal()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.EndDate < DateTime.Now && q.ExamType == ExamType.Ödev && q.IsActive == true).OrderByDescending(o => o.EndDate).ThenBy(q => q.FK_ClassID).ToList();


        }

      

        public long GetExamsCount()
        {

            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);

            return collection.Count( Builders<Exam>.Filter.Eq(s => s.IsActive, true) & Builders<Exam>.Filter.Eq(s => s.IsPublished, true));

        }
        public Exam GetExamByID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.id.Equals(objectId)).FirstOrDefault();

        }

        public List<Exam> GetExamByUserID(ObjectId userId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.FK_TeacherId.Equals(userId) && q.IsActive == true && q.IsDeleted == false && q.Sezon==Common.SezonGet.GetInstance().SezonName).OrderByDescending(o => o.EndDate).ToList();
        }

        public List<Exam> GetExamsByUserIDandClassID(ObjectId userId, ObjectId fK_ClassId, int page, int pageSize,string search)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
           
            if(!string.IsNullOrEmpty( search))
            return collection.AsQueryable<Exam>().Where(q => q.ProjectTitle.ToLower().Contains(search.ToLower()) && (q.FK_ClassID.Equals(fK_ClassId) || (q.ExamToUsersByID != null && q.ExamToUsersByID.Contains(userId)))  && q.IsActive == true && q.IsPublished == true
            && (q.ExamType.Equals(ExamType.Quiz) || q.ExamType.Equals(ExamType.GenelDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSayisal) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSozel))

            ).OrderByDescending(o=>o.CreatedDate).Skip(page*pageSize).Take(pageSize).ToList() ;
        else
                return collection.AsQueryable<Exam>().Where(q =>  (q.FK_ClassID.Equals(fK_ClassId) || (q.ExamToUsersByID != null && q.ExamToUsersByID.Contains(userId))) && q.IsActive == true && q.IsPublished == true
                        && (q.ExamType.Equals(ExamType.Quiz) || q.ExamType.Equals(ExamType.GenelDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirme) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSayisal) || q.ExamType.Equals(ExamType.KazanimDegerlendirmeSozel))

                        ).OrderByDescending(o => o.CreatedDate).Skip(page * pageSize).Take(pageSize).ToList();
        }

        public void InsertExamTransferByEduiko(ExamTransferEduIKO e)
        {
            var MongoDBeduiko = _client.GetDatabase(_databaseName);
          
            IMongoCollection<ExamTransferEduIKO> collectionEduiko = MongoDBeduiko.GetCollection<ExamTransferEduIKO>(collectionNameOpenExam);
            collectionEduiko.InsertOne(e);
        }

        public void PassiveToQuizByIds(List<ObjectId> quizIds)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            var filterDef = new FilterDefinitionBuilder<Exam>();
            var filter = filterDef.In(x => x.id, quizIds);
            var options = new UpdateOptions { IsUpsert = true };
            var update = new BsonDocument("$set", new BsonDocument("IsActive", false));
            //var filter = new BsonDocument();
            //var update = new BsonDocument("$set", new BsonDocument("x", 1));
            //var options = new UpdateOptions { IsUpsert = true };
            //var result = await collection.UpdateManyAsync(filter, update, options);

            collection.UpdateMany(filter,update,options);
        }

        public List<Exam> GetExamsByIDs(List<ObjectId> list)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);

            var filterDef = new FilterDefinitionBuilder<Exam>();
            var filter = filterDef.In(x => x.id, list);
            return collection.Find(filter).ToList();
        }

        public List<Exam> GetOldExamByUserID(ObjectId userId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.FK_TeacherId.Equals(userId) && q.IsActive == true && q.IsDeleted == false && q.EndDate < DateTime.Now).OrderByDescending(o=>o.EndDate).ToList();

        }
        public List<Exam> GetExamByUserIDAndType(ObjectId userId,ExamType eType)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.FK_TeacherId.Equals(userId) && q.IsActive == true && q.IsDeleted == false && q.ExamType==eType).ToList();

        }


        public List<Exam> GetOldExam(ObjectId fK_ClassId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.FK_ClassID.Equals(fK_ClassId) && q.IsActive == true && q.IsDeleted == false && q.EndDate < DateTime.Now).ToList();

        }

        public List<Exam> GetExams(ExamType eType)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            return collection.AsQueryable<Exam>().Where(q => q.IsActive == true && q.IsDeleted == false && q.ExamType == eType).ToList();

        }

        public void UpdateExamById(Exam e)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionName);
            var filter = Builders<Exam>.Filter.Eq(s => s.id, e.id);

            collection.ReplaceOne(filter, e);
        }
        public List<StudentFile> GetAllStudentFilesByOdevID(List<ObjectId> loid)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<StudentFile> collection = MongoDB.GetCollection<StudentFile>(collectionNameStudentFile);
            return collection.AsQueryable<StudentFile>().Where(q => loid.Contains(q.FK_OdevID)).ToList();

        }
        public List<StudentFile> GetStudentFilesByOdevIDsAndStudentId(List<ObjectId> loid, ObjectId userId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<StudentFile> collection = MongoDB.GetCollection<StudentFile>(collectionNameStudentFile);
            return collection.AsQueryable<StudentFile>().Where(q => loid.Contains(q.FK_OdevID) && q.FK_UserID == userId).ToList();
        }

        public List<StudentFile> GetAllStudentFiles()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<StudentFile> collection = MongoDB.GetCollection<StudentFile>(collectionNameStudentFile);
            return collection.AsQueryable<StudentFile>().ToList();
        }
    }
}
