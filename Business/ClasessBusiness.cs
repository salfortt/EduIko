using Data;
using Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClasessBusiness
    {
        private ClassesData _dalc;
        private ClassesData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = ClassesData.GetInstance();

                return _dalc;
            }
        }
        private ClasessBusiness() { }
        private static ClasessBusiness Instance;
        public static ClasessBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new ClasessBusiness();

            return Instance;
        }

        public List<Grade> GetGradeis(string sezon)
        {
             
                return dalc.GetGradeis(sezon);
             
        }

        public void InsertClassRoom(ClassRoom cr)
        {
            dalc.InsertClassRoom(cr);
        }

        public Grade GetGradeByMeetingID(string meetingID)
        {
            return dalc.GetGradeByMeetingID(meetingID);
        }

        public void InsertGrade(Grade g)
        {
            dalc.InsertGrade(g);

        }


        public List<Grade> GetGradeByUserID(ObjectId id)
        {
            return dalc.GetGradeByUserID(id);
        }

        public Grade GetGradeByID(ObjectId objectId)
        {
            return dalc.GetGradeByID(objectId);
        }

        public void UpdateGradeByID(Grade g)
        {
            dalc.UpdateGradeByID(g);
        }

        public void InsertTrackingData(OnlineLectureTracking onlineLectureTracking)
        {
            dalc.InsertTrackingData(onlineLectureTracking);
        }

        public long GetOnlineLectureTrackingByUserIdAndWeekAndLectureId(ObjectId userId, int activeWeek, ObjectId lectureId)
        {
          return  dalc.GetOnlineLectureTrackingByUserIdAndWeekAndLectureId(userId, activeWeek, lectureId);
        }
        public long GetOnlineLectureTrackingByUserIdAndWeekAndOnlineLectureIds(ObjectId userId,  List<ObjectId> onlineLectureIds)
        {
            return dalc.GetOnlineLectureTrackingByUserIdAndWeekAndOnlineLectureIds(userId,  onlineLectureIds);
        }
        public List<OnlineLecture> GetOnlineLectureByClassIdAndWeek(ObjectId id, int activeWeek,  OnlineClassStatusEnum status)
        {
            return dalc.GetOnlineLectureByClassIdAndWeek(id,activeWeek,status);
        }

        public List<OnlineLectureTracking> GetTrackingDataByLectureId(ObjectId lectureId)
        {
          return  dalc.GetTrackingDataByLectureId(lectureId);
        }
        public List<OnlineLectureTracking> GetTrackingsData()
        {
            return dalc.GetTrackingsData();
        }
        public void InsertOnlineLecture(OnlineLecture onlineLecture)
        {
            dalc.InsertOnlineLecture(onlineLecture);
        }
        public void InsertOnlineServerInfo(OnlineServerInfo server)
        {
            dalc.InsertOnlineServerInfo(server);
        }
        public List<OnlineServerInfo> GetOnlineServersInfo()
        {
           return   dalc.GetOnlineServersInfo();
        }
         
        public List<OnlineLecture> GetOnlineLectures()
        {
           return dalc.GetOnlineLectures();
        }

        public List<OnlineLecture> GetOnlineLectureByClassIdAndWeek(ObjectId id, int activeWeek)
        {
            return dalc.GetOnlineLectureByClassIdAndWeek(id,activeWeek);
        }

        public List<OnlineLecture> GetOnlineActiveLecturesByClassID(ObjectId classId)
        {
            return dalc.GetOnlineActiveLecturesByClassID(classId);
        }
        public List<OnlineLecture> GetOnlineEndedLecturesByClassID(ObjectId classId)
        {
            return dalc.GetOnlineEndedLecturesByClassID(classId);
        }
        
        public OnlineLecture GetOnlineLectureByID(ObjectId Id)
        {
            return dalc.GetOnlineLectureByID(Id);
        }

        public void UpdateOnlineLecture(OnlineLecture ol)
        {
            dalc.UpdateOnlineLecture(ol);
        }

        public long GetOnlineActiveLectureCountByClassID(ObjectId objectId)
        {
            return dalc.GetOnlineActiveLectureCountByClassID(objectId);  
        }

        public long GetOnlineFinishedLectureCountByClassID(ObjectId objectId)
        {
            return dalc.GetOnlineFinishedLectureCountByClassID(objectId);
        }

        public void UpdateOnlineLectureTracking(OnlineLectureTracking item)
        {
            dalc.UpdateOnlineLectureTracking(item);
        }

      
    }
}
