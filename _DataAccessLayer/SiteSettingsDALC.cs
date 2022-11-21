using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccessLayer
{
   public class SiteSettingsDALC : MongoDocumentsDatabase
    {
        public SiteSettingsDALC() { }
        private static SiteSettingsDALC Instance;
        private const string collectionName = "SiteSettings";
        private const string collectionSeason = "Season";
        public static SiteSettingsDALC GetInstance()
        {
            if (Instance == null)
                Instance = new SiteSettingsDALC();

            return Instance;
        }

        public Dictionary<string, Setting> LoadSettings()
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetMenuList()
        {
            return GetToList<Menu>("Menu");
        }

        public int InsertMenu(Menu m)
        {
            return Insert<Menu>(m,"Menu");
        }

        public List<User> GetOgrenciler()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<User> collection = MongoDB.GetCollection<User>("Account");
            List<User> result = collection.AsQueryable<User>().Where(q =>  q.IsActive.Equals(true) &&
             q.UserType.Tip.Equals(UserTypeEnum.Student.ToString()) 
               
            ).ToList();
            //var MongoDB = _client.GetDatabase(_databaseName);
            //IMongoCollection<User> collection = MongoDB.GetCollection<User>("Account");
            //List<User> result= collection.AsQueryable<User>().Where(q =>
            //q.KurumIlgisi.Any(sb => sb.UserType.Tip.Equals(UserTypeEnum.Student))
            // && q.KurumIlgisi.Any(sq => sq.Sezon.SezonAdi.Equals(sezon))
            //).ToList();
            return result;
        }

   
        public List<User> GetUsers()
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<User> collection = MongoDB.GetCollection<User>("Account");
            List<User> result = collection.AsQueryable<User>().Where(q => q.IsActive.Equals(true)  
             
            ).ToList();
            //var MongoDB = _client.GetDatabase(_databaseName);
            //IMongoCollection<User> collection = MongoDB.GetCollection<User>("Account");
            //List<User> result= collection.AsQueryable<User>().Where(q =>
            //q.KurumIlgisi.Any(sb => sb.UserType.Tip.Equals(UserTypeEnum.Student))
            // && q.KurumIlgisi.Any(sq => sq.Sezon.SezonAdi.Equals(sezon))
            //).ToList();
            return result;
        }

        public List<Grade> GetSiniflar(string sezon)
        {
             
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Grade> collection = MongoDB.GetCollection<Grade>("Grade");
            return collection.AsQueryable<Grade>().Where(q => q.Sezon.Equals(sezon) && q.IsActive==true).ToList();
        }

        public List<Grade> GetSiniflarByKurumID(ObjectId kurumID)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Grade> collection = MongoDB.GetCollection<Grade>("Grade");
            return collection.AsQueryable<Grade>().Where(q => q.FK_KurumID.Equals(kurumID)).ToList();
        }

        public void UpdateMenu(List<Menu> tmp)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<Menu> collection = MongoDB.GetCollection<Menu>("Menu");
            foreach (Menu item in tmp)
            {
                collection.ReplaceOne(p => p.id == item.id, item, new UpdateOptions { IsUpsert = false });
             
            }
              
        }

        public void InsertKisiler(List<Kisi> kisiler)
        {
            InsertList<Kisi>(kisiler, "Kisiler");
        }

        public void InsertSMSMessages(List<MessageSMS> lmes)
        {
            InsertList<MessageSMS>(lmes, "GonderilecekMesajlar");
        }

        public List<MessageSMS> GetSMSMessages()
        {
            return GetToList<MessageSMS>("GonderilecekMesajlar");
        }

        public void UpdateSMSMessage(MessageSMS m)
        {
            Update<MessageSMS>(m, "GonderilecekMesajlar");
        }

        public void UpdateKisi(Kisi item)
        {
            Update<Kisi>(item, "Kisiler");
        }

        public void InsertLookedUpDB(LookedUp lup)
        {
            Insert<LookedUp>(lup, "LookedUp");
        }
    }
}
