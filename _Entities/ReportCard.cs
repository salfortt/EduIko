using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ReportCard : IWithId
    {
        public ObjectId id { get; set; }
        public ObjectId FK_ClassID { get; set; }
        public int Grade { get; set; }
        public  ObjectId  FK_StudentID { get; set; }
        public RepordCardType RepordCardType { get; set; }
        public string Sezon { get; set; }
        public int Week { get; set; }
        public List<LessonPoint> LessonsGradeies { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public bool IsActive { get; set; } = true;

    }
    public class StudentReportCard   
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public string Sezon { get; set; }
        public int Week { get; set; }
        public ObjectId FK_TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string TeacherNote { get; set; }
        public ObjectId FK_LectureID { get; set; } /*FK_LectureID  lecture kullandım hep lesson olmalıydı*/
        public string LectureName { get; set; }
        public ObjectId FK_ClassID { get; set; }
        public int Grade { get; set; }
        public string GradeName { get; set; }
        public ObjectId FK_StudentID { get; set; }
        public string StudentName { get; set; }
        public RepordCardType RepordCardType { get; set; }
 
        public List<StudentLessonPoint> StudentLessonPoints { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public bool IsActive { get; set; } = true;

    
       
      
      

    }


    public class StudentLessonPoint   
    {
        public LessonGradeType LessonGradeType { get; set; }
        public decimal StudentPoint { get; set; }


    }
 


    public class LessonProperties /*Ders notu puanı*/
    {
        public ObjectId id { get; set; }
        //public ObjectId FK_LessonID { get; set; }  
        public int Grade { get; set; }
        //public string LessonName { get; set; }
        public RepordCardType RepordCardType { get; set; }
        public List<LessonGradeTypeAndPoint> LessonGradeTypeAndPoints { get; set; }
        public bool IsActive { get; set; } = true;

    }

    public class LessonPoint /*Ders notu puanı*/
    {
        //   public decimal Point { get; set; }
        //public decimal MaxPoint { get; set; }
        public ObjectId FK_TeacherID { get; set; }
        public string TeacherName { get; set; }
        public ObjectId FK_LessonID { get; set; } /*FK_LectureID  lecture kullandım hep lesson olmalıydı*/
        public string LessonName { get; set; }
        public string TeacherNote { get; set; }
        public List<LessonGradeTypeAndPoint> LessonPoints { get; set; }
    }
    public class LessonGradeTypeAndPoint
    {
        public LessonGradeType LessonGradeType { get; set; }
        public decimal MaxPoint { get; set; }
    }
    public enum LessonGradeType
    {
        Total = 1, Quiz = 2, HomeWork = 3, RaisingNetCountOnPortalQuiz = 4, ParticipationInTheLesson = 5, OnlineLectureAttendance = 6 
    }
    public enum RepordCardType
    {
        Online=1,FaceToFace=2,Individual=3/*bireysel*/
    }
}
