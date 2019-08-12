namespace CrackingTheCodingInterview
{
    using System;
    using System.Collections.Generic;

    public struct KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class MyHashMap<TKey, TValue>
    {
        private readonly int size;
        private readonly LinkedList<KeyValuePair<TKey, TValue>>[] listAtIndex;

        public MyHashMap(int initSize)
        {
            this.size = initSize;
            listAtIndex = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }

        protected int GetGeneratedIndex(TKey key)
        {
            int index = key.GetHashCode() % size;
            return Math.Abs(index);
        }

        protected LinkedList<KeyValuePair<TKey, TValue>> GetLinkedList(int index)
        {
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = listAtIndex[index];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValuePair<TKey, TValue>>();
                listAtIndex[index] = linkedList;
            }
            return linkedList;
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetGeneratedIndex(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(index);
            KeyValuePair<TKey, TValue> item = new KeyValuePair<TKey, TValue>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        public TValue Find(TKey key)
        {
            int index = GetGeneratedIndex(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(index);

            foreach (KeyValuePair<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default;
        }

        public void Remove(TKey key)
        {
            int index = GetGeneratedIndex(key);
            LinkedList<KeyValuePair<TKey, TValue>> linkedList = GetLinkedList(index);
            bool itemFound = false;
            KeyValuePair<TKey, TValue> foundItem = default;
            foreach (KeyValuePair<TKey, TValue> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
    }
}
