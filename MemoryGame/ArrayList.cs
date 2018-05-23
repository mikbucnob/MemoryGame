using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class ArrayList<T> : IEnumerable<T>
    {
        private T[] theArray;
        private int index = 0;

        public ArrayList() : this(52) { }
        
        public ArrayList(int size)
        {
            theArray = new T[size];
        }

        public int Count
        {
            get { return theArray.Length; }
        } 


        public T this[int i]
        {
            get { return theArray[i]; }
            set { theArray[i] = value; }
        }

        public void Add(T value)
        {
            theArray[index] = value;
            index++;

            if (index > theArray.Length)
                Resize(theArray.Length * 2);
        }

        public T Get(int value)
        {
            return theArray[value];
        }

        public void RemoveAll(T val)
        {
            Remove(val, false);
        }

        public void Remove(T val)
        {
            Remove(val, true);
        }

        private void Remove(T val, Boolean all)
        {
            for (int i = 0; i < theArray.Length; i++)
            {
                if (theArray[i].Equals(val))
                {
                    theArray[i] = default(T);
                    if (all) return;
                }
            }
        }


        private void Resize(int newSize)
        {
            Array.Resize(ref theArray, newSize);
        }

        public void Compact()
        {

            T temp = default(T);
            //theArray = theArray.Except(new T[] { temp }).ToArray();
            //return;
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/default-values-table

            int count = 0;
            for (int i = 0; i < theArray.Length; i++)
            {

                // if (theArray[i].Equals(default(T))) // how to use generics here


                if (!object.Equals(temp, theArray[i]))
                {
                    count++;
                }


            }
            T[] newArray = new T[count];
            int j = 0;
            for (int i = 0; i < theArray.Length; i++)
            {
                // if (theArray[i].Equals(default(T))) // how to use generics here

                if (!object.Equals(temp, theArray[i]))
                {
                    newArray[j] = theArray[i];
                    j++;
                }
            }

            theArray = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int x = 0; x < theArray.Length; x++)
            {
                yield return theArray[x];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}


