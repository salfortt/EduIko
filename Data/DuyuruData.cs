using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Data
{
  public class DuyuruData :MongoDocumentsDatabase
    {

        private DuyuruData() { }
        private static DuyuruData Instance;
        private const string collectionName = "Duyuru";
        public static DuyuruData GetInstance()
        {
            if (Instance == null)
                Instance = new DuyuruData();

            return Instance;
        }

        public int InsertDuyuru(Duyuru g)
        {
            return Insert(g, collectionName);
        }

        public List<Duyuru> GetDuyuru()
        {
            return GetToList<Duyuru>(collectionName).Where(q => q.IsActive == true).ToList();

        }

        public List<Duyuru> GetBulten()
        {
            return GetToList<Duyuru>("Bulten").Where(q => q.IsActive == true).ToList();
        }
        public List<Duyuru> GetDuyuruAndBulten()
        {
            List<Duyuru> ld = GetToList<Duyuru>(collectionName).Where(q => q.IsActive == true).ToList();

            ld.AddRange(GetToList<Duyuru>("Bulten").Where(q => q.IsActive == true).ToList());

            return ld;

        }

        public void UpdateDuyuru(Duyuru dy)
        {
          
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Duyuru> collection = MongoDB.GetCollection<Duyuru> (collectionName);
            var filter = Builders<Duyuru> .Filter.Eq(s => s.id, dy.id);

            collection.ReplaceOneAsync(filter, dy);
            //typeof(T).Name
        
    }

       

        public Duyuru GetByDuyuruID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Duyuru> collection = MongoDB.GetCollection<Duyuru>(collectionName);
            Duyuru d = collection.AsQueryable<Duyuru>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
            if (d == null)
            {

                collection = MongoDB.GetCollection<Duyuru>("Bulten");
                 d = collection.AsQueryable<Duyuru>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
            }

            return d;
        }

        public void UpdateBulten(Duyuru dy)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Duyuru> collection = MongoDB.GetCollection<Duyuru>("Bulten");
            var filter = Builders<Duyuru>.Filter.Eq(s => s.id, dy.id);

            collection.ReplaceOneAsync(filter, dy);
        }

        public void InsertBulten(Duyuru dy)
        {
              Insert(dy, "Bulten");
        }


        public  Duyuru getGetDuyuruByLink(string link)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Duyuru> collection = MongoDB.GetCollection<Duyuru>(collectionName);
            return collection.AsQueryable<Duyuru>().Where(q => q.DuyuruLink.Equals(link)).FirstOrDefault();
        }
    }
}
