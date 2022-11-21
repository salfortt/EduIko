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

   public class MessageSMSBusiness
    {
        private MessageSMSBusiness() { }
        private static MessageSMSBusiness Instance;

        public static MessageSMSBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new MessageSMSBusiness();

            return Instance;
        }

       
        private MessageSMSData _dalc;
        private MessageSMSData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = MessageSMSData.GetInstance();

                return _dalc;
            }
        }
        public List<Kisi> GetKisiler()
        {
            return dalc.GetKisiler();
        }

        public List<MessageSMS> GetMessages()
        {
            return dalc.GetMessages();
        }

        public List<MessageSMS> GetMessageByUserId(ObjectId id)
        {
            return dalc.GetMessageByUserId(id);
        }

        public int InsertMessage(MessageSMS y)
        {
            return dalc.InsertMessage(y);

        }

        public MessageSMS GetMessageById(ObjectId objectId)
        {
            return dalc.GetMessageById(objectId);
        }

        public void DeleteMessageById(ObjectId objectId)
        {
             dalc.DeleteMessageById(objectId);
        }

     
        public void UpdateMessage(MessageSMS m)
        {
            dalc.UpdateMessage(m);
        }

        

        //public List<MessageSMS> GetMessageList(string gradeDay, string classId)
        //{
        //    return dalc.GetMessageList(gradeDay, classId);
        //}
    }
}
