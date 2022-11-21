using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Grade : IWithId
    {
 
  


        public ObjectId id { get; set; }
        public ObjectId FK_KurumID { get; set; }
        public ObjectId FK_TeacherID { get; set; }//oluşturan
       
        public List<ObjectId> AddedStudents { get; set; }
      
        public string Sezon { get; set; }
        public string SinifAdi { get; set; }
        public int Sinif { get; set; }
        public int Sube { get; set; }
        public int ServerID { get; set; }
        public int Capacity { get; set; }
        //  public List<AddedStudent> Students { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public DateTime SeasonStartDay { get; set; } 
        public List<OnlineLecture> OnlineLectures { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
