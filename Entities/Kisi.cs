using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kisi:IWithId
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Okul { get; set; }
        public string Ogrenci { get; set; }
        public string Anne { get; set; }
        public string Baba { get; set; }
        public string AnneTel { get; set; }
        public string BabaTel { get; set; }
        public string Sinif { get; set; }
        public string Sube { get; set; }
        public string Sezon { get; set; }
        public bool Ydil { get; set; } = false;
        public OkulTip OkulTip { get; set; }
        public bool IsAccsess { get; set; } = true;
        //public bool Gorusuldumu { get; set; } = false;
        //public List<string> GorusmeNotu { get; set; }
        //public DateTime GorusmeTarihi { get; set; }
        //public List<DateTime> RandevuTarihi { get; set; }
        //public bool AranmakIstiyor { get; set; } = true;

    }
    public enum OkulTip { ilk = 1, orta = 2, lise = 3, unv = 4 }
}
