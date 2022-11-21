using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;

namespace BusinessLayer
{

   public class LectureBusiness
    {
        private LectureBusiness() { }
        private static LectureBusiness Instance;

        public static LectureBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new LectureBusiness();

            return Instance;
        }

      

        private LectureData _dalc;
        private LectureData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = LectureData.GetInstance();

                return _dalc;
            }
        }

        public List<Lecture> GetLectures()
        {
            return dalc.GetLectures();
        }
        public  Lecture  GetLectureByID(ObjectId id)
        {
            return dalc.GetLectureByID(id);
        }
        public void Insert(Lecture l)
        {
            dalc.Insert(l);
        }

        public void InsertList(List<Lecture> ll)
        {
            dalc.InsertList(ll);
        }

        public void InsertEarning(Earnings s)
        {
            dalc.InsertEarning(s);
        }

        public List<Earnings> GetEarningsByUserId(ObjectId id)
        {
            return dalc.GetEarningsByUserId(id);
        }

        public LessonProperties GetLessonProperties(int sube)
        {
            return dalc.GetLessonProperties(sube);
        }

        public List<Earnings> GetEarnings()
        {
            return dalc.GetEarnings();
        }
        public byte[] GetEarningsZip()
        {
            return dalc.GetEarningsZip();
        }


        public Earnings GetEarningsById(ObjectId objectId)
        {
            return dalc.GetEarningsById(objectId);
        }

        public void RemoveEarningsById(ObjectId objectId)
        {
            dalc.RemoveEarningsById(objectId);
        }

        public void UpdateEarningsById(Earnings s)
        {
            dalc.UpdateEarningsById(s);
        }

        public List<Earnings> GetEarningsByLectureName(List<string> lst)
        {
            return dalc.GetEarningsByLectureName(lst);
        }

        public float GetReadTime(ObjectId userID, DateTime createdDate)
        {
            return dalc.GetReadTime(userID,createdDate);
        }

        public Earnings GetEarningBySubSubjectAndSinif(string subSubject, string sinif)
        {
            return dalc.GetEarningBySubSubjectAndSinif(subSubject,sinif);
        }
        public List<Earnings> GetEarningByGradeAndLectureName(string grade, string lectureName)
        {
            return dalc.GetEarningByGradeAndLectureName(grade, lectureName);
        }
        public void InsertLessonProperties(LessonProperties lp)
        {
              dalc.InsertLessonProperties(lp);
        }
     

    }
}
