using DataAccessLayer;
using Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReportCardBusiness
    {
        private ReportCardData _dalc;
        private ReportCardData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = ReportCardData.GetInstance();

                return _dalc;
            }
        }
        private ReportCardBusiness() { }
        private static ReportCardBusiness Instance;
        public static ReportCardBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new ReportCardBusiness();

            return Instance;
        }

        public ReportCard GetStudent()
        {
            

            return new ReportCard();
        }

        public List<StudentReportCard> GetStudentReportCardsBySessonAndWeekAndClassID(string sezonName, int activeWeek, ObjectId classID)
        {
            return dalc.GetStudentReportCardsBySessonAndWeekAndClassID(sezonName,activeWeek, classID);
        }

        public void InsertStudentReportCardWithForm(System.Collections.Specialized.NameValueCollection frm , User u ,List<Lecture> Lectures, string sezonName)
        {

            StudentReportCard src = new StudentReportCard();
            string classID = frm["classID"];
            Grade g = new Grade();
            g = ClasessBusiness.GetInstance().GetGradeByID(ObjectId.Parse(classID));
            int week = Convert.ToInt32(frm["week"]);
            var quiz = frm.Keys[4];
            var homeWork = frm.Keys[5];
            //var raisingNetCountOnPortalQuiz = frm.Keys[6];
            var participationInTheLesson = frm.Keys[6];
            var onlineLectureAttendance = frm.Keys[7];
            var teacherNoteKey = frm.Keys[8];

            decimal valQuiz = Convert.ToDecimal(frm[quiz].Replace(".", ","));
            decimal valHomeWork = Convert.ToDecimal(frm[homeWork].Replace(".", ","));
            //decimal valRaisingNetCountOnPortalQuiz = Convert.ToDecimal(frm[raisingNetCountOnPortalQuiz].Replace(".", ","));
            decimal valParticipationInTheLesson = Convert.ToDecimal(frm[participationInTheLesson].Replace(".", ","));
            decimal valOnlineLectureAttendance = Convert.ToDecimal(frm[onlineLectureAttendance].Replace(".", ","));
            var teacherNote = frm[teacherNoteKey];

            List<StudentLessonPoint> lsp = new List<StudentLessonPoint>();
            StudentLessonPoint sp = new StudentLessonPoint();

            sp.LessonGradeType = LessonGradeType.Quiz;
            sp.StudentPoint = valQuiz;
            lsp.Add(sp);
            sp = new StudentLessonPoint();

            sp.LessonGradeType = LessonGradeType.HomeWork;
            sp.StudentPoint = valHomeWork;
            lsp.Add(sp);
            sp = new StudentLessonPoint();

            sp.LessonGradeType = LessonGradeType.RaisingNetCountOnPortalQuiz;
            //sp.StudentPoint = valRaisingNetCountOnPortalQuiz;
            lsp.Add(sp);
            sp = new StudentLessonPoint();

            sp.LessonGradeType = LessonGradeType.ParticipationInTheLesson;
            sp.StudentPoint = valParticipationInTheLesson;
            lsp.Add(sp);
            sp = new StudentLessonPoint();

            sp.LessonGradeType = LessonGradeType.OnlineLectureAttendance;
            sp.StudentPoint = valOnlineLectureAttendance;
            lsp.Add(sp);

            src.FK_TeacherID = u.id;
            src.TeacherName = $"{u.Adi} {u.Soyadi}";
            src.TeacherNote = teacherNote;
            src.Sezon = sezonName;
            src.Week = week;
            src.FK_LectureID = Lectures.Where(q => q.Name.Trim() == u.Brans.Trim()).FirstOrDefault().id;
            src.LectureName = Lectures.Where(q => q.Name.Trim() == u.Brans.Trim()).FirstOrDefault().Name;
            src.FK_ClassID = g.id;
            src.Grade = g.Sube;
            src.GradeName = g.SinifAdi;
            src.FK_StudentID = ObjectId.Parse(frm["studentID"]);
            src.StudentName = frm["studentName"];
            src.RepordCardType = RepordCardType.Online;
            src.StudentLessonPoints = new List<StudentLessonPoint>();
            src.StudentLessonPoints = lsp;

            InsertStudentReportCard(src);
        }

        public List<StudentReportCard> GetStudentReportCardsBySessonAndWeekAndStudentID(string sezonName, int activeWeek, ObjectId id)
        {
            return dalc.GetStudentReportByReportID(sezonName,activeWeek,id);
        }

        public void InsertStudentReportCard(StudentReportCard src)
        {
            dalc.InsertStudentReportCard(src);
        }

        public void UpdateAdminStudentReportCardWithForm(System.Collections.Specialized.NameValueCollection frm)
        {
            
                List<string> LectureList = frm.GetValues("lecture").ToList();
                 
                if (LectureList != null && LectureList.Count > 0)
                {
                    foreach (string lect in LectureList)
                    {

                        ObjectId reportID = ObjectId.Parse(frm[$"reportID-{lect}"]);
                        StudentReportCard _src = GetStudentReportByReportID(reportID);
                        foreach (StudentLessonPoint item in _src.StudentLessonPoints)
                        {

                            _src.StudentLessonPoints.Where(q => q.LessonGradeType == item.LessonGradeType).FirstOrDefault().StudentPoint = Convert.ToDecimal(frm[$"{lect}-{item.LessonGradeType}"].Replace(".", ","));
                        }
                        UpdeteStudentReport(_src);
                    }
                }
            
        }
        public void UpdateTeacherStudentReportCardWithForm(System.Collections.Specialized.NameValueCollection frm)
        {

            List<string> LectureList = frm.GetValues("lecture").ToList();

            if (LectureList != null && LectureList.Count > 0)
            {
                foreach (string lect in LectureList)
                {

                    ObjectId reportID = ObjectId.Parse(frm[$"reportID-{lect}"]);
                    StudentReportCard _src = GetStudentReportByReportID(reportID);
                    foreach (StudentLessonPoint item in _src.StudentLessonPoints)
                    {
                        if (item.LessonGradeType!= LessonGradeType.RaisingNetCountOnPortalQuiz)
                        {
                            _src.StudentLessonPoints.Where(q => q.LessonGradeType == item.LessonGradeType).FirstOrDefault().StudentPoint = Convert.ToDecimal(frm[$"{lect}-{item.LessonGradeType}"].Replace(".", ","));
                        }
                        
                    }

                    _src.TeacherNote = frm["gorus"];
                    UpdeteStudentReport(_src);
                }
            }

        }
        public StudentReportCard GetStudentReportByReportID(ObjectId reportID)
        {
            return dalc.GetStudentReportByReportID(reportID);
        }

        public void UpdeteStudentReport(StudentReportCard src)
        {
              dalc.UpdeteStudentReport(src);
        }
    }
}
