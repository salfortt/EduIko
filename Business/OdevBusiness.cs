using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;
using Common;

namespace Business
{

   public class OdevBusiness 
    {
        private OdevBusiness() { }
        private static OdevBusiness Instance;

        public static OdevBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new OdevBusiness();

            return Instance;
        }



        private OdevData _dalc;
        private OdevData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = OdevData.GetInstance();

                return _dalc;
            }
        }

        private MissionBusiness _MissionB;
        private MissionBusiness MissionB
        {
            get
            {
                if (_MissionB == null)
                    _MissionB = MissionBusiness.GetInstance();

                return _MissionB;
            }
        }

        private MissionOperations _MissionO;
        private MissionOperations MissionO
        {
            get
            {
                if (_MissionO == null)
                    _MissionO = MissionOperations.GetInstance();

                return _MissionO;
            }
        }


        public List<Exam> GetExam(ObjectId fK_ClassId ,ExamType eType)
        {
          return  dalc.GetExam(fK_ClassId,   eType);
        }

        public void Insert(Exam e)
        {
          bool result=  dalc.Insert(e);
            if (result)
            {
                //todo:Gürkan miison kontrol et
                List<ObjectId> appointedList = new List<ObjectId>();
                //AppointedWhoisType ap;
                 
                if (e.ExamToUsersByID != null && e.ExamToUsersByID.Count > 0)
                { 
                    appointedList = e.ExamToUsersByID;
                  //  ap = AppointedWhoisType.Student;
                }
                else { 

                    appointedList.AddRange(AccountBusiness.GetInstance().GetUsersByGradeID(e.FK_ClassID).Select(s=>s.id).ToList() );
                  //  ap = app.Class;
                }
                //Mission Mission = MissionO.CreateMission(e.FK_TeacherId, true, null, e.id.ToString(), e.ProjectTitle, e.ProjectContent, null, e.StartDate, e.EndDate, e.ExamFiles != null ? e.ExamFiles.Select(s => s.FilePath).ToList() : new List<string>()
                //    , appointedList, ap, MissionType.Exam, MissionCreateType.Created, MissionJobPeriodType.OneTime, MissionStatus.Created
                //    );

                // result = MissionB.InsertMission(Mission); //Mission ekleniyorsa info relation bilgisis basılıyor


                //if(result)
                //  MissionB.CreateMissionRelation(MissionO.CreateMissionTracking(Mission)); //Tüm işlem başarılı ise  görev tanımlanır
            }

           
        }



        public void UpdateByUserLookedUp(Exam e)
        {
            dalc.UpdateByUserLookedUp(e);
        }

        public List<Exam> GetExamsByType(ExamType type)
        {
          return  dalc.GetExamsByType(type);
        }

        public List<Exam> GetActiveExamClassOrPersonal(ObjectId studentID, ObjectId classID)
        {
            return dalc.GetActiveExamClassOrPersonal(studentID, classID);
        }
        public List<Exam> GetOldExamClassOrPersonal(ObjectId studentID, ObjectId classID)
        {
            return dalc.GetOldExamClassOrPersonal(studentID, classID);
        }
        public void UpdateExamById(Exam e)
        {
            dalc.UpdateExamById(e);
        }

        public List<Exam> GetExams(ExamType eType)
        {
            return dalc.GetExams(eType);
        }
        public List<Exam> GetExams()
        {
            return dalc.GetExams();
        }

        public Exam GetExamByID(ObjectId objectId)
        {
            return dalc.GetExamByID(objectId);
        }

        public List<Exam> GetOldExam(ObjectId fK_ClassId)
        {
            return dalc.GetOldExam(fK_ClassId);
        }

    

        public List<Exam> GetExamByUserID(ObjectId UserId)
        {
            return dalc.GetExamByUserID(UserId);
        }
        public List<Exam> GetOldExamByUserID(ObjectId UserId)
        {
            return dalc.GetOldExamByUserID(UserId);
        }
        public List<Exam> GetExamByUserIDAndType(ObjectId UserId,ExamType eType)
        {
            return dalc.GetOldExamByUserID(UserId);
        }

        public List<Exam> GetExamsByIDs(List<ObjectId> list)
        {
            return dalc.GetExamsByIDs(list);
        }

        public void PassiveToQuizByIds(List<ObjectId> quizIds)
        {
            dalc.PassiveToQuizByIds(quizIds);
        }

        public List<Exam> GetAllActiveExamClassOrPersonal()
        {
            return dalc.GetAllActiveExamClassOrPersonal(); 

        }
        public List<Exam> GetAllOldExamClassOrPersonal()
        {
            return dalc.GetAllOldExamClassOrPersonal();

        }
        public void InsertExamTransferByEduiko(ExamTransferEduIKO e)
        {
             
            dalc.InsertExamTransferByEduiko(e);
        }

        public List<Exam> GetExamsByUserIDandClassID(ObjectId userId, ObjectId fK_ClassId, int page,int pageSize,string search)
        {
            return dalc.GetExamsByUserIDandClassID(userId, fK_ClassId,page,pageSize,search);
        }

        public List<Exam> GetExamQuizies(  int page, int pageSize,string search)
        {
            return dalc.GetExamQuizies(page,pageSize, search);
        }

        public long GetExamsByClassIDGetCount( ObjectId fK_ClassId)
        {
            return dalc.GetExamsByClassIDGetCount(fK_ClassId);
        }

        public long GetExamsCount()
        {
         return dalc.GetExamsCount();
        }
     
        public void InsertStudentFiles(List<StudentFile> LSF)
        {
              dalc.InsertStudentFiles(LSF);
        }

        public List<StudentFile> GetAllStudentFilesByOdevID(List<ObjectId> loid)
        {
            return dalc.GetAllStudentFilesByOdevID(loid);
        }

        public List<StudentFile> GetStudentFilesByOdevIDsAndStudentId(List<ObjectId> loid, ObjectId userId)
        {
            return dalc.GetStudentFilesByOdevIDsAndStudentId(loid, userId);
        }

        public List<StudentFile> GetAllStudentFiles()
        {
            return dalc.GetAllStudentFiles();
        }
    }
}
