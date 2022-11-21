using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using MongoDB.Bson;

namespace BusinessLayer
{
    public class BlogBusiness
    {
        private BlogBusiness() { }
        private static BlogBusiness Instance;

        public static BlogBusiness GetInstance()
        {
            if (Instance == null)
                Instance = new BlogBusiness();

            return Instance;
        }



        private BlogData _dalc;
        private BlogData dalc
        {
            get
            {
                if (_dalc == null)
                    _dalc = BlogData.GetInstance();

                return _dalc;
            }
        }

        public int InsertBlog(BlogPost g) {

            dalc.InsertBlog(g);

            return 1;
        }
        public int UpdateBlog(BlogPost g)
        {

            dalc.UpdateBlog(g);

            return 1;
        }
        public List<BlogPost> getGetBlog()
        {
            return dalc.GetBlog();
        }
        public List<BlogPost> getGetBlogByUserID(ObjectId id)
        {
            return dalc.getGetBlogByUserID(id);
        }

        public  BlogPost  getGetBlogByLink(string link)
        {
            return dalc.getGetBlogByLink(link);
        }

        public BlogPost getGetBlogByBlogID(ObjectId objectId)
        {
            return dalc.getGetBlogByBlogID(objectId);
        }
    }
}
