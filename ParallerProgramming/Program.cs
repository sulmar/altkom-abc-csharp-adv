using System;

namespace ParallerProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ThreadTests.SyncTest();
            // ThreadTests.StartThreadTest();
            //ThreadTests.StartThreadWithParameterTest();
            // ThreadTests.StartThreadWithParameterTest2();
            //   ThreadTests.MultiDownload();

            // ThreadPoolTests.Test();

            TaskTests.Test();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
