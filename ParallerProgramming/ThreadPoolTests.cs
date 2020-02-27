using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace ParallerProgramming
{
    class ThreadPoolTests
    {
        private static int ManagedThreadId => Thread.CurrentThread.ManagedThreadId;

        public static void Test()
        {
            ThreadPoolTest();
        }

        private static void ThreadPoolTest()
        {
            ThreadPool.SetMaxThreads(4, 4);

            ThreadPool.GetAvailableThreads( out int workers, out int io);

            ThreadPool.QueueUserWorkItem(new WaitCallback(Download), "http://www.google.pl");

            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Download), "http://www.google.pl");
            }
        }

        public static void Download(object url)
        {
            Download((string)url);
        }

        public static void Download(string url)
        {
            Console.WriteLine($"#{ManagedThreadId} downloading...");
            
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //using (var client = new WebClient())
            //{
            //    string content = client.DownloadString(url);



            //    Console.WriteLine($"#{ManagedThreadId} downloaded {url} {content.Length} size");
            //}

            Console.WriteLine($"#{ManagedThreadId} downloaded {url}");
        }

    }
}
