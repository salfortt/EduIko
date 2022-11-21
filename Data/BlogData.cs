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
  public class BlogData :MongoDocumentsDatabase
    {

        private BlogData() { }
        private static BlogData Instance;
        private const string collectionName = "Blog";
        public static BlogData GetInstance()
        {
            if (Instance == null)
                Instance = new BlogData();

            return Instance;
        }

        public int InsertBlog(BlogPost g)
        {
            return Insert(g, collectionName);
        }

        public List<BlogPost> GetBlog()
        {
            return GetToList<BlogPost> (collectionName);
        }

        public void UpdateBlog(BlogPost gal)
        {
          
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<BlogPost> collection = MongoDB.GetCollection<BlogPost> (collectionName);
            var filter = Builders<BlogPost> .Filter.Eq(s => s.id, gal.id);

            collection.ReplaceOne(filter, gal);
            //typeof(T).Name
        
    }

        public List<BlogPost> getGetBlogByUserID(ObjectId id)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<BlogPost> collection = MongoDB.GetCollection<BlogPost>(collectionName);
            return collection.AsQueryable<BlogPost>().Where(q => q.UserId.Equals(id)).ToList();

        }

        public BlogPost getGetBlogByBlogID(ObjectId objectId)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<BlogPost> collection = MongoDB.GetCollection<BlogPost>(collectionName);
            return collection.AsQueryable<BlogPost>().Where(q => q.id.Equals(objectId)).FirstOrDefault();
        }

        public  BlogPost getGetBlogByLink(string link)
        {
            var MongoDB = _client.GetDatabase(_databaseName);
            IMongoCollection<BlogPost> collection = MongoDB.GetCollection<BlogPost>(collectionName);
            return collection.AsQueryable<BlogPost>().Where(q => q.URL.Equals(link)).FirstOrDefault();
        }
    }
}
