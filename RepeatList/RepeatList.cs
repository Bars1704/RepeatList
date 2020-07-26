using System;
using System.Collections.Generic;
using System.Text;

namespace RepeatList
{
    public class RepeatList<T> : List<T>
    {
        public bool CanselizationToken;
        int Counter;
        public RepeatList()
        {
            Reset();
        }
        public RepeatList(IEnumerable<T> y):base(y)
        {
            Reset();
        }
        public RepeatList(int size) : base(size)
        {
            Reset();
        }
        void Reset()
        {
            Counter = 0;
            CanselizationToken = false;
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
