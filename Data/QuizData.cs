using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Data
{
    public class QuizData : MongoDocumentsDatabase
    {
        private QuizData() { }
        private static QuizData Instance;
        private const string collectionName = "Question";
        private const string collectionNameExamAnswers = "ExamAnswers";
        private const string collectionNameExam = "Exam";
        private const string collectionNameQuestion = "Question";
        private const string collectionNameQuestionary = "Questionary";
        private const string collectionNameQuestionaryCokluZekaComment = "QuestionaryCokluZekaComment";
        private const string collectionNameEtkinlik = "Etkinlik";
        private const string collectionNameAutoExamByUser = "UserAutoExam";
        public static QuizData GetInstance()
        {
            if (Instance == null)
                Instance = new QuizData();

            return Instance;
        }


        public List<Question> GetQuestions(int sube)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>(collectionName);
            return collection.AsQueryable<Question>().Where(q => q.Class.Equals(sube) && q.IsActive == true).ToList();

        }

        public List<Question> GetQuestion(int sube)
        {
            throw new NotImplementedException();
        }

        public void Insert(Question q)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>(collectionName);
            collection.InsertOne(q);

            var MongoDBeduiko = _client.GetDatabase(_databaseNameEduiko);
            IMongoCollection<Question> collectionEduiko = MongoDBeduiko.GetCollection<Question>(collectionName);
            collectionEduiko.InsertOne(q);
        }

        public List<Exam> GetExams()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionNameExam);
            return collection.AsQueryable<Exam>().Where(q => q.IsActive == true).ToList();

        }

        public Question GetQuestionsById(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>(collectionName);
            return collection.AsQueryable<Question>().Where(q =>  q.id.Equals(id)).FirstOrDefault();
        }

      

        public List<Question> GetQuestionList(ObjectId userId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>("Question");
            return collection.AsQueryable<Question>().Where(q => q.FK_AddUserID.Equals(userId) && q.IsActive == true).ToList();
        }

        public List<Question> GetQuestionsByIds(List<ObjectId> questions)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>(collectionName);

            var filterDef = new FilterDefinitionBuilder<Question>();
            var filter = filterDef.In(x => x.id ,  questions  );
            return collection.Find(filter).ToList();
             
        }

      

        public List<Exam> GetExamByTypeClassIdAndWeek(ExamType ödev, ObjectId classId, int activeWeek)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionNameExam);
            return collection.AsQueryable<Exam>().Where(q => q.ExamType == ödev && q.FK_ClassID == classId && q.Week == activeWeek && q.ExamToUsersByID == null && q.IsActive == true).ToList();
        }
        public List<ExamReplyByUser> GetExamAnswersByTypeUserIdAndWeek(ExamType quiz, ObjectId id, int activeWeek)
        {

            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.ExamType.Equals(quiz) && q.FK_UserID.Equals(id) && q.Week == activeWeek).ToList();

        }

        public void UpdateExamById(Exam e)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionNameExam);
            var filter = Builders<Exam>.Filter.Eq(s => s.id, e.id);

            collection.ReplaceOne(filter, e);
        }

        public Exam GetExamByID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>(collectionNameExam);
            return collection.AsQueryable<Exam>().Where(q => q.id.Equals(objectId)).FirstOrDefault();

        }

        public List<ExamReplyByUser> GetExamAnswersByTypeClassIdAndWeek(ExamType quiz, ObjectId classId, int activeWeek)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.ExamType.Equals(quiz) && q.FK_ClassID.Equals(classId) && q.Week == activeWeek).ToList();
        }
        public List<Question> GetQuestionList()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>("Question");
            return collection.AsQueryable<Question>().Where(q =>   q.IsActive == true).ToList();
        }


        public void QuestionaryCreate(List<Questionary> lqry)
        {
            InsertList(lqry,"Questionary");
        }

        public List<Questionary> QuestionaryGetByExamName(string examName)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Questionary> collection = MongoDB.GetCollection<Questionary>("Questionary");
            return collection.AsQueryable<Questionary>().Where(q => q.AnketAdi.Equals(examName)).ToList();
        }

        public List<Exam> GetQuestionaryList()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>("Exam");
            return collection.AsQueryable<Exam>().Where(q => q.ExamType.Equals(ExamType.Anket)).ToList();
        }

        public List<ExamReplyByUser> QuestionaryResults()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.ExamType.Equals(ExamType.Anket) && q.ExamResultStatus.Equals(ExamResultStatus.Bitti) ).ToList();
        }

        public void UserExamAnswersUpdate(ExamReplyByUser examReplyByUser)
        {
            

            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            var filter = Builders<ExamReplyByUser>.Filter.Eq(s => s.id, examReplyByUser.id);

            collection.ReplaceOne(filter, examReplyByUser);
        }

        public ExamReplyByUser GetAnswerByExamId(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_ExamID.Equals(objectId)).FirstOrDefault();

        }

        public void UpdateQuestionById(Question q)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>("Question");
            var filter = Builders<Question>.Filter.Eq(s => s.id, q.id);

            collection.ReplaceOne(filter, q);
        }

        public ExamReplyByUser GetAnswerByID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
        }

     

        public List<Question> GetByType(QuestionType ucuAcik)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>("Question");
            return collection.AsQueryable<Question>().Where(q => q.QuestionType.Equals(ucuAcik) && q.IsActive==true).ToList();

        }

        public List<Exam> GetQuizTypeAndFKClassID(ExamType quiz, ObjectId fK_ClassID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Exam> collection = MongoDB.GetCollection<Exam>("Exam");
            return collection.AsQueryable<Exam>().Where(q => q.FK_ClassID.Equals(fK_ClassID) && q.ExamType.Equals(quiz)).ToList();
        }

        public List<ExamReplyByUser> GetAnswers()
        {
            return GetToList<ExamReplyByUser>(collectionNameExamAnswers);
        }

        public void InsertEtkinlik(Question q)
        {
            Insert(q, "Etkinlik");
        }

        public List<ObjectId> GetExamsByUserIDFromAnswers(ObjectId userID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_UserID.Equals(userID)).Select(s=>s.FK_ExamID).ToList();

            //IMongoCollection<Exam> collectionExam = MongoDB.GetCollection<Exam>("Exam");
            //var filterDef = new FilterDefinitionBuilder<Exam>();
            //var filter = filterDef.In(x => x.id, list);
            //return collectionExam.Find(filter).ToList().Where(q => q.IsActive == true).ToList();

        }

        public void UserExamAnswersUpdateMultiple(List<ExamReplyByUser> answers)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            foreach (var item in answers)
            {
                var filter = Builders<ExamReplyByUser>.Filter.Eq(s => s.id, item.id);
                collection.ReplaceOne(filter, item);
            }
        }

        public ExamReplyByUser GetAnswerByExamIdAndUserID(ObjectId objectId, ObjectId userId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_ExamID.Equals(objectId) && q.FK_UserID.Equals(userId) ).FirstOrDefault();

        }

        public List<ExamReplyByUser> GetAnswersByExamId(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_ExamID.Equals(objectId)).ToList();

        }

        public List<ExamReplyByUser> GetAnswersByUserID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_UserID.Equals(objectId)).ToList();

        }

        public ExamReplyByUser GetAnswerByUserIDAndExamID(ObjectId objectId, ObjectId examId  )
        {
            var MongoDB = _client.GetDatabase(_databaseName); 
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_UserID.Equals(objectId) && q.FK_ExamID.Equals(examId)).FirstOrDefault();

        }

        public List<ExamReplyByUser> QuestionaryResultsByUserID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.ExamType.Equals(ExamType.Anket) && q.ExamResultStatus.Equals(ExamResultStatus.Bitti) && q.FK_UserID==id ).ToList();

        }

        public List<QuestionaryCokluZekaComment> QuestionaryResultComment(List<string> list)
        { 
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<QuestionaryCokluZekaComment> collection = MongoDB.GetCollection<QuestionaryCokluZekaComment>("QuestionaryCokluZekaComment");

            var filterDef = new FilterDefinitionBuilder<QuestionaryCokluZekaComment>();
            var filter = filterDef.In(x => x.Alan, list);
            return collection.Find(filter).ToList();
        
    }
        public List<QuestionaryCokluZekaComment> QuestionaryResultComment()
        {

            return GetToList<QuestionaryCokluZekaComment>("QuestionaryCokluZekaComment"); 

        }
        public ExamReplyByUser QuestionaryResult(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
        }

        public void QuestionaryYorumInsert(List<QuestionaryCokluZekaComment> lczc)
        {
            InsertList<QuestionaryCokluZekaComment>(lczc, "QuestionaryCokluZekaComment");
        }

        public List<Question> GetSubeDersID(int? sube, ObjectId dersId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>(collectionName);

            
            return collection.AsQueryable().Where(q=>q.Class.Equals(sube) && q.FK_LectureID.Equals(dersId) && q.IsActive==true).ToList();
        }

        public void UserExamAnswersInsert(ExamReplyByUser examReplyByUser)
        {
            Insert(examReplyByUser,collectionNameExamAnswers);
        }

        public List<Question> GetQuestionsByClassAndLecture(int sube, string lectureName)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Question> collection = MongoDB.GetCollection<Question>(collectionName);
            return collection.AsQueryable<Question>().Where(q => q.Class.Equals(sube) && q.LectureName.Equals(lectureName) && q.IsActive == true).ToList();

        }
    }
}
