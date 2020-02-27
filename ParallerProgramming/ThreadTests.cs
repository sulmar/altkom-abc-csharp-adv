using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace ParallerProgramming
{
    class ThreadTests
    {

        private static int ManagedThreadId => Thread.CurrentThread.ManagedThreadId;

        public static void SyncTest()
        {
            Console.WriteLine($"#{ManagedThreadId} Test ");
            Send();
            Console.WriteLine($"#{ManagedThreadId} Success.");
        }

        public static void StartThreadTest()
        {
            Console.WriteLine($"#{ManagedThreadId} Test ");
            Thread thread = new Thread(Send);

            thread.Start();

            Console.WriteLine($"#{ManagedThreadId} Success.");
        }

        public static void StartThreadWithParameterTest()
        {
            Console.WriteLine($"#{ManagedThreadId} Test ");
            Thread thread1 = new Thread(Download);
            Thread thread2 = new Thread(Download);
            Thread thread3 = new Thread(Download);

            thread1.Start("http://www.altkom.pl");
            thread2.Start("http://www.google.com");
            thread3.Start("http://www.microsoft.com");

            Console.WriteLine($"#{ManagedThreadId} Success.");
        }
        public static void StartThreadWithParameterTest2()
        {
            Console.WriteLine($"#{ManagedThreadId} Test ");
            Thread thread1 = new Thread(() => Download("http://www.altkom.pl"));
            Thread thread2 = new Thread(() => Download("http://www.google.com"));
            Thread thread3 = new Thread(() => Download("http://www.microsoft.com"));

            thread1.Start();
            thread2.Start();
            thread3.Start();

            Console.WriteLine($"#{ManagedThreadId} Success.");
        }

        public static void MultiDownload()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread2 = new Thread(() => Download("http://www.google.com"));
                thread2.Start();
            }
        }

        public static void Download(string url)
        {
            Console.WriteLine($"#{ManagedThreadId} downloading...");
            var client = new WebClient();
            string content = client.DownloadString(url);
            Console.WriteLine($"#{ManagedThreadId} downloaded {url} {content.Length} size");
        }
        public static void Download(object url)
        {
            Console.WriteLine($"#{ManagedThreadId} downloading...");
            var client = new WebClient();
            string content = client.DownloadString((string)url);
            Console.WriteLine($"#{ManagedThreadId} downloaded {url} {content.Length} size");
        }

        public static void Send()
        {
            Console.WriteLine($"#{ManagedThreadId} Sending...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{ManagedThreadId} Sent.");
        }

        
    }
}
