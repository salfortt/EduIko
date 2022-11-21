using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class LectureDay
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public string ClassName { get; set; }
        public DateTime DateandTime { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }
        public List<string> Lecture { get; set; }
    }
    public class Lecture
    {
        public ObjectId id { get; set; }
        public string Name { get; set; }
        public bool IsViewOnQuiz { get; set; }
        public List<int> Grade { get; set; }
        public bool IsActive { get; set; }
        public bool IsViewOnReportCard { get; set; } = false;

    }

    public class WordAndExplain//Kazanım
    {
        public string Word { get; set; }
        public string Explain { get; set; }
    }
        public class Earnings//Kazanım
    {
        public ObjectId id { get; set; }
        public ObjectId FK_AddedUserID  { get; set; }
        public string Sube { get; set; }
        public string LectureName { get; set; }
        public string Subject { get; set; }
        public string SubSubject { get; set; }
        public int Unite { get; set; }
        public int QuestionCount { get; set; }
        public List<LookedUp> LookedUp { get; set; }
        public List<string> EarningItems { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public List<string> Spot { get; set; }
        public List<string> OutSource { get; set; }
        public List<WordAndExplain> WordAndExplain { get; set; }
        public List<ContentFile> Files { get; set; }
        public bool IsActive { get; set; }
    }

            public class ContentFile
            {
            public string Extension { get; set; }
            public string Path { get; set; }
            public string ExtensionIcon { get; set; }

    }
    public class DersList
    {
        public string Sinif { get; set; }//aynı konu ya da alt konuda sınıflarda çakışma oldu
        public string Ders { get; set; }
        public List<Konu> Konular { get; set; }
    }

    public class Konu
    {
        public string KonuAdi { get; set; }
        public bool IsContent { get; set; }
        public List<string> Basliklar { get; set; }
    }

}
