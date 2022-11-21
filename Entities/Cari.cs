using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
   public class Cari
    {
        public ObjectId id { get; set; }
        public int ID { get; set; }
        public int FK_Cari_Hareket { get; set; }
        public int FK_Uye { get; set; }
        public int FK_UyeTipi { get; set; }
        public int Miktar { get; set; }
        public string Not { get; set; }
    }
}
