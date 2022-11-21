using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rehberlik
    {
        public ObjectId id { get; set; }
        public ObjectId FK_StudentID { get; set; }
        public ObjectId FK_TeacherID { get; set; }
        public ObjectId FK_ClassID { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public string TeacherAdSoyad { get; set; }
        public string Sezon { get; set; }
        public List<Content> Contents { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public List<DateTime> Dates { get; set; }
        

    }
    public class Content
    {
        public ObjectId id { get; set; }
        public ObjectId FK_UserID { get; set; }
        public string  UserAdSoyad { get; set; }
        public string Sezon { get; set; }
        public string ContentText { get; set; }
        public DateTime Date { get; set; }
        public List<Files> Files { get; set; }


    }

    public class OgrenciTanimaFormu
    {
        public ObjectId id { get; set; }
        public ObjectId FK_StudentID { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public string Sezon { get; set; }

        public OgrenciBilgisi Ogrenci { get; set; }
        public AileBilgisi Aile { get; set; }
        public VeliBilgisi Veli { get; set; }
        public AnneBilgisi Anne { get; set; }
        public BabaBilgisi Baba { get; set; }





        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public List<DateTime> Dates { get; set; }


    }
    public class OgrenciBilgisi
    {

        public string AdSoyad { get; set; }

        public string Cinsiyet { get; set; }
        public string DogumYerTarih { get; set; }
        public string Adres { get; set; }
        public string SinifVeNumara { get; set; }
        public string Okulu { get; set; }
        public string OkulOncesi { get; set; }
        public string NeYapmakTanHoslanir { get; set; }
        public string TasinmaVeOkulDegisimi { get; set; }
        public string TeknolikAletVeKullanim { get; set; }
        public string OdasiVarmi { get; set; }
        public string IlacVeCihaz { get; set; }

        public string Hastalik { get; set; }

        public string Olay { get; set; }
        public string DersDisiFaliyetleri { get; set; }
     

    }
    public class AileBilgisi
    {

        public string Kardesler { get; set; }

        public string KacinciCocuksun { get; set; }
        public string OkulaGidenKardes { get; set; }
        public string HastaOlanVarmi { get; set; }
        public string Evdekiler { get; set; }
       


    }
    public class VeliBilgisi
    {

        public string AdSoyad { get; set; }

        public string Yakinligi { get; set; }
        public string Telefon { get; set; }
        public string Egitimi { get; set; }
        public string Meslegi { get; set; }



    }
    public class AnneBilgisi
    {

        public string AdSoyad { get; set; }
        public string DogumYerTarih { get; set; }
        public string Ozmu { get; set; }
        public string Sagmi { get; set; }
        public string Engellimi { get; set; }
        public string Egitimi { get; set; }

        public string Meslegi { get; set; }

    }
    public class BabaBilgisi
    {

        public string AdSoyad { get; set; }
        public string DogumYerTarih { get; set; }
        public string Ozmu { get; set; }
        public string Sagmi { get; set; }
        public string Engellimi { get; set; }
        public string Egitimi { get; set; }

        public string Meslegi { get; set; }

    }

    public class VeliFormu
    {
        public ObjectId id { get; set; }
        public ObjectId FK_GuardianID { get; set; }
        public ObjectId FK_StudentID { get; set; }
        public string VeliAdSoyad { get; set; }
        public string Sezon { get; set; }
        public List<RehblerlikQuestionAnswer> Answers { get; set; }
        public string VeliNotu { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public  DateTime CreatedDate { get; set; }

        public DateTime EndedDate { get; set; }
    }

    public class RehblerlikQuestionAnswer
    {
        public int QuestionID { get; set; }
        public RehberlikQuestionType RehberlikQuestionType { get; set; }
        public RehberlikAnswerEnum QuestionAnswer { get; set; } /*Puan 1 ile 5 arası*/
    }

    public enum RehberlikQuestionType
    {
        KisiselSosyal=1,Mesleki=2,Egitsel=3
    }

    public enum RehberlikAnswerEnum
    {
        HayirKesinlikleKatilmiyorum=1,HayirKatilmiyorum=2,Kararsizim=3,EvetKatiliyorum=4,EvetKesinlikleKatiliyorum=5
    }
    }