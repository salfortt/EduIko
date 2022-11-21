using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IWithId
    {
        ObjectId id { get; set; }
    }

    [Serializable]
    public class Message :IWithId
    {

        public ObjectId id { get; set; }
        public ObjectId FK_UserId { get; set; }
        public UserType UserType { get; set; }
        public List<IUser> To { get; set; }//kimlere atıldığı çoklu gönderim içinS
        public ObjectId ToClassID { get; set; }
      //  public List<ObjectId> MessageToUsersByID { get; set; }
        public List<UserInfo> MessageToUsersByID { get; set; }
        public string UserNameAndSurname { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public List<string> MessageContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsUrgent { get; set; }

        public bool IsReplied { get; set; }
        public bool IsClosed { get; set; }
        public bool IsParent { get; set; }//mesaj ebeveyne mi atılıyor
        public List<MessageReply> ReplyMessage { get; set; }
        public List<LookedUp> LookedUp { get; set; }

    }
    [Serializable]
    public class UserInfo
    {
        public ObjectId UserID { get; set; }
        public ObjectId FK_ClassID { get; set; }
        public string UserNameAndSurname { get; set; }


    }

    [Serializable]
    public class MessageReply
    {

        public ObjectId id { get; set; }
        public ObjectId FK_FromId { get; set; }
        public UserType UserType { get; set; }
        public string RepliedNameAndSurname { get; set; }
        public string ReplyMessage { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    [Serializable]
    public class MessageSMS : IWithId
    {

        public ObjectId id { get; set; }
        public string FK_DlrId { get; set; }
        public string SchoolName { get; set; }
        public string Classes { get; set; }
        public string Message { get; set; }
        public string SendDateTime { get; set; }//sendDateTime “2015.7.23.9.30.0”
        public List<string> Cells { get; set; }
        public SMSSendType Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now.Add(DateTime.Now - DateTime.UtcNow);

    }

    [Serializable]
    public enum SMSSendType
    {
       waiting=0,strated=1,pending=2,completed=3

    }
}
