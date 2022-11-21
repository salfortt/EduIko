using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;

namespace Business
{

   public class QuizBusiness 
    {
        private QuizBusiness() { }
        private static QuizBusiness Instance;

    

        public static QuizBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new QuizBusiness();

            return Instance;
        }



        private QuizData _dalc;
        private QuizData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = QuizData.GetInstance();

                return _dalc;
            }
        }
        public List<Exam> GetExams()
        {
            ////public List<Exam> ListExam
            ////{
            ////    get
            ////    {

            ////        List<Exam> LExam = ssc.GetListExam();

            ////        if (LExam == null)
            ////        {
            ////            LExam = LoadExam();
            ////            ssc.SetListExam(LExam);
            ////        }

            ////        return LExam;
            ////    }
            ////} 
            return dalc.GetExams();
        }
        public List<Question> GetQuestion(int sube)
        {
            return dalc.GetQuestion(sube);
        }

        public List<Question> GetQuestions(int sube)
        {
          return  dalc.GetQuestions(sube);
        }
        public Question GetQuestionsById(ObjectId id)
        {
            return dalc.GetQuestionsById(id);
        }

        public List<Question> GetQuestionList(ObjectId id)
        {
            return dalc.GetQuestionList(id);
        }

        public List<Question> GetQuestionsByIds(List<ObjectId> questions)
        {
            return dalc.GetQuestionsByIds(questions);
        }
      
        public void Insert(Question q)
        {
            dalc.Insert(q);
        }

        public List<Question> GetQuestionsByClassAndLecture(int sube, string lectureName)
        {
           return  dalc.GetQuestionsByClassAndLecture(sube,lectureName);
        }

        public List<ExamReplyByUser> GetExamAnswersByTypeClassIdAndWeek(ExamType quiz, ObjectId classId, int activeWeek)
        {
            return dalc.GetExamAnswersByTypeClassIdAndWeek(quiz, classId, activeWeek);
        }

        public List<Exam> GetExamByTypeClassIdAndWeek(ExamType ödev, ObjectId classId, int activeWeek)
        {
            return dalc.GetExamByTypeClassIdAndWeek(ödev, classId,activeWeek);
        }

        public void UserExamAnswersInsert(ExamReplyByUser examReplyByUser)
        {
                dalc.UserExamAnswersInsert(examReplyByUser);
        }

        public List<Question> GetSubeDersID(int? sube, ObjectId dersId)
        {
          return  dalc.GetSubeDersID(sube, dersId);
        }

        public void QuestionaryCreate(List<Questionary> lqry)
        {
            dalc.QuestionaryCreate(lqry);
        }

        public List<Questionary> QuestionaryGetByExamName(string examName)
        {
            return dalc.QuestionaryGetByExamName(examName);
        }

        public List<ExamReplyByUser> GetExamAnswersByTypeUserIdAndWeek(ExamType quiz, ObjectId id, int activeWeek)
        {
            return dalc.GetExamAnswersByTypeUserIdAndWeek(quiz,id,activeWeek);
        }

        public List<Question> GetQuestionList()
        {
            return dalc.GetQuestionList();
        }

        public void QuestionaryYorumInsert(List<QuestionaryCokluZekaComment> lczc)
        {
            dalc.QuestionaryYorumInsert(lczc);
        }

        public List<Exam> GetQuestionaryList()
        {
            return dalc.GetQuestionaryList();
        }

        public ExamReplyByUser QuestionaryResult(ObjectId objectId)
        {
            return dalc.QuestionaryResult(objectId);
        }

        public Exam GetExamByID(ObjectId objectId)
        {
            return dalc.GetExamByID(objectId);
        }

        public List<ExamReplyByUser> QuestionaryResults()
        {
            return dalc.QuestionaryResults();
        }

        public void UpdateExamById(Exam e)
        {
            dalc.UpdateExamById(e);
        }

        public List<QuestionaryCokluZekaComment> QuestionaryResultComment(List<string> list)
        {
            return dalc.QuestionaryResultComment(list);
        }
        public List<QuestionaryCokluZekaComment> QuestionaryResultComment()
        {
            return dalc.QuestionaryResultComment();
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
          return   dalc.GetAnswerByUserIDAndExamID(objectId, examId);
        }
        public List<ExamReplyByUser> GetAnswersByUserID(ObjectId objectId)
        {
            return dalc.GetAnswersByUserID(objectId);
        }

        public ExamReplyByUser GetAnswerByExamId(ObjectId objectId)
        {
            return dalc.GetAnswerByExamId(objectId);
        }
        public ExamReplyByUser GetAnswerByExamIdAndUserID(ObjectId objectId ,ObjectId userID)
        {
            return dalc.GetAnswerByExamIdAndUserID(objectId,userID);
        }
        

        public List<ExamReplyByUser> GetAnswersByExamId(ObjectId objectId)
        {
            return dalc.GetAnswersByExamId(objectId);
        }

        public ExamReplyByUser GetAnswerByUserID(ObjectId objectId)
        {
            return dalc.GetAnswerByExamId(objectId);
        }

        public void UpdateQuestionById(Question q)
        {
            dalc.UpdateQuestionById(q);
        }

        public void UserExamAnswersUpdateMultiple(List<ExamReplyByUser> answers)
        {
            dalc.UserExamAnswersUpdateMultiple(answers);
        }

        public List<ObjectId> GetExamsByUserIDFromAnswers(ObjectId objectId)
        {
            return dalc.GetExamsByUserIDFromAnswers(objectId);
        }

        public List<ExamReplyByUser> GetAnswers()
        {
            return dalc.GetAnswers();
        }

        public void InsertEtkinlik(Question q)
        {
            dalc.InsertEtkinlik(q);
        }

        public ExamReplyByUser GetAnswerByID(ObjectId objectId)
        {
            return dalc.GetAnswerByID(objectId);
        }

        public List<Exam> GetQuizTypeAndFKClassID(ExamType quiz, ObjectId fK_ClassID)
        {
            return dalc.GetQuizTypeAndFKClassID(quiz,fK_ClassID);
        }

        public List<Question> GetByType(QuestionType ucuAcik)
        {
            return dalc.GetByType(ucuAcik);
        }

       
    }
  
}
