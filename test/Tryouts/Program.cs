using System;
using SlowTests.Bugs;
using SlowTests.Issues;
using FastTests.Voron.Storage;

namespace Tryouts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {   
                Console.WriteLine(i);
                using (var test = new RavenDB_7698())   
                {
                    test.CanRestartEmptyAsyncTransaction();
                }
            }
        }
    }
}
