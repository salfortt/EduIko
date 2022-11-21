using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Duyuru
    {
        public ObjectId id { get; set; }
        public DateTime PostedOn { get; set; }
        public KategoriTipi Tipi { get; set; }
        public string Sezon { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool IsActive { get; set; }
        public string DuyuruLink { get; set; }
        public string OutLink { get; set; }
        public bool IsDuyuru { get; set; }
        public bool IsSlider { get; set; }
        public List<Galeri> Galeri { get; set; }

    }

    public enum KategoriTipi
    {
        Duyuru,Etkinlik,Bulten

    }
}
