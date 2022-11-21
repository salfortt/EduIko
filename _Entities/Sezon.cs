using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    [Serializable]
    public class Sezon
    {
        public ObjectId id { get; set; }
        public ObjectId FK_ClassId { get; set; }
        public string SezonAdi { get; set; }
        public string Subesi { get; set; }
        public string Sinifi { get; set; }
        //        public List<Yetki> SezonYetkiSinirlari { get; set; }
        public bool  AktifMi { get; set; }
    }
 

    
}