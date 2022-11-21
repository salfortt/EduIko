using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CacheController
{
   public class RedisConnectionFactory
    {
        static RedisConnectionFactory()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {

#if DEBUG
                //return ConnectionMultiplexer.Connect("147.135.91.230:44324@istanbul343,");
                return ConnectionMultiplexer.Connect("192.168.1.21:6379@istanbul343,,");

#else
         return ConnectionMultiplexer.Connect("192.168.1.21:6379@istanbul343,,");
               
    

#endif

                //redis server conn string bilgisi, web config'den almak daha doğru ancak şimdilik buraya yazdık
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection => lazyConnection.Value;

        public static void DisposeConnection()
        {
            if (lazyConnection.Value.IsConnected)
                lazyConnection.Value.Dispose();
        }
    }


 
}
 
