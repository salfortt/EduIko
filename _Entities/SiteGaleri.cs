using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class SiteGaleri
    {
        public ObjectId id { get; set; }
        public string GaleriAdi { get; set; }
        public string GaleriLink { get; set; }
        public string GaleriAciklamasi { get; set; }
        public string Ekleyen { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public List<Galeri> Galeri { get; set; }
    }

    public class Galeri {

        public string   ImagePath { get; set; }
        public string ImageAltText { get; set; }
        public string ImageDescription { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
