using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Yoklama
    {
        public ObjectId  id{ get; set; }
        public DateTime CreatedTime { get; set; }
        public Mevcut Mevcut { get; set; }
        public string GradeDay { get; set; }
        public int GradeOrder { get; set; }
        public List<Gelmeyen> Gelmeyenler { get; set; }
        public string TeacherNameSurname { get; set; }
        public ObjectId FK_ClassId { get; set; }
        public string ClassName { get; set; }
        public string LectureName { get; set; }
        public DateTime UpdateTime { get; set; }
       // public ObjectId FK_UserId{ get; set; }
        public ObjectId FK_LectureID { get; set; } //Ders ID
        public ObjectId FK_PlanId { get; set; }//Eklenecek ders programının program ID si
        public ObjectId FK_TeacherId { get; set; }
        public bool IsActive { get; set; } = true;

    }
    public class Gelmeyen
    {
        public ObjectId FK_UserId { get; set; }
        public string AdiSoyadi { get; set; }

    }
        public enum Mevcut {

        Tam=0,Eksik=1
    }
}
