using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLayer
{
   public class ExamAnalysisBusiness
    {
        private ExamAnalysisBusiness() { }
        private static ExamAnalysisBusiness Instance;

        public static ExamAnalysisBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new ExamAnalysisBusiness();

            return Instance;
        }


        private ExamAnalysisData _dalc; // dalc buradan kalkacak account map bu ';' yapoacak ya cache ya da dalc
        private ExamAnalysisData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = ExamAnalysisData.GetInstance();

                return _dalc;
            }
        }


        public int InsertExamAnalysis(ExamaAnalysis y)
        {
            return dalc.InsertExamAnalysis(y);
        }
    }
}
