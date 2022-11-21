using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class BurslulukKayit : IWithId
    {
        public ObjectId id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
  
        public string CreatedDate { get; set; }
        public string Okul { get; set; }
        public string Sinif { get; set; }
        public string Ilce { get; set; }

        public string Semt { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public bool IsActive { get; set; } = true;
        public string Sezon { get; set; }
        public decimal Ucret { get; set; }
        public  DateTime  CreatedDateTime { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public DateTime BursRandevuTarihi { get; set; }
        public DateTime GorusmeRandevuTarihi { get; set; }
 
        public  string  Content  { get; set; }
        public GorusmeTipi Durum { get; set; }
    }
}
