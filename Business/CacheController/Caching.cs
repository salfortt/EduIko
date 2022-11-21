using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CacheController
{
   public class Caching
    {
        private static Caching Instance;

        // ICache redisCache = new RedisCache();

        //    var userToBeCached = new User
        //    {
        //        Id = 1,
        //        Email = "sadasd@gmail.com",
        //        FirstName = "Gürkan",
        //        LastName = "Aydın"
        //    };
        //    var key1 = "isim";

        //    redisCache.Set(key1, userToBeCached, DateTime.Now.AddMinutes(30));//30 dakikalığına objemizi redis'e atıyoruz

        //        if (redisCache.Exists(key1))
        //        {
        //            var userRedisResponse = redisCache.Get<User>(key1);
        //}

        private static ICache mycache;
        private static ICache myCache
        {
            get
            {
                if (mycache == null)
                    mycache = new RedisCache();

                return mycache;
            }
        }

        public static Caching GetInstance()
        {
            if (Instance == null)
                Instance = new Caching();
            return Instance;
        }

        public AccountMap GetAccountMap()
        {
            if (mycache.Exists("accountMap"))
                return mycache.Get<AccountMap>("accountMap");
            else
                return null;
        }

    }
}
