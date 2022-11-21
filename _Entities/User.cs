using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    [Serializable]
    public class FCPerson
    {
        public string height { get; set; }
        public bool is_silhouette { get; set; }
        public string url { get; set; }
        public string width { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public string gender { get; set; }
 
    }




    /*Yukarısı FaceBook User*/
 
    public interface IUser {
        ObjectId id { get; set; }
        ObjectId FK_ClassId { get; set; }
        string Adi { get; set; }
        string UserLink { get; set; }
        string Soyadi { get; set; }
        string Cinsiyet { get; set; }
        UserType UserType { get; set; }
        Int64 TCNo { get; set; }
    }
    [Serializable]
    public class User :IUser
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public ObjectId FK_ClassId { get; set; }
        public ObjectId FK_KurumID { get; set; }
        public ObjectId FK_VeliOgrID{ get; set; }
        public string ReferenceID { get; set; }
        public List<string> NotifyIds { get; set; }
        public string FacebookID { get; set; }
        public string FacebookImgURL { get; set; }
        public string VeliCocukAdSoyad { get; set; }

        public List<IlgiTipi> KurumIlgisi { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public bool FirstPassChange { get; set; }

        public string phone { get; set; }
        public string Adi { get; set; }
        public string UserLink { get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public Int64 TCNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public UserType UserType { get; set; }
        public UserTypeEnum UserTypeEnum { get; set; }
        public string KullaniciNotu { get; set; }
        public string Brans { get; set; }
        public List<string> CokluBrans { get; set; }
        public string Gorev { get; set; }
  
        public Yetki KullaniciYetkisi { get; set; }
        public List<IletisimBilgi> Iletisim { get; set; }
        public CV KullaniciCV { get; set; }
        public SiteBilgisi SiteBilgisi { get; set; }
        public bool AcsessSite { get; set; }
    
        public int Order { get; set; }
        public bool IsActive { get; set; }


        public Credit UserCredit { get; set; }
        public int Class { get; set; }
        public ObjectId FK_TeacherID { get; set; }
        public DateTime BirthDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;// = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public string School { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public ObjectId FK_SchoolID { get; set; }
        public ObjectId FK_ProvinceID { get; set; }
        public ObjectId FK_DistrictID { get; set; }
        public string PicturePath { get; set; }
        //  public string Brans { get; set; }
        public bool MailActivate { get; set; } = false; //eğer true ise home a yönlensin
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime MailActivateDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public Credit Credit { get; set; }
 
    }


    [Serializable]
    public class Credit
    {

        public ObjectId FK_SubscriptionTypeID { get; set; }
        public ObjectId FK_UserID { get; set; }
        public string SubscriptionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public PaymentTypeEnum PaymentTypeEnum { get; set; }

    }

    [Serializable]
    public class SubscriptionType
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public UserTypeEnum UserType { get; set; }
        public string Name { get; set; }
        public int ClassCapacity { get; set; }
        public int StudentCapacity { get; set; }
        public int ClassStudentCapacity { get; set; }
        public int LCCount { get; set; }//LC Live Class online uzaktan eğitim
        public int LCDuration { get; set; }
        public bool IsCam { get; set; } = false;
        public bool IsMic { get; set; } = false;
        public bool IsRecording { get; set; } = false;
        public bool IsAvatar { get; set; } = false;
        public float Price { get; set; }
        public PaymentTypeEnum PaymentTypeEnum { get; set; }
    }
    //[Serializable]
    //public class CreditStudent
    //{

    //    public int ClassCapacity { get; set; }
    //    public int StudentCapacity { get; set; }

    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }

    //}
    [Serializable]
    public enum PaymentTypeEnum
    {
        Month1 = 1, Month3 = 3, Month6 = 6, Month12 = 12

    }
    [Serializable]
    public class  SiteBilgisi {
       
        public string Hakkinda { get; set; }
        public string Aciklama { get; set; }
        public string KisaYazi { get; set; }
        public string OzluSoz { get; set; }
        public string OzluSozSahibi { get; set; }
        public string ProfilePicPath { get; set; }
    }
    [Serializable]
    public class UserType
    {
        public ObjectId id { get; set; }
        public string Tip { get; set; }
         
        public int TipId { get; set; }
        public string GorevAdi { get; set; }//müdür,ahçı,temzilik,memur,müdür yardımcısı vs vs
    }
    [Serializable]
    public enum UserTypeEnum {
        Student,Teacher,Guardian,Director,Manager,Admin, Employee

    }
    [Serializable]
    public class IletisimBilgi
    {
        public int IletisimId { get; set; }
        public string IletisimTipi { get; set; }
        public string IletisimBilgisi { get; set; }//tipe göre bilgiler buraya gelecek
        public bool AktifMi { get; set; }

    }
    [Serializable]
    public class IletisimTipi
    {
        public int IletisimTipiId { get; set; }
        public string TipAdi { get; set; }//telefeon, adres,cep tel,ev tel , mail,skype gibi,adres
        public int TipAdiUzunlukBilgisi { get; set; }
    }
    [Serializable]
    public class Yetki
    {
        public ObjectId id { get; set; }
        public List<YetkiAlan> YetkiAlani { get; set; }

    }
    [Serializable]
    public class YetkiAlan
    {
        public ObjectId id { get; set; }
        public string AlanAdi { get; set; }//ekleme,silme,yazma,okuma,admin,öğrenci,veli,müdür
      
        public List<YetkiTipi> YetkiTipleri { get; set; }

    }


 

    [Serializable]
    public class YetkiTipi
    {
        public ObjectId id { get; set; }
        public string YetkiTipAdi { get; set; }//ekleme,silme,yazma,okuma,admin,öğrenci,veli,müdür
        public string Aciklama { get; set; }
    }





    [Serializable]
    public class CV {
        public string Ozgecmis { get; set; }

        public List<Egitim> EgitimHayati { get; set; }
        public List<Proje> Projeleri { get; set; }

        public List<Sertifika> Sertifikalari { get; set; }
    }
    [Serializable]
    public class Egitim {

        public int MezuniyetYili { get; set; }
        public Okul Okulu { get; set; }


    }
    [Serializable]
    public class Okul{

        public string OkulAdi { get; set; }
        public string Bolum { get; set; }
        public string Fakulte { get; set; }
        public OkulTipi Tipi { get; set; }
    }
    [Serializable]
    public class OkulTipi {
        public string Tipi { get; set; }//ilokul,Lise,Lisans,Onlisans
    }
    [Serializable]
    public class Sertifika
    {
        public int Yil { get; set; }
        public string Donem { get; set; }
        public string Adi { get; set; }


    }
    [Serializable]
    public class Proje {
        public int Yil { get; set; }
        public string Donem { get; set; }
        public string ProjeAdi { get; set; }
        public string Kurum { get; set; }
        public string Not { get; set; }

    }


}