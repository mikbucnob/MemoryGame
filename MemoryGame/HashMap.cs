using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HashMap<K, V>
    {
        public class Pair : IComparable<Pair>
        {
            public K key;
            public V value;
            public Pair(K key, V value) { this.key = key; this.value = value; }

            public int CompareTo(Pair other)
            {
               return this.key.Equals(other.key)?0:-1;
            }
        }

        public int Count { get; private set; }

        private System.Collections.Generic.LinkedList<Pair>[] data;//array of list of Pair

        public HashMap()
        {
            
        }

        public void Add(K key, V value)
        {
                int hash = Hash(key);
                if (data == null)
                    Resize(hash + 1);
                else if (data.Length <= hash)
                    Resize(hash + 1);
                if (data[hash] == null)
                    data[hash] = new System.Collections.Generic.LinkedList<Pair>();
                data[hash].AddFirst(new Pair(key, value));
                Count++;
        }

        private int Hash(K key)
        {
            int hash;
            hash = key.GetHashCode();
            hash = hash % 1000;
            if (hash < 0)
                hash = Math.Abs(hash);
            return hash;
        }


        public void Remove(K key)
        {
            int hash = Hash(key);
            ICollection<Pair> myList = data[hash];
            myList.Remove(Find(key));
            Count--;
        }

        private Pair Find(K key)
        {
            int hash = Hash(key);
            ICollection<Pair> myList = data[hash];
            foreach (Pair p in myList)
            {
                if (p.key.Equals(key)) /*found the CORRECT value*/
                {
                    return p;

                }
            }
            return null;
        }

        public bool Contains(K key)
        {
            int hash = Hash(key);
            if (!(data[hash] == null))
            {
                foreach (var pair in data[hash])
                {
                    if (pair.CompareTo(new Pair(key, default(V))) == 0)
                        return true;
                }
            }
            return false;
        }

        public V Get(K key)
        {
            if (Find(key) != null)
                return Find(key).value;
            else
                return default(V);
        }

        private void Resize(int newSize)
        {
            Array.Resize(ref data, newSize);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private static void TraverseList<T>(LinkedList<T> LinkedList)
        {
            foreach (var item in LinkedList)
            {
                Console.WriteLine(item);
            }
        }
        //go to each element of array
        //print the list, must be inside

    }
}
