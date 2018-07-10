using System.Collections.Generic;

namespace LRUCache
{
    class Program
    {
        // use linkedList
        class LRUCache
        {
            int capacity;
            LinkedList<int> cache;
            Dictionary<int, LinkedListNode<int>> table;

            LRUCache(int cap)
            {
                capacity = cap;
                cache = new LinkedList<int>();
                table = new Dictionary<int, LinkedListNode<int>>();
            }

            int Get(int key)
            {
                if (!table.ContainsKey(key))
                {
                    return -1;
                }

                // assign prev 
                cache.AddFirst(table[key].Value);
                // this is O(1) according to documentation 
                cache.Remove(table[key]); 
                // Move this key to the front of the cache
                return cache.First.Value;
            }

            void Put(int key, int value)
            {
                // Key already exists
                if (table.ContainsKey(key))
                {
                    // Update the value
                    Get(key);
                    table[key].Value = value;
                    return;
                }

                // Reached the capacity, remove the oldest entry
                if (cache.Count == capacity)
                {
                    table.Remove(key);
                    cache.RemoveLast();
                }

                // Insert the entry to the front of the cache and update mapping.
                cache.AddFirst(new LinkedListNode<int>(value));
                table[key] = cache.First;
            }

        };

        static void Main(string[] args)
        {
        }
    }
}
