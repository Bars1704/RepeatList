using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace RepeatList
{
    public class RepeatList<T> : IEnumerable<T>,IList<T>
    {
        public int Capacity { get { return datas.Length; } }
        public bool IsReadOnly => throw new NotImplementedException();
        T IList<T>.this[int index] { get => this[index]; set => this[index] = value; }
        public int Count { get; private set ; }

        public bool CanselizationToken;
        T[] datas;
        int Counter;
        public RepeatList()
        {
            Reset();
            datas = new T[1];
        }
        void Reset()
        {
            Count = 0;
            Counter = 0;
            CanselizationToken = false;
        }
        public RepeatList(IEnumerator<T> y)
        {
            int size = 0;

            do
            {
                size++;
            } while (y.MoveNext());
            y.Reset();

            datas = new T[size];
            for (int i = 0; i < size; i++)
            {
                datas[i] = y.Current;
                y.MoveNext();
            }

            Reset();

        }
        public RepeatList(int size)
        {
            Reset();
            datas = new T[size];
        }
        T this[int index]
        {
            get { return datas[index]; }
            set { datas[index] = value; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            while(Counter != Capacity)
            {
                if (CanselizationToken)
                {
                    yield break;
                }
                if (Counter == Capacity - 1)
                {
                    Counter = 0;
                }
                yield return datas[Counter++];
            }  
        }
        public void Add(T data)
        {
            if (Count >= Capacity)
            {
                T[] newData = new T[Capacity +3];
                datas.CopyTo(newData, 0);
                datas = newData;
            }
            datas[Count++] = data;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)datas).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            datas[index] = default(T);
            for(int i = index; i < Count-1; i++)
            {
                datas[i] = datas[i + 1];
            }
            Count--;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RepeatList<int> test = new RepeatList<int> { 1, 2, 3 };
            int i = 0;
            foreach (var x in test)
            {
                i++;
                if (i == 100)
                {
                    test.CanselizationToken = true;
                }
                Console.WriteLine(x);
            }
        }
    }
}
