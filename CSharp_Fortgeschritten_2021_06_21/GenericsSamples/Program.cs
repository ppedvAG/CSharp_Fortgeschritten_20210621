using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<string> strList = new List<string>(); //typisierte Liste


            IDictionary<int, Items> itemDict = new Dictionary<int, Items>();

            


            itemDict.Add(111, new Items());
            itemDict.Add(111, new Items()); //-> Exception wird geschmissen



            KeyValuePair<int, Items> newItem = new KeyValuePair<int, Items>(122, new Items());
            itemDict.Add(newItem);


            foreach (KeyValuePair<int, Items> currentItem in itemDict)
            {
                //currentItem.Key;
                //currentItem.Value;
            }


            if (!itemDict.ContainsKey(112))
            {
                itemDict.Add(112, new Items);
            }



            Hashtable hashTable = new Hashtable();
            hashTable.Add(123, "hallo Welt");
            hashTable.Add("abc", DateTime.Now);


            //Befüllte Auswahl Liste (selektiere 1 oder mehrer Items)
            // Item 1
            // Item 3 

            //Deine Liste mit Items 
            // Item 2



            DataStore<Guid, int> data = new DataStore<Guid, int>();
            data.AddOrUpdate(1, Guid.NewGuid());

            data.AddOrUpdate(2, Guid.NewGuid())
            data.WhatISABC(33);

        }
    }


    public class Items
    {
        public Items()
        {

        }
        //...
    }



    public class DataStore<T, ABC>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }


        public void WhatISABC(ABC item)
        { 
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }

        public void DisplayDefault<DD>()
        {
            DD item = default(DD);
            Console.WriteLine($"Default value of {typeof(DD)} is {(item == null ? "null" : item.ToString())}.");
        }
    }


}
