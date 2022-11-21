using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    public class ExamTransferEduIKO
    {
        public ObjectId id { get; set; }
        public ObjectId FK_TeacherId { get; set; }
        public ObjectId FK_ClassID { get; set; }

        public List<ObjectId> ExamToUsersByID { get; set; }

        public string Sezon { get; set; }
     public   int Week { get; set; }
        public string Teacher { get; set; }
      public string GradeName { get; set; }
      public string LectureName { get; set; }
      public DateTime StartDate { get; set; }
      public string StartTime { get; set; }
      public string FinishTime { get; set; }
      public DateTime TeacherLastLookUpDate { get; set; }//kalkacak
      public DateTime StudentLastLookUpDate { get; set; }//kalkacak
      public DateTime EndDate { get; set; }
      public int Duration { get; set; }//Quiz ya da benzeri uygulamalar için
      public int BreakDuration { get; set; }
      public ExamType ExamType { get; set; }
      public string ProjectTitle { get; set; }
      public string ProjectDescription { get; set; }
      public string ProjectContent { get; set; }//kalkacak
      public int QuestionCount { get; set; }
      public bool IsWaitFinishDate { get; set; }
      public bool IsActive { get; set; }
      public bool IsDeleted { get; set; }
      public bool IsPublished { get; set; }
      public bool IsUpdated { get; set; }
      public bool IsOrderExam { get; set; }
       
        //[BsonDateTimeOptions(DateOnly = true)]
        //public DateTime DateOfBirth { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
      public DateTime CreatedDate { get; set; }
      public DateTime UpdatedDate { get; set; }
      public List<LookedUp> LookedUp { get; set; }//kalkacak
       
      public List<Files> ExamFiles { get; set; }//kalkacak
      public List<Message> ExamMessages { get; set; }//kalkacak
      public List<ObjectId> Questions { get; set; }
      public List<ObjectId> ExamsIDsForGenerealQuiz { get; set; }//ekli sayisal ve sözel kazanim değerlendirmeler  her yerde ekli şuan düzeltip tek tip haline getiremiyorum
      public List<ObjectId> FK_SubSessionIDs { get; set; }//ekli sınavlar
      public ObjectId FK_ParentExamID { get; set; }
      public List<ExamSummary> ExamSummaries { get; set; }
      public List<ExamReport> ExamReports { get; set; }
      public List<Questionary> Questionaries { get; set; }
      public List<string> RehberlikSorulari { get; set; }
      public string ImgURL { get; set; }
        public List<StudentFile> StudentFiles { get; set; }//kalkacak
    }


    public interface ExamTransfer
    {
         ObjectId id { get; set; }
         ObjectId FK_TeacherId { get; set; }
         ObjectId FK_ClassID { get; set; }
        
         List<ObjectId> ExamToUsersByID { get; set; }
        
         string Sezon { get; set; }
          int Week { get; set; }
        string Teacher { get; set; }
         string GradeName { get; set; }
         string LectureName { get; set; }
         DateTime StartDate { get; set; }
         string StartTime { get; set; }
         string FinishTime { get; set; }
         DateTime TeacherLastLookUpDate { get; set; }//kalkacak
         DateTime StudentLastLookUpDate { get; set; }//kalkacak
         DateTime EndDate { get; set; }
         int Duration { get; set; }//Quiz ya da benzeri uygulamalar için
         int BreakDuration { get; set; } 
         ExamType ExamType { get; set; }
         string ProjectTitle { get; set; }
         string ProjectDescription { get; set; }
         string ProjectContent { get; set; }//kalkacak
         int QuestionCount { get; set; }
         bool IsWaitFinishDate { get; set; } 
         bool IsActive { get; set; }
         bool IsDeleted { get; set; }
         bool IsPublished { get; set; }
         bool IsUpdated { get; set; }
         bool IsOrderExam { get; set; }

        //[BsonDateTimeOptions(DateOnly = true)]
        //public DateTime DateOfBirth { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
          DateTime CreatedDate { get; set; }
          DateTime UpdatedDate { get; set; }
          List<LookedUp> LookedUp { get; set; }//kalkacak
         
          List<Files> ExamFiles { get; set; }//kalkacak
          List<Message> ExamMessages { get; set; }//kalkacak
        List<ObjectId> Questions { get; set; }
           List<ObjectId> ExamsIDsForGenerealQuiz { get; set; }//ekli sayisal ve sözel kazanim değerlendirmeler  her yerde ekli şuan düzeltip tek tip haline getiremiyorum
          List<ObjectId> FK_SubSessionIDs { get; set; }//ekli sınavlar
          ObjectId FK_ParentExamID { get; set; }
          List<ExamSummary> ExamSummaries { get; set; }
          List<ExamReport> ExamReports { get; set; }
          List<Questionary> Questionaries { get; set; }
          List<string> RehberlikSorulari { get; set; }
          string ImgURL { get; set; }
          List<StudentFile> StudentFiles { get; set; }//kalkacak
    }
    [Serializable]
    public class ExamSummary
    {

        public string ExamName { get; set; }
        public ObjectId FK_ExamID { get; set; }
        public ExamType ExamType { get; set; }
        public int QuestionCount { get; set; }
        public string AddedLesson { get; set; }

    }

    [Serializable]
    public class Exam: ExamTransfer
    {
        public ObjectId id { get; set; }

        public  int BreakDuration { get; set; } = 5;//oturumlar arası bekleme süresi default 5 dk
        public int Week { get; set; }
        public bool IsWaitFinishDate { get; set; } = false;//sıralama göstermek için bitiş tarihi bekleniyor
        public bool IsOrderExam { get; set; }
        public int QuestionCount { get; set; }
        public ObjectId FK_ParentExamID { get; set; }
        public List<ExamSummary> ExamSummaries { get; set; }
        public List<ObjectId> FK_SubSessionIDs { get; set; }//ekli sınavlar
        public ObjectId FK_TeacherId { get; set; }
        public ObjectId FK_ClassID { get; set; }
        public ObjectId FK_LectureID { get; set; }
        public string LectureName { get; set; }
        public List<ObjectId> TekrarCozecekOgrler { get; set; }
        public string Sezon { get; set; }
        public string Teacher { get; set; }
        public string GradeName { get; set; }
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public DateTime TeacherLastLookUpDate { get; set; }
        public DateTime StudentLastLookUpDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }//Quiz ya da benzeri uygulamalar için
        public ExamType ExamType { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectContent { get; set; }
        public int QueriesCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<LookedUp> LookedUp{ get; set; }
        public List<ObjectId> ExamToUsersByID { get; set; }
        public List<Files> ExamFiles { get; set; }
        public List<Message> ExamMessages { get; set; }
        public List<ObjectId> Questions { get; set; }
        public List<ObjectId>  ExamsIDsForGenerealQuiz { get; set; }
        public List<ExamReport> ExamReports { get; set; }
        public List<Questionary> Questionaries { get; set; }
        public List<string> RehberlikSorulari { get; set; }
        public string ImgURL { get; set; }

        public List<StudentFile> StudentFiles { get; set; }
        
    }
    [Serializable]
    public class StudentFile
    {
        public ObjectId id { get; set; }
        public ObjectId FK_OdevID { get; set; }
        public string FilePath { get; set; }
        public string AddedUserNameAndSurname { get; set; }
        public ObjectId FK_UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public bool IsTeacherFile { get; set; }

    }

    [Serializable]
    public class ExamReport
    {
       
        public ObjectId FK_UserId { get; set; }

        public string UserNameAndSurname { get; set; }
        public string Note { get; set; }
        public int Point { get; set; }
        public ExamReportType ExamReportType { get; set; }
        public bool TryCheck { get; set; }
        public DateTime TryCheckCreatedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    [Serializable]
    public class LookedUp
    {
        public ObjectId id { get; set; }
        public ObjectId FK_UserId { get; set; }
        public UserTypeEnum UserType { get; set; }
        public InfoTypeEnum InfoType { get; set; }
        public string Url { get; set; }
        public string UserNameAndSurname { get; set; }
        public float SayfadaKalmaSuresi { get; set; }
        public DateTime CreatedDate { get; set; }

    }
    [Serializable]
    public enum InfoTypeEnum
    {
        LogOut = 0,Login=1,  Odev = 2, Mesaj = 3, Ders = 4, Quiz = 5,Update=6,Delete=7,Create=8
    }
    [Serializable]
    public class Files
    {
        public ObjectId id { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }


    }
    [Serializable]
    public enum ExamResultStatus
    {
        Baslatildi,DevamEdiyor,TekrarCoz,Bitti //Genel Değerlerndirme
    }
    [Serializable]
    public enum ExamType {
        Ödev,Sınav,Quiz,Proje,KTT,GenelDegerlendirme,Anket,KazanimDegerlendirme,Rehberlik,KttEtkinlik,KazanimDegerlendirmeSozel,KazanimDegerlendirmeSayisal 
    }
    [Serializable]
    public enum ExamReportType
    {
      Yapılmamış,Eksik,Tamamlanmış,Tebrik
    }

}
