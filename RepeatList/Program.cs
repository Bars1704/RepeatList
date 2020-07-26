using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace RepeatList
{
  

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
                Console.WriteLine(i+x);
            }
        }
    }
}
