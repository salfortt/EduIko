using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
  public  class Ogrenci
    {
        public ObjectId id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
     //   public int FK_Okul { get; set; }
        public string Okul { get; set; }
        public string Sinif { get; set; }
        public int OkulNo { get; set; }
        public int FK_ZKampusSinif { get; set; }
        public string ZKampusSinif { get; set; }
        public string Veli { get; set; }
        public string VeliTelefon { get; set; }
        public string VeliMail { get; set; }
        public string Adres { get; set; }
        public int KayitUcreti { get; set; }
        public int TaksitSayisi { get; set; }
        public string Aciklama { get; set; }
        public string Password { get; set; }
        public int Cinsiyet { get; set; }
 
        public DateTime OdemeTarihi { get; set; }
    }
}
