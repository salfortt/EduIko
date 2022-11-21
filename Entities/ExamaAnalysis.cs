using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ExamaAnalysis
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public ObjectId FK_UserId { get; set; }
        public string NameSurname { get; set; }
        public List<EduPeriod> SezonReports { get; set; }
    }

    public class EduPeriod
    {
        public string PeriodName { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public ObjectId FK_QuizId { get; set; }
        public string PeriodName { get; set; }
        public ExamType ExamType { get; set; }
        public ObjectId FK_ClassId { get; set; }
        public ObjectId FK_KurumId { get; set; }
        public ObjectId FK_TeacherId { get; set; }//Sistemi öğretmen satın almışsa
        public string QuizName { get; set; }
        public QuizType QuizType { get; set; }
        public int Sube { get; set; }
        public string SubeAdi { get; set; }
        public string KurumAdi { get; set; }
        public int IlSiralamasi { get; set; }
        public int IlceSiralamasi { get; set; }
        public List<LectureResult> LectureResult { get; set; }



    }
    public enum QuizType
    {
        Quiz = 1,
        Etkinlik = 2,
        GenelDegerlendirme = 3,
        KazanimDegerlendirme = 4,
        Rehberlik = 5,
        KTT = 6,
        EtkinlikSoruKoku = 7,
        EtkinlikBoslukDoldurma = 8,
        EtkinlikTerim = 9,
        EtkinlikDogruYanlis = 10,
        EtkinlikZamanlaCoz = 11,
        KazanimDegerlendirmeSayisal = 12,
        KazanimDegerlendirmeSozel = 13


    }

    public class LectureResult
    {
        public string SezonName { get; set; }
        public string QuizName { get; set; }
        public ExamType ExamType { get; set; }
        public string LectureName { get; set; }
        public int QuestionCount { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public int NullCount { get; set; }
        public float PercentageOfSsuccess { get; set; }
        public float RemainingCount { get; set; }
        public TimeSpan SessionTime { get; set; }

    }


}
