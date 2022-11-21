using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class GorusmeData : MongoDocumentsDatabase
    {
        private GorusmeData() { }
        private static GorusmeData Instance;
        private const string collectionName = "Gorusme";
        private const string collectionNameBursluluk = "Bursluluk";
        public static GorusmeData GetInstance()
        {
            if (Instance == null)
                Instance = new GorusmeData();

            return Instance;
        }

        public int InsertGorusme(Gorusme g)
        {
            return Insert(g, collectionName);
        }

      
        public void GetGorusmeByID(int id)
        {
            throw new NotImplementedException();
        }

        public int InsertMenu(Menu m)
        {
            return Insert(m, "Menu");
        }

        public List<Menu> GetMenu()
        {
            return GetToList<Menu>("Menu");
        }

        public List<Gorusme> GetGorusmeler()
        {
            return GetToList<Gorusme>("Gorusme").Where(q => q.IsActive == true).ToList();
        }

        public Gorusme GetGorusmeByID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Gorusme> collection = MongoDB.GetCollection<Gorusme>(collectionName);
            return collection.AsQueryable<Gorusme>().Where(q => q.id.Equals(id) && q.IsActive == true).FirstOrDefault();

        }

        public List<Contact> GetContacts()
        {
            return GetToList<Contact>("ContactMessage");
        }

        public List<BurslulukKayit> GetBursluluklar()
        {
            return GetToList<BurslulukKayit>(collectionNameBursluluk).Where(q=>q.IsActive).ToList();
        }

        public int InsertGorusmeTipi(List<GorusmeTipi> lGorusmeTipi)
        {
            return InsertList(lGorusmeTipi,"GorusmeTipi");
        }

        public BurslulukKayit GetBurslulukByID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<BurslulukKayit> collection = MongoDB.GetCollection<BurslulukKayit>(collectionNameBursluluk);
            return collection.AsQueryable<BurslulukKayit>().Where(q => q.id.Equals(objectId) ).FirstOrDefault();
        }

        public void UpdateBursluluk(BurslulukKayit g)
        {
            Update<BurslulukKayit>(g, collectionNameBursluluk);
        }

        public List<GorusmeTipi> GetGorusmeTipi()
        {
            return GetToList<GorusmeTipi>("GorusmeTipi");
        }

        public async Task<long>  EditGorusmeByID(Gorusme g )
        {
             
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Gorusme> collection = MongoDB.GetCollection<Gorusme>(collectionName);
           Task<ReplaceOneResult> result =  collection.ReplaceOneAsync(c => c.id == g.id, g);
           
            var res = await result;

            
            if (res.IsModifiedCountAvailable)
                return res.ModifiedCount;

       


            return 0;

        
    }


        public void testUpdate()
        {

            var collection2 = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("name", "Juni");
            var update = Builders<BsonDocument>.Update
                .Set("cuisine", "American (New)")
                .CurrentDate("lastModified");
            var result =  collection2.UpdateOne(filter, update);

        


        }
    
    }
}
