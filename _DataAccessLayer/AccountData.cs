using Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccessLayer
{
   public  class AccountData : MongoDocumentsDatabase
    {
        private AccountData() { }
        private static AccountData Instance;
        private const string collectionName = "Account";
        public static AccountData GetInstance()
        {
            if (Instance == null)
                Instance = new AccountData();

            return Instance;
        }

       

        public User GetAccount( string mail, string password)
        {
          //  var filter = Builders<User>.Filter.Eq(mail, password);

            User user = _database.GetCollection<User>(collectionName).AsQueryable().Where(q=>q.mail.Equals(mail) && q.password.Equals(password) && q.IsActive==true).FirstOrDefault();
                
                
                //.Find(filter).FirstOrDefault();
            //typeof(T).Name
            return user;
        }

        public List<UserType> GetUserType()
        {
            return GetToList<UserType>("UserType");
        }

        public User GetUsersListByIDs(ObjectId userID)
        {
            return _database.GetCollection<User>(collectionName).AsQueryable().Where(q => q.id==userID).FirstOrDefault();
        }

        public int InsertAccount(User k)
        {

            return Insert(k, collectionName);
        }

        public User GetAccountTCNO(string tcno, string p)
        {

            User user = _database.GetCollection<User>(collectionName).AsQueryable().Where(q => q.TCNo >0 && q.TCNo.Equals(tcno) && q.password.Equals(p)).FirstOrDefault();
 
            return user;
        }

        public List<ObjectId> GetUsersObjectIdByGradeID(ObjectId id)
        {
            return _database.GetCollection<User>(collectionName).AsQueryable().Where(q => q.FK_ClassId == id && q.UserType.Tip == UserTypeEnum.Student.ToString() && q.IsActive == true).Select(s=>s.id).ToList();

        }

        public List<User> GetUsersByGradeID(ObjectId id)
        {
            return _database.GetCollection<User>(collectionName).AsQueryable().Where(q => q.FK_ClassId==id && q.UserType.Tip==UserTypeEnum.Student.ToString() && q.IsActive==true).ToList();
        }

        public void InsertAccountType(List<UserType> ut)
        {
            InsertList(ut,"UserType");
        }

        public List<User> GetUsersListByIDs(List<ObjectId> list)
        {
            return _database.GetCollection<User>(collectionName).AsQueryable().Where(q => list.Contains( q.id)).ToList();
        }

        public User GetUser(ObjectId id)
        {

            User user = _database.GetCollection<User>(collectionName).AsQueryable().Where(q => q.id.Equals(id)).FirstOrDefault();


            //.Find(filter).FirstOrDefault();
            //typeof(T).Name
            return user;
        }

        public void UserUpdate(User u)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<User> collection = MongoDB.GetCollection<User>(collectionName);
            var filter = Builders<User>.Filter.Eq(s => s.id, u.id);

            collection.ReplaceOne(filter, u);
        }

        public List<User> GetUsersIdarecilerList()
        {
 
      List<User>   lu=    _database.GetCollection<User>(collectionName).AsQueryable().Where(q => q.IsActive==true && q.UserType.Tip == UserTypeEnum.Teacher.ToString()
      || q.UserType.Tip == UserTypeEnum.Director.ToString()
           || q.UserType.Tip == UserTypeEnum.Manager.ToString()
      ).ToList().OrderBy(o=>o.Adi).ToList() ;
 
            return lu;
            //"UserType.Tip":"Öğretmen", "KurumIlgisi.Sezon.SezonAdi":"2018 - 2019"
        }

        public List<YetkiTipi> GetYetkiTipi()
        {
            return GetToList<YetkiTipi>("YetkiTipi");
        }

        public void InsertYetkisizGiris(YetkisizGiris yg)
        {
            Insert(yg, "YetkisizGiris");
        }

        public void InsertAccountFC(FCPerson person)
        {
             

            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<FCPerson> collection = MongoDB.GetCollection<FCPerson>("FCPerson");

            collection.ReplaceOne(p => p.id == person.id,    person,    new UpdateOptions { IsUpsert = true });

        }

        public FCPerson GetFaceAccountByFaceID(string id)
        {
            FCPerson user = _database.GetCollection<FCPerson>("FCPerson").AsQueryable().Where(q => q.id.Equals(id)).FirstOrDefault();
            return user;
        }

        public User GetAccountByFaceID(string id)
        {
            User user = _database.GetCollection<User>(collectionName).AsQueryable().Where(q => q.FacebookID.Equals(id)).FirstOrDefault();

            return user;
        }

        public List<YetkiAlan> GetYetkiAlan()
        {
            return GetToList<YetkiAlan>("YetkiAlan");
        }

        public List<User> GetUsersList()
        {
            return GetToList<User>(collectionName);
        }
        public void InsertYetki(YetkiTipi y)
        {
            Insert(y, "YetkiTipi");
        }

        public void InsertYetkiAlan(YetkiAlan ya)
        {
            Insert(ya, "YetkiTipiAlan");
        }
    }
}
