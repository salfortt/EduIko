using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ExamReplyData : MongoDocumentsDatabase
    {



        private ExamReplyData() { }
        private static ExamReplyData Instance;
        private const string collectionNameExamAnswers = "ExamReply";
        private const string collectionNameExamAnswersUnending = "ExamReplyUnending";
        public static ExamReplyData GetInstance()
        {
            if (Instance == null)
                Instance = new ExamReplyData();

            return Instance;
        }



        public List<ExamReplyByUser> QuestionaryResults()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.ExamType.Equals(ExamType.Rehberlik) && q.ExamResultStatus.Equals(ExamResultStatus.Bitti)).ToList();
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

        public ExamReplyByUser GetAnswerByID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
        }


        public List<ExamReplyByUser> GetAnswers()
        {
            return GetToList<ExamReplyByUser>(collectionNameExamAnswers);
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
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_ExamID.Equals(objectId) && q.FK_UserID.Equals(userId)).FirstOrDefault();

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

        public List<ExamReplyByUser> GetAnswersByGeneralExamId(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_ParentExamID.Equals(id)).ToList();
        }

        public List<ExamReplyByUser> GetAnswersByExamIDs(ObjectId objectId, List<ObjectId> fK_SubSessionIDs)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_UserID.Equals(objectId) && fK_SubSessionIDs.Contains(q.FK_ExamID)).ToList();
        }

        public void InsertExamReplyUnending(ExamReplyByUser examReplyByUser)
        {
            Insert(examReplyByUser, collectionNameExamAnswersUnending);
        }

        public ExamReplyByUser GetAnswerByUserIDAndExamID(ObjectId objectId, ObjectId examId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_UserID.Equals(objectId) && q.FK_ExamID.Equals(examId)).FirstOrDefault();

        }

        public List<ExamReplyByUser> QuestionaryResultsByUserID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.ExamType.Equals(ExamType.Rehberlik) && q.ExamResultStatus.Equals(ExamResultStatus.Bitti) && q.FK_UserID == id).ToList();

        }

        public List<ObjectId> GetExamsByUserIDFromAnswers(ObjectId userID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.FK_UserID.Equals(userID)).Select(s => s.FK_ExamID).ToList();
        }

        public ExamReplyByUser QuestionaryResult(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<ExamReplyByUser> collection = MongoDB.GetCollection<ExamReplyByUser>(collectionNameExamAnswers);
            return collection.AsQueryable<ExamReplyByUser>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
        }


        public void UserExamAnswersInsert(ExamReplyByUser examReplyByUser)
        {
            Insert(examReplyByUser, collectionNameExamAnswers);
        }

    }
}
