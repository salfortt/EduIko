using MongoDB.Bson;
using System;

namespace Entities
{

    [Serializable]
    public class IlgiTipi
    {
    
        public Sezon Sezon { get; set; }// Şu sezonda Öğrenci  // şu sezonda Öğretmen
        public ObjectId FK_ClassId { get; set; }
        public UserType UserType { get; set; }
        public bool AktifMi { get; set; }
    }

}