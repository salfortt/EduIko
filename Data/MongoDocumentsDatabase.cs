using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB;

namespace Data
{
    public class MongoDocumentsDatabase 
    {
        ///////////////////////// eski server  public const string connectionString = "mongodb://gurkan:istanbul343@mongo1:27017?readPreference=secondaryPreferred;connectTimeoutMS=300000;socketTimeoutMS=600000;maxPoolSize=5000000;wtimeout=3600000;wtimeoutMS=3600000";

        //mongodb://gurkan:istanbul343@mongo1:27017?authMechanism=SCRAM-SHA-256;replicaSet=my_mongodb_0;


#if DEBUG
        public const string connectionString = "mongodb://gurkan:istanbul343@mongo1:27017,mongo2:27017,mongo3:27017?connectTimeoutMS=300000;socketTimeoutMS=600000;maxPoolSize=5000000;wtimeout=3600000;wtimeoutMS=3600000";

        //public const string connectionString = "mongodb://gurkan:istanbul343@147.135.91.230:44323?readPreference=secondaryPreferred;connectTimeoutMS=300000;socketTimeoutMS=600000;maxPoolSize=5000000;wtimeout=3600000;wtimeoutMS=3600000";

        // public const string connectionString = "mongodb://gurkan:istanbul343@147.135.91.230:44323?authMechanism=SCRAM-SHA-256&readPreference=secondaryPreferred;connectTimeoutMS=300000;socketTimeoutMS=600000;maxPoolSize=5000000;wtimeout=3600000;wtimeoutMS=3600000";

        // mongodb://gurkan:istanbul343@192.168.1.2:27017,192.168.1.3:27017,192.168.1.4:27017/?authMechanism=SCRAM-SHA-256&authSource=admin&replicaSet=my_mongodb_0&readPreference=primary
        //connect=replicaSet;replicaSet=my_mongodb_0;w=1;readPreference=secondaryPreferred;connectTimeoutMS=300000;socketTimeoutMS=600000;maxPoolSize=5000000;wtimeout=3600000;wtimeoutMS=3600000

#else
        public const string connectionString = "mongodb://gurkan:istanbul343@mongo1:27017,mongo2:27017,mongo3:27017?connectTimeoutMS=300000;socketTimeoutMS=600000;maxPoolSize=5000000;wtimeout=3600000;wtimeoutMS=3600000";
   
 
#endif
        public string _databaseName = "KurumlarProjesi";
        public string _databaseNameEduiko = "Eduiko";
        /// <summary>
        /// MongoDB Server
        /// </summary>
        public IMongoClient _client;
        public IMongoDatabase _database;
        //  private readonly string connectionString = "mongodb://localhost:27017/GSM";
        /// <summary>
        /// Name of database 
        /// </summary>
       

        public MongoUrl MongoUrl { get; private set; }

        /// <summary>
        /// Opens connection to MongoDB Server
        /// </summary>
        protected MongoDocumentsDatabase()
        {
            MongoUrl = MongoUrl.Create(connectionString);
            
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase( _databaseName);

        }

        /// <summary>
        /// Get database
        /// </summary>
        protected IMongoDatabase Database
        {
            get { return _client.GetDatabase(_databaseName); }
        }

        protected int InsertList<T>(List<T> data, string collectionName)
        {
            try
            {
                var MongoDB = _client.GetDatabase(_databaseName);
                IMongoCollection<T> collection = MongoDB.GetCollection<T>(collectionName);
                collection.InsertMany(data);
            }
            catch (Exception)
            {

                throw;
            }
           
            //typeof(T).Name
            return 1;
        }
        protected int Insert<T>(T data, string collectionName)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<T> collection = MongoDB.GetCollection<T>(collectionName);

           int result = 0;

            try
            {
                collection.InsertOne(data);
                result = 1;
            }
            catch (Exception ex)
            {

                throw;
            }

           
             
            return result;
        }
        protected void Update<T>(T data, string collectionName) where T : IWithId
        {
            var tt = data.id;
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<T> collection = MongoDB.GetCollection<T>(collectionName);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(s => s.id, data.id);
            collection.ReplaceOne(filter, data);
            
        }

        protected List<T> GetToList<T>(string collectionName)
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            //typeof(T).Name
            return collection.Find(_ => true).ToList();
        }

        protected T GetDocument<T>(string collectionName)
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);
            //typeof(T).Name
            return collection.Find(_ => true).FirstOrDefault();
        }

       




        //     public IMongoCollection<Zoo> Zoo { get { return Database.GetCollection<Zoo>("zoo"); } }
    }
}
