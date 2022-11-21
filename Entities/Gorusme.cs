using System;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Entities
{
    public class Gorusme
    {
        public ObjectId id { get; set; }
        public string Sezon { get; set; }
        public string VeliAdSoyad { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public string OgrenciOkul { get; set; }
        public string OgrenciSinif { get; set; }
        public string VeliTelefon { get; set; }
        public string VeliMail { get; set; }
        public int Ucret { get; set; }
        public ObjectId FK_GorusenID { get; set; }
        public ObjectId FK_BurslulukID { get; set; }
        public string GorusenAdSoyad { get; set; }
        public DateTime Tarih { get; set; }//Görüşme tarihi
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime BursRandevuTarihi { get; set; }
        public DateTime GorusmeRandevuTarihi { get; set; }
        public bool IsActive { get; set; } = true;
        public string Aciklama { get; set; }
        public List<Content> Contents { get; set; }
        public GorusmeTipi Durum { get; set; }


    }
    public enum GorusmeTipi
    {
        Gorusulmedi,Olumlu,Olumsuz,TekrarAranacak,Acmadi,SinavaGirdi,SinavaGirmedi,TekrarGorusulecek,RandevuyaGelmedi,RandevuYenilendi,KayitYapildi,Aranmamis,SinavKaydiYapildi,OnlineSinavBasvurusu
    }
}