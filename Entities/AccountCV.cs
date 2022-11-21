using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AccountCV
    {
        public ObjectId id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Education> Education { get; set; }
        public List<AccountProject> Projects { get; set; }
        public List<Certificate> Certificateies { get; set; }
    }



    [Serializable]
    public class Education
    {
        public int GraduationYear { get; set; }
        public School School { get; set; }
    }
    [Serializable]
    public enum EducationType
    {
        continues = 1, graduated = 2
    }
    [Serializable]
    public class School
    {
        public string SchoolName { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public SchoolType SchoolType { get; set; }
    }
    [Serializable]
    public enum SchoolType
    {
        kindergarten = 0, primarySchool = 1, middleSchool = 2, college = 3, highSchool = 4, university = 5, graduate = 6, doctorate = 7
    }
    [Serializable]
    public class Certificate
    {
        public int CertificateYear { get; set; }

        public string CertificateName { get; set; }

        public string Description { get; set; }
    }
    [Serializable]
    public class AccountProject
    {
        public int ProjectYear { get; set; }
        public string ProjectName { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }

    }
}
