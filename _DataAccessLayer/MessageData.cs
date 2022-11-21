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
  public  class MessageData :MongoDocumentsDatabase
    {


        private MessageData() { }
        private static MessageData Instance;
        private const string collectionName = "Message";
        public static MessageData GetInstance()
        {
            if (Instance == null)
                Instance = new MessageData();

            return Instance;
        }

        public int InsertMessage(Message y)
        {
            return Insert(y, collectionName);
        }

        public Message GetMessageById(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Message> collection = MongoDB.GetCollection<Message>(collectionName);
            return collection.AsQueryable<Message>().Where(q => q.id.Equals(id)).FirstOrDefault();

        }

        public List<Message> GetMessages()
        {
            return GetToList<Message>(collectionName).AsQueryable().Where(m=>m.IsClosed ==false ).ToList();
        }

        public List<Message> GetMessageByUserId(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Message> collection = MongoDB.GetCollection<Message>(collectionName);
            return collection.AsQueryable<Message>().Where(q => q.FK_UserId.Equals(id)).ToList();

        }

        public void UpdateMessageWithReplies(Message m)
        {
            Update<Message>(m,collectionName);
        }

        public void UpdateMessage(Message m)
        {
            Update<Message>(m, collectionName);
        }

        public List<string> GetUserNameById(List<ObjectId> ids)
        {
            List<string> result =new List<string>();
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<User> collection = MongoDB.GetCollection<User>("Account");
             
           List<User> u = collection.AsQueryable<User>().Where(q => ids.Contains(q.id)).ToList() ;
            if (u != null)
                foreach (var item in u)
                    result.Add( item.Adi + " " + item.Soyadi);

            return result;    
        }

        //public List<Message> GetMessageList(string gradeDay, string classId)
        //{
        //    var MongoDB = _client.GetDatabase(_databaseName);
        //    IMongoCollection<Message> collection = MongoDB.GetCollection<Message>(collectionName);
        //    return collection.AsQueryable<Message>().Where(q => q.GradeDay.Equals(gradeDay) && q.FK_ClassId.Equals(ObjectId.Parse(classId))).ToList();

        //}

        public void DeleteMessageById(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Message> collection = MongoDB.GetCollection<Message>(collectionName);
            collection.DeleteOne(q=>q.id.Equals(objectId));

        }
    }
}
