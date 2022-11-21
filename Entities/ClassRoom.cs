using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace Entities
{
    public class ClassRoom
    {
        public ObjectId id { get; set; }
    
        public int DerslikNo { get; set; }
        public float DerslikMetreKare { get; set; }
        public float DerslikYukseklik { get; set; }
        public int DerslikPencereSayisi { get; set; }
        public int CiftliSiraSayisi { get; set; }
        public int TekliSiraSayisi { get; set; }
        public string DerslikAdi { get; set; }
        public int SinifinBulunduguKat { get; set; }
        public int SinifKapasiteResmi { get; set; }
        public int SinifKapasite { get; set; }
        public int SinifMevcudu { get; set; }
        public List<Demirbas> Demirbas { get; set; }
        public List<Yetki> SinifYetkiSinirlari { get; set; }
        public bool AktifMi { get; set; }

    }

}