using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OnlineLecture : IWithId
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public ObjectId FK_GradeID { get; set; }
        public ObjectId FK_TeacherID { get; set; }
        public List<ObjectId> StudentsAssigned { get; set; }
        public string LectureName { get; set; }

        public ObjectId FK_LectureID { get; set; }
        public int ServerID { get; set; }
        public int Week { get; set; }
        public string LectureStartDateTime { get; set; }
        public string Subject { get; set; }
        //public List<Link> Links { get; set; }
        public string name { get; set; }
        public string meetingID { get; set; }
        public string attendeePW { get; set; }
        public string moderatorPW { get; set; }
        public string welcome { get; set; }
        public string logoutURL { get; set; }
        public string SALT { get; set; }
        public string URL { get; set; }
        public string record { get; set; }
        public string duration { get; set; }
        public string voiceBridge { get; set; }
        public string createTime { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public bool IsActive { get; set; } = true;
        public bool DidItHappen { get; set; } = false;//ders gerçekleştimi // linkleri realtime da oluştur yada zamanına bak ona göre aç kapa
        public OnlineClassStatusEnum OnlineClassStatus { get; set; } = OnlineClassStatusEnum.DidNotStart;


    }

    public class OnlineLectureTracking: IWithId 
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public ObjectId FK_LectureID { get; set; } //online dersin Id si

        public ObjectId FK_DersID { get; set; } //Dersin id si
        public ObjectId FK_UserID { get; set; }
        public int Week { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string meetingID { get; set; }
        public OnlineLectureAccessType OnlineLectureAccessType { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);
        public string LectureStartDateTime { get; set; }

    }

    //public class  Link
    //{
    //    public LinkType LinkType { get; set; }
    //    public string Url { get; set; }


    //}
    public class OnlineServerInfo
    {
        public ObjectId id { get; set; } = ObjectId.GenerateNewId();
        public int ServerID { get; set; }
        public string URL { get; set; }
        public string SALT { get; set; }
        public string logoutURL { get; set; }
        public bool ServerState { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public enum OnlineLectureAccessType
    {
      OnlineCreate=1,  OnlineJoin = 2, OfflineView = 3 

    }

    public enum OnlineClassStatusEnum
    {
        DidNotStart = 1, DidStart = 2, DidEnd = 3

    }
    public enum LinkType
    {
        CreateURL = 1, JoinModeratorURL = 2, JoinClientURL = 3, JoinMeetingURL = 4

    }
}
