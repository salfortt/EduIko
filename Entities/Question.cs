using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public enum QuestionType
    {
        Test,UcuAcik,EtkinlikKavram,EtkinlikBosluk,EtkinlikYanlisDogru

    }

    [Serializable]
    public class GeneralQuizReplyState
    {
        public ObjectId FK_ExamID { get; set; }
        public bool OngoingSession { get; set; } = false;//devam eden Sınav mı? ilk geldiğinde false ikincisinde true 
        public DateTime IsWaitingOverDate { get; set; }  //Bekleme süresi bittimi devam  eden Sınav mı? ilk geldiğinde false ikincisinde true 
        public bool IsWaitingOver { get; set; } = false;//Beklem esüresi bittimi  eden Sınav mı? ilk geldiğinde false ikincisinde true 
        public bool IsExamFinish { get; set; } = false;
        public List<ObjectId> FK_FinihedSessionIds { get; set; } = new List<ObjectId>();//biten sınav


    }
    [Serializable]
    public class ExamReplyAutoExamByUser
    {
        public ObjectId id { get; set; }
        public ObjectId FK_UserID { get; set; } = ObjectId.Parse("000000000000000000000000");
        public ObjectId FK_EarningID { get; set; }
        public string SubSubject { get; set; }
        public int Sinif { get; set; }
        public string LectureName { get; set; }
        public string UserNameSurname { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public DateTime EndDate { get; set; }
        public DateTime DateUnending { get; set; }
        public TimeSpan ExamDuration { get; set; }
        public List<ObjectId> QuestionIds { get; set; }
        public ExamType ExamType { get; set; } //= ExamType.AutoExam;
        public List<QuestionAutoExamAnswer> QuestionAnswer { get; set; }


    }
    [Serializable]
    public class Estimate
    {
        public string LectureName { get; set; }
        public int LectureEstimate { get; set; }

    }

    [Serializable]
    public class QuestionAutoExamAnswer
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public ObjectId FK_QuestionID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public string Choosen { get; set; }
        public decimal Puan { get; set; }
        public bool IsItTrue { get; set; }


    }
    [Serializable]
    public class Question
    {
        public ObjectId id { get; set; } 
        public ObjectId FK_AddUserID{ get; set; }
        public QuestionType QuestionType { get; set; }
        public string AddUserNameSurname { get; set; }
        public string Content { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string Subject { get; set; }
        public string SubSubject { get; set; }
        public string Earning { get; set; }
        public ObjectId FK_LectureID { get; set; }
        public ObjectId FK_EarningID { get; set; }
        public string LectureName { get; set; }
         public int Order { get; set; }
        public int Hard { get; set; }
        public int Point { get; set; }
        public string ImgUrl { get; set; }
        public List<Answer> Replies { get; set; }
        public DateTime Dates { get; set; }//sırası ile ekleme ve güncelleme tarihleri
        public List<WordAndExplain> WordAndExplain { get; set; }
        public List<UcuAcik> UcuAcikAnahtar { get; set; }
        public bool IsActive { get; set; }

    }

    [Serializable]
    public class UserHomeInfo {
        public ObjectId id { get; set; }
        public int QuizCount { get; set; }
        public int QuestionCount { get; set; }
        public int CorrectQuestionCount { get; set; }
        public int FalseQuestionCount { get; set; }

    }

    [Serializable]
    public class Questionary
    {
        public ObjectId id { get; set; }
        public string Alan { get; set; }
        public string AlanDigerAd { get; set; }
        public string Soru { get; set; }
        public string Bolum { get; set; }
        public int Puan { get; set; }
        public string AnketAdi { get; set; }

    }


    [Serializable]
    public class Answer//sorunun cevapları
    {
        public ObjectId id { get; set; }
        public string Text { get; set; }
        public string Option { get; set; }
        public bool IsPhoto { get; set; }
        public string ImgUrl { get; set; }
        public int Order { get; set; }
        public bool IsTrue { get; set; }

    }

    [Serializable]
    public class ExamReplyByUser {
        public ObjectId id { get; set; }
        public ObjectId FK_UserID { get; set; }
        public ObjectId FK_ExamID { get; set; }
        public ObjectId FK_LectureID { get; set; }//yeni set et
        public ObjectId FK_ClassID { get; set; }//yeni set et
        public ObjectId FK_ParentExamID { get; set; }//yeni set et
        public string LectureName { get; set; }
        public int Week { get; set; }
        public string QuizName { get; set; }
        public int Sinif { get; set; }
        public string Sube { get; set; }
        public string SezonName { get; set; }
        public string UserNameSurname { get; set; }
     
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public ExamType ExamType { get; set; }
        public ExamResultStatus ExamResultStatus { get; set; }
        public List<QuestionAnswer> QuestionAnswer { get; set; }
        public List<QuestionaryResult> QuestionaryResult { get; set; }
        public List<Estimate> FirstEstimate { get; set; }
        public List<Estimate> LastEstimate { get; set; }
    }
    [Serializable]
    public class QuizResult
    {
   //     public ObjectId id { get; set; }
        public string Alan { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Okul { get; set; }
        public string Sinif { get; set; }
        public ObjectId FK_QuesionID { get; set; }
        public List<ObjectId> UsersCorrect { get; set; }
        public List<UserFalseAndChooen> UserFalseAndChooen { get; set; }
        public int CorrectCount { get; set; }
        public int FalseCount { get; set; }
   //     public decimal AlanToplamPuan { get; set; }
     //   public string AlanSonuc { get; set; }


    }
    [Serializable]
    public class UserFalseAndChooen
    {
        public ObjectId FK_UserID { get; set; }
        public string Choosen { get; set; }

    }
    [Serializable]
    public class QuestionaryResult
    {
        public ObjectId id { get; set; }
        public string Alan { get; set; }
        public string Bolum { get; set; }
        public decimal AlanToplamPuan { get; set; }
        public string AlanSonuc { get; set; }


    }
    [Serializable]
    public class QuestionaryCokluZekaComment
    {
        public ObjectId id { get; set; }
        public string Alan { get; set; }
        public string AlanBasligi { get; set; }
        public string AlanYorum { get; set; }

        public List<AltAlanYorum> Yorumlar { get; set; }


    }

    [Serializable]
    public class AltAlanYorum
    {
        public string AltAlanBasligi { get; set; }
        public string AltAlanBasligiYorumu { get; set; }
    }
    [Serializable]
    public class QuestionaryResultComment
    {
        public ObjectId id { get; set; }
        public string Alan { get; set; }
        public string YorumBasligi { get; set; }
        public string BasliginYorumu { get; set; }

    }
    [Serializable]
    public class QuestionAnswer
    {
        public ObjectId id { get; set; }
        public ObjectId FK_QuestionID { get; set; }
        public int Order { get; set; }
        public ObjectId FK_UserID { get; set; }
 
        public ObjectId FK_ExamID { get; set; }
        public ObjectId FK_ProvinceID { get; set; }//şehir ortalaması
        public ObjectId FK_DistrictID { get; set; }//ilçe ortalması
        public ObjectId FK_SchoolID { get; set; }//okul ortalaması
        public ObjectId FK_ClassID { get; set; }//Sınıf ortalaması

        public string Choosen { get; set; }
        public decimal Puan { get; set; }
        public string Alan { get; set; }
        public Reminding Reminding { get; set; }
        public string Bolum { get; set; }
        public bool IsItTrue { get; set; }
        public bool secimIptal { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Reply> UserReplies { get; set; }//ilk görüş zamanı add çıkış zamanı sonraki görüş zamanı eklenecek sonra çıkış zamanı kaç kezde toplam kaç süre harcamış göreceğiz
    }

    [Serializable]
    public class Reply //Çözme kararı 
    {
        public ObjectId id { get; set; }
        public ObjectId FK_QuestionID { get; set; }
        public string Choosen { get; set; }
        public bool IsItTrue { get; set; }
        public bool FirstTime { get; set; }
        public bool secimIptal { get; set; }
        public TimeSpan ReadTime { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    [Serializable]
    public enum Reminding
    {
        ZamanaIhtiyacimVar = 1, YuzdeElli = 2, EminDegilim = 3, FikrimYok = 4
    }
}
