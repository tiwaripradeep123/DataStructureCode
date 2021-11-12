using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp._2021
{


    /*
     Cache = size = 3
     1... 10, 11 -> evict/store 

    Dictionary<Key, Value> 
    
    var keyOccurances = new List<string>(3); // ContainsKey(key), Remove(key), Add(Key);
    List.RemoveAt(0)

    keyOccurancesCount = size;
    
    Add(key, value)
    1. Check if we can add new entry // keyOccurances.Count = size;
        1. no - 
            1. Add the keys in cache and also in the keyOccurances at the top.
            2. update -> update cache and also bring key to the top in keyOccurances.
       2. get the key to be evicted 
            1. Get the key from first element in the keyOccurances
            2. 
    Get(key)
     1. Caceh Hit 
     2. Cache miss -> Add(key, func => {})
        
    MemCache 

    count = 2 .. N 
    APP instance 1   
    APP instance 2 

    ...
    APP instance N
    
    RedisCache 

     
     */

    public class TestLRUCache
    {
        public static void Tests()
        {
            var lruCache = new LRUCache(5);
            Random rand = new Random(1);

            for (int i = 0; i < 100; i++)
            {

                var key = rand.Next(1, 10).ToString();
                Console.WriteLine($"Getting Key {key} -> value {lruCache.Get(key)}");
            }
        }
    }


    public class LRUCache
    {
        int size = -1;
        
        public LRUCache() : this(10)
        {

        }
        public LRUCache(int cacheSize)
        {
            size = cacheSize;
            cache = new Dictionary<string, string>(size);
            frequencyList = new List<string>(size);
        }

        Dictionary<string, string> cache = null;
        List<string> frequencyList = null;

        public string Get(string key)
        {
            if (cache.ContainsKey(key))
            {
                Console.WriteLine($"Found key {key}");
                frequencyList.Remove(key);
                frequencyList.Add(key);
                return cache[key];
            }
            else
            {
                Console.WriteLine($"Mising key {key}");

                return Add(key);
            }
        }

        // authorization 

        public string Add(string key)
        {
            Console.WriteLine($"Adding key {key}");
            string value = GetValueFromStore();

            if (frequencyList.Count == size)
            {
                Console.WriteLine($"Limit reached while getting {key}");
                var lruKey = frequencyList[0];
                frequencyList.RemoveAt(0);
                cache.Remove(lruKey);
                frequencyList.Add(key);
                cache.Add(key, value);
            }
            else
            {
                Console.WriteLine($"Limit NOT reached [{frequencyList.Count}/ {size}] while getting {key}");
                frequencyList.Add(key);
                cache.Add(key, value);
            }
            return value;
        }

        private static string GetValueFromStore()
        {
            Random rand = new Random();
            string value = rand.Next(1, 1000).ToString();
            return value;
        }
    }
}
