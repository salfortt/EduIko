using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Mission // bu class tablo olarak ana görev tanımı tutulacak, sonraki alt tüm işlemler bir log colection a eklenecek
    {

        /// <summary>
        /// Burda yöneticiler iş oluşturabilir  ve iş tanımlayabilirler... 
        /// check list oluşturup kontrolünü raporlayabilir
        ///  bu sadece Mission kontrol omurgası 
        ///  
        /// haricinde yapılması gereken check list collection olmalı ve buradaki tüm hareketlerde ona basılmalı ... 
        /// mesajlar Mission konusu olmadığı için ... daha az bilgi ile check edilecek status halinde relation collection oluştur
        /// ayrıca otomatik oluşturulacak joblarıda sisteme girmeli ve otomatik olarak bu reletion collectionuna işi düşürmeli
        /// </summary>
        public ObjectId id { get; set; }
        public bool IsMainMisson { get; set; } = false;//Ana görev mi?
        public ObjectId FK_MainID { get; set; }
        public ObjectId FK_ReletionJobID { get; set; }
        public List<SubMission> SubMissions { get; set; }

        public ObjectId FK_InitiatorID { get; set; } //başlatan
        public MissionProperties MissionProperties { get; set; }
     //   public List<MissionSequence> MissionSequence { get; set; }  FKMainId ye bağlı olanları çağır ve created date e göre sırala oluşum sırası çıkar
      //  public ObjectId FK_ParentMissionID { get; set; }
      
      //  public string InitiatorName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MissionStatus MissionStatus { get; set; }
        public List<CheckNote> CheckNotes { get; set; } = new List<CheckNote>();
        public DateTime CreatedDate { get; set; }
        

    }
    public class MissionProperties 
    {
        public MissionCreateType MissionCreateType { get; set; }
        public MissionType MissionType { get; set; }
        public MissionJobPeriodType MissionJobPeriod { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public UserTypeEnum UserTypeEnum { get; set; }
        public List<ObjectId> AppointedList { get; set; } //atananlar
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CheckNote
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public ObjectId FK_UserID { get; set; }
        //public string UserName { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public List<string> FilesPath { get; set; }
    }

    //public class MissionSequence
    //{/*
    //    1 - Eylem Hoca görevlendir Seba Hocayı
    //    2- Seba Hoca görevlendirir Sedat Hocayı
    //    3- Sedat Hoca Öğretmenleri
    //    4- Öğretmen Öğrenciyi

    //    burada 4 tane Mission açılır 
    //    sadece 1. de IsMainMisson true olur
    //    diğerleri ise hep  FK_ParentMissionID bir üste bağlıdır
    //    List<MissionSequence> main için kendi bilgisini taşır
    //    hiyerarşik olarak sonra gelenler üstüdüklerin bilgisini de taşır. 

    //    En alttaki Öğrenci de bulunan List<MissionSequence> yukarı doğru tüm görev bilgisini barındırır ki işin tamamnını görelim

    //    Bu bağlamla her kademeden tüm işin tamamını ve süreçlerini görebilecdeğiz 

    //    Main görevden sorgu çekince List<MissionSequence> içerisnde main ID yi çeker sem tüm görevler gelecektir


    //     */
    //    public ObjectId FK_MissionID { get; set; } 
    //    public int Sequence { get; set; }
    //    // public string CreatedName { get; set; } = string.Empty;
    //    //public DateTime CreatedDate { get; set; }
    //}

    public class Departments
    {
        public ObjectId id { get; set; }  
        /*
         * Eğitim
         * Destek -- satın alma -- temizlik bakım onarım 
         * Muhasebe
         * halkla ilişkiler
         * İK
         *  
         * 
         
             */
        public string Name { get; set; }
      
    }

    public class SubMission
    {
        public ObjectId id { get; set; }
        public ObjectId FK_CreatedUser { get; set; }
        public string Name { get; set; }
        public List<ObjectId> AppointedList { get; set; }
        public List<Check> CheckList { get; set; }
        public bool IsActive { get; set; } = true;


    }

    public class Check
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public ObjectId FK_CreatedUser { get; set; }
        public string Name { get; set; }
        public string MissionDescription { get; set; } = string.Empty;
        public MissionJobPeriodType MissionJobPeriodType { get; set; }
        public List<StaffConfirmation> StaffConfirmations { get; set; }
        public DateTime CreatedDate { get; set; }
       
    }
   
   

    public class StaffConfirmation
    {
        public ObjectId StaffID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public enum AppointmentType
    {
            School = 1, Class = 2
    }
    //public enum AppointedWhoisType
    //{
    //        Officer=1, Teacher = 2,Student = 3, Guardian = 4, Employee=5
    //}
    public enum MissionType
    {

        Mission = 1, Event = 2, Trip=3/*gezi*/,Exam=4/*ödev*/,Quiz=5, Inspection=6/*yoklama*/, AddedStudy=7/* akşam ya da ek çalışmalar*/,RemoteStudy=8,ClubStudy=9
    }
    public enum MissionCreateType
    {
        Created = 1, Auto = 2 // müdür burada otomatik oluşacak check list işerinide 
    }
    public enum MissionJobPeriodType
    {

        OneTime = 1, Daily = 2,Weekly=3, Monthly=4, Yearly=5,Seasonal=6/*dönemsel*/, EveryLesson=7/*her ders yoklama gibi*/
    }
    public enum MissionStatus
    {

        Created = 1, Continues = 2, Completed = 3, Refused=4 , CheckAgain=5, Checked=6, Ignore=7,Done=8 /* Yöneticinin son onayı done*/
    }

    public class MissionTracking
    {
         
        public ObjectId id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ObjectId FK_InitiatorID { get; set; } //başlatan
        public ObjectId FK_RLPID { get; set; }
        public ObjectId FK_ReletionJobID { get; set; }
        public List<ObjectId> AppointedList { get; set; } //atananlar
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MissionStatus MissionStatus { get; set; }
        public MissionType MissionType { get; set; }

    }
}