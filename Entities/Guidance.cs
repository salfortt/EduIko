using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Entities
{
    public class Guidance
    {
        ObjectId id { get; set; }
        ObjectId FK_ClassId { get; set; }
        string Adi { get; set; }
        string UserLink { get; set; }
        string Soyadi { get; set; }
        string Cinsiyet { get; set; }
        UserType UserType { get; set; }
        Int64 TCNo { get; set; }

    }
    public class GuidanceReportByStudent
    {
        ObjectId id { get; set; }
        ObjectId FK_ClassID { get; set; } 
        string Ogrenci { get; set; }
        public List<GuidanceReport> Raporlar { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }


    }
    public class GuidanceReport
    {
        ObjectId id { get; set; }
        string Ogretmen { get; set; }
        public RaporKategori Kategori { get; set; }
        public RaporDonem Rapor { get; set; }
        public string Aciklama { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }

    public enum RaporDonem{
        Kabul,Eylul,Subat,Haziran,Yaz

    }
    public enum RaporKategori
    {
        Rehberlik,Akademik,Projeler,OkulKulturu,Cevre,Sosyal,Kaygilari,OgretmenTutumu,OzBakim,TakimCalismasi,MeslekiGelisim
            //Akademik akademik başarı
            //Projeler   Projeler
            //OkulKültürü Okul ve sınıf içi etkinkikler
            //Sosyal Sosyal kişilik tutumları
            //Çevre Öğrencinin çevre tutumu
            //Ogretmen ile tutumu
            //Oz bakım
            //Takım Calışması ve sorumluluk
            //Kaygıları


    }
}
