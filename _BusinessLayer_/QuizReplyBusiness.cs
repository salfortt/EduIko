using BusinessLayer.CacheController;
using DataAccessLayer;
using Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{

    public class QuizReplyBusiness
    {
        private QuizReplyBusiness() { }

        //    Caching rc = Caching.GetInstance();
        //    Dictionary<ObjectId, Question> ListQuestionDic = rc.GetListQuestionDic();

        //    List<Question> LQuestion = new List<Question>();

        //    if (ListQuestionDic == null)
        //    {

        //        LQuestion = dalc.GetQuestionList();


        //        ListQuestionDic = LQuestion.ToDictionary(d => d.id, d => d);
        //        rc.SetListQuestionDic(ListQuestionDic);
        //        rc.SetListQuestion(LQuestion);
        //    }



        //}
        private static QuizReplyBusiness Instance;


        //ServerSideCaching rc = ServerSideCaching.GetInstance();
        //PersonalCaching pc = PersonalCaching.GetInstance();

        public static QuizReplyBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new QuizReplyBusiness();

            return Instance;
        }



        private ExamReplyData _dalc;
        private ExamReplyData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = ExamReplyData.GetInstance();

                return _dalc;
            }
        }



        public void UserExamAnswersInsert(ExamReplyByUser examReplyByUser)
        {
            dalc.UserExamAnswersInsert(examReplyByUser);
        }

        public ExamReplyByUser QuestionaryResult(ObjectId objectId)
        {
            return dalc.QuestionaryResult(objectId);
        }

        public List<ExamReplyByUser> QuestionaryResults()
        {
            return dalc.QuestionaryResults();
        }



        public List<ExamReplyByUser> QuestionaryResultsByUserID(ObjectId id)
        {
            return dalc.QuestionaryResultsByUserID(id);
        }

        public void UserExamAnswersUpdate(ExamReplyByUser examReplyByUser)
        {
            dalc.UserExamAnswersUpdate(examReplyByUser);
        }

        public ExamReplyByUser GetAnswerByUserIDAndExamID(ObjectId objectId, ObjectId examId)
        {
            return dalc.GetAnswerByUserIDAndExamID(objectId, examId);
        }
        public List<ExamReplyByUser> GetAnswersByUserID(ObjectId objectId)
        {
            return dalc.GetAnswersByUserID(objectId);
        }

        public ExamReplyByUser GetAnswerByExamId(ObjectId objectId)
        {
            return dalc.GetAnswerByExamId(objectId);
        }
        public ExamReplyByUser GetAnswerByExamIdAndUserID(ObjectId objectId, ObjectId userID)
        {
            return dalc.GetAnswerByExamIdAndUserID(objectId, userID);
        }


        public List<ExamReplyByUser> GetAnswersByExamId(ObjectId objectId)
        {
            return dalc.GetAnswersByExamId(objectId);
        }

        public ExamReplyByUser GetAnswerByUserID(ObjectId objectId)
        {
            return dalc.GetAnswerByExamId(objectId);
        }



        public void UserExamAnswersUpdateMultiple(List<ExamReplyByUser> answers)
        {
            dalc.UserExamAnswersUpdateMultiple(answers);
        }

        public List<ObjectId> GetExamsByUserIDFromAnswers(ObjectId objectId)
        {
            return dalc.GetExamsByUserIDFromAnswers(objectId);
        }

          
        
        //public List<ExamReplyByUser> AllAnswers
        //{
        //    get
        //    {
        //        if (rc.GetListAnswers() == null)
        //            rc.SetListAnswers(LoadAnswers());

        //        return rc.GetListAnswers();
        //    }
        //}

        private List<ExamReplyByUser> LoadAnswers()
        {
            return dalc.GetAnswers();
        }


        public ExamReplyByUser GetAnswerByID(ObjectId objectId)
        {
            return dalc.GetAnswerByID(objectId);
        }

        public void InsertExamReplyUnending(ExamReplyByUser examReplyByUser)
        {
            dalc.InsertExamReplyUnending(examReplyByUser);
        }

        public List<ExamReplyByUser> GetAnswersByExamIDs(ObjectId objectId, List<ObjectId> fK_SubSessionIDs)
        {
            return dalc.GetAnswersByExamIDs(objectId, fK_SubSessionIDs);
        }

        public List<ExamReplyByUser> GetAnswersByGeneralExamId(ObjectId id)
        {
            return dalc.GetAnswersByGeneralExamId(id);
        }

        public List<ExamReplyByUser> GetAnswers()
        {
            return dalc.GetAnswers();
        }
    }

}
