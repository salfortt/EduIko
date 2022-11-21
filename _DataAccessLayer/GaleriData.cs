using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataAccessLayer
{
  public class GaleriData :MongoDocumentsDatabase
    {

        private GaleriData() { }
        private static GaleriData Instance;
        private const string collectionName = "Galeri";
        public static GaleriData GetInstance()
        {
            if (Instance == null)
                Instance = new GaleriData();

            return Instance;
        }

        public int InsertGaleriAdi(SiteGaleri g)
        {
            return Insert(g, collectionName);
        }

        public List<SiteGaleri> GetGaleri()
        {
            return GetToList<SiteGaleri>(collectionName);
        }

        public void UpdateGaleri(SiteGaleri gal)
        {
          
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<SiteGaleri> collection = MongoDB.GetCollection<SiteGaleri>(collectionName);
            var filter = Builders<SiteGaleri>.Filter.Eq(s => s.id, gal.id);

            collection.ReplaceOneAsync(filter, gal);
            //typeof(T).Name
        
    }

        public SiteGaleri GetGaleriByID(string id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<SiteGaleri> collection = MongoDB.GetCollection<SiteGaleri>(collectionName);
            return collection.AsQueryable<SiteGaleri>().Where(q => q.id.Equals(ObjectId.Parse(id))).FirstOrDefault();

        }
    }
}
