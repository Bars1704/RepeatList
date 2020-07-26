using System;
using System.Collections.Generic;
using System.Text;

namespace RepeatList
{
    public class RepeatList<T> : List<T>
    {
        public bool IsReadOnly => throw new NotImplementedException();

        public bool CanselizationToken;
        int Counter;
        public RepeatList()
        {
            Reset();
        }
        void Reset()
        {
            Counter = 0;
            CanselizationToken = false;
        }
        public RepeatList(IEnumerator<T> y)
        {
            do
            {
                Add(y.Current);
            } while (y.MoveNext());
            Reset();
        }
        public RepeatList(int size) : base(size)
        {
            Reset();
        }
        public new T this[int index]
        {
            get { return base[index % Count]; }
            set { base[index % Count] = value; }
        }
        public new IEnumerator<T> GetEnumerator()
        {
            while (Counter != Capacity)
            {
                if (CanselizationToken)
                {
                    yield break;
                }
                if (Counter == Capacity - 1)
                {
                    Counter = 0;
                }
                yield return base[Counter++];
            }
        }
    }
}
