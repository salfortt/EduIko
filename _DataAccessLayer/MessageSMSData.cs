using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace DataAccessLayer
{
  public  class MessageSMSData :MongoDocumentsDatabase
    {


        private MessageSMSData() { }
        private static MessageSMSData Instance;
        private const string collectionName = "MessageSMS";
        public static MessageSMSData GetInstance()
        {
            if (Instance == null)
                Instance = new MessageSMSData();

            return Instance;
        }

      

        public MessageSMS GetMessageById(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<MessageSMS> collection = MongoDB.GetCollection<MessageSMS>(collectionName);
            return collection.AsQueryable<MessageSMS>().Where(q => q.id.Equals(id)).FirstOrDefault();

        }

        public List<Kisi> GetKisiler()
        {
            return GetToList<Kisi>("Kisiler").ToList();
        }

        public List<MessageSMS> GetMessages()
        {
            return GetToList<MessageSMS>(collectionName).ToList();
        }

        public List<MessageSMS> GetMessageByUserId(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<MessageSMS> collection = MongoDB.GetCollection<MessageSMS>(collectionName);
            return collection.AsQueryable<MessageSMS>().Where(q => q.id.Equals(id)).ToList();

        }

        public int InsertMessage(MessageSMS y)
        {
            return Insert(y, collectionName);
        }

      
        public void UpdateMessage(MessageSMS m)
        {
            Update<MessageSMS>(m, collectionName);
        }

    

        //public List<MessageSMS> GetMessageList(string gradeDay, string classId)
        //{
        //    var MongoDB = _client.GetDatabase(_databaseName);
        //    IMongoCollection<MessageSMS> collection = MongoDB.GetCollection<MessageSMS>(collectionName);
        //    return collection.AsQueryable<MessageSMS>().Where(q => q.GradeDay.Equals(gradeDay) && q.FK_ClassId.Equals(ObjectId.Parse(classId))).ToList();

        //}

        public void DeleteMessageById(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<MessageSMS> collection = MongoDB.GetCollection<MessageSMS>(collectionName);
            collection.DeleteOne(q=>q.id.Equals(objectId));

        }
    }
}
