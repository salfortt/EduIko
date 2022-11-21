  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using MongoDB.Bson;

namespace Business
{

   public class MessageBusiness
    {
        private MessageBusiness() { }
        private static MessageBusiness Instance;

        public static MessageBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new MessageBusiness();

            return Instance;
        }



        private MessageData _dalc;
        private MessageData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = MessageData.GetInstance();

                return _dalc;
            }
        }

        public List<Message> GetMessages()
        {
            return dalc.GetMessages();
        }

        public List<Message> GetMessageByUserId(ObjectId id)
        {
            return dalc.GetMessageByUserId(id);
        }

        public int InsertMessage(Message y)
        {
            return dalc.InsertMessage(y);

        }

        public Message GetMessageById(ObjectId objectId)
        {
            return dalc.GetMessageById(objectId);
        }

        public void DeleteMessageById(ObjectId objectId)
        {
             dalc.DeleteMessageById(objectId);
        }

        public void UpdateMessageWithReplies(Message m)
        {
            dalc.UpdateMessageWithReplies(m);
        }

        public void UpdateMessage(Message m)
        {
            dalc.UpdateMessage(m);
        }

        public List<string> GetUserNameById(List<ObjectId> ids)
        {
          return   dalc.GetUserNameById(ids);
        }

        //public List<Message> GetMessageList(string gradeDay, string classId)
        //{
        //    return dalc.GetMessageList(gradeDay, classId);
        //}
    }
}
