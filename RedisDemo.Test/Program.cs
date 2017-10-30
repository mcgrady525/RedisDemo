using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSharing.Frameworks.Redis;
using SSharing.Frameworks.Common.Extends;

namespace RedisDemo.Test
{
    class Program
    {
        private static readonly string testKey= "Ubtrip.HomeTicket.TestKey";
        private static readonly string testKey111 = "Ubtrip.HomeTicket.TestKey111";

        static void Main(string[] args)
        {
            var redisClient = new RedisWrapper();

            //add
            redisClient.Add(testKey, "hello redis");

            //get
            var result = redisClient.Get(testKey);

            //update
            if (!result.IsNullOrEmpty())
            {
                redisClient.Update(testKey, "hello redis update at 2017-10-30 10:49:16");
            }

            //remove
            redisClient.Remove(testKey);


            //json
            var m = new TestRedis
            {
                Id= 1,
                Name= "zhangsan",
                Address= new Address
                {
                    PostNumber= "111222",
                    AddressDetail= "深圳市宝安区旭生大厦1213"
                }
            };
            redisClient.Add<TestRedis>(testKey111, m);

            var result1 = redisClient.Get<TestRedis>(testKey111);
            
            Console.ReadKey();
        }
    }

    class TestRedis
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }
        
    }

    class Address
    {
        public string PostNumber { get; set; }

        public string AddressDetail { get; set; }

    }
}
