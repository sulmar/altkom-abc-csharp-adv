using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ParallerProgramming
{
    class TaskTests
    {
        private static int ManagedThreadId => Thread.CurrentThread.ManagedThreadId;

        public static void Test()
        {
            // CreateTaskTest();
            // RunTaskTest();
            // RunTaskTest2();

            // CalculateSyncTest();
            //CalculateAsyncTest();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            CancellationToken token = cancellationTokenSource.Token;

            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(4));

            Progress<string> progress = new Progress<string>(p => Console.Write(p));


            Task.Run(()=>CalculateAsyncAwaitTest(token, progress));

            Console.WriteLine("Press any key to cancel.");
            Console.ReadKey();

            cancellationTokenSource.Cancel();

        }

        private static void CalculateSyncTest()
        {
            decimal salary = Calculate(100);
            decimal total = Calculate(salary, 1);
            Console.WriteLine($"result {salary}");
        }
        private static async Task CalculateAsyncAwaitTest(
            CancellationToken token = default,
            IProgress<string> progress = null)
        {
            decimal salary = await CalculateAsync(10000, token, progress);
            decimal total = await CalculateAsync(salary, 1);
            Console.WriteLine($"result: {total}");
        }

        private static Task CalculateAsyncTest()
        {
            return CalculateAsync(100)
                .ContinueWith(t => CalculateAsync(t.Result, 1))
                    .ContinueWith(t => Console.WriteLine($"result {t.Result.Result}"));
        }

        public static Task<decimal> CalculateAsync(decimal amount, 
            CancellationToken cancellationToken = default,
             IProgress<string> progress = null
            )
        {
            return Task.Run(() => Calculate(amount, cancellationToken, progress));
        }

        public static decimal Calculate(decimal amount, 
            CancellationToken cancellationToken = default,
            IProgress<string> progress = null
            )
        {
           
            Console.WriteLine($"#{ManagedThreadId} calculating...");

            for (int i = 0; i < 10; i++)
            {
                //if (cancellationToken.IsCancellationRequested)
                //{
                //    return 0;
                //}

                cancellationToken.ThrowIfCancellationRequested();


                Thread.Sleep(TimeSpan.FromSeconds(1));

                progress?.Report(".");
                // Console.Write(".");
            }
            
            Console.WriteLine($"#{ManagedThreadId} calculated.");
            return amount * 1.23m;
        }

        public static Task<decimal> CalculateAsync(decimal amount, byte count, decimal rate = 500)
        {
            return Task.Run(() => Calculate(amount, count, rate));
        }

        public static decimal Calculate(decimal amount, byte count, decimal rate = 500)
        {
            if (count<0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (rate<0)
            {
                throw new ArgumentOutOfRangeException(nameof(rate));
            }
            

            Console.WriteLine($"#{ManagedThreadId} calculating children...");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"#{ManagedThreadId} calculated.");
            return amount + rate * count;
        }


        private static void CreateTaskTest()
        {
            Task task = new Task(() => Download("http://www.google.com"));
            task.Start();
        }

        private static void RunTaskTest()
        {
            for (int i = 0; i < 100; i++)
            {
               // Task.Factory.StartNew(() => Download("http://www.google.com"));

                Task.Run(() => Download("http://www.google.com"));
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
            }
        }

        private static void RunTaskTest2()
        {
            Task[] tasks = new Task[10];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() => Download("http://www.google.com"));
            }

            tasks.ToList().ForEach(t => t.Start());

            Task.WhenAll(tasks).Wait();

        }

        private static void WaitTaskTest()
        {
            Task t1 = Task.Run(() => Download("http://www.google.com"));

            t1.Wait();

            Console.WriteLine("Do work");
            

        }

        public static void Download(string url)
        {
            Console.WriteLine($"#{ManagedThreadId} downloading...");

            using var client = new WebClient() ;
            string content = client.DownloadString(url);
            Console.WriteLine($"#{ManagedThreadId} downloaded {url} {content.Length} size");

        }

       
    }
}
