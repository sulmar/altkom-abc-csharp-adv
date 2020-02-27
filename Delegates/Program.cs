using System;

namespace Delegates
{
    class Program
    {

        static void Main(string[] args)
        {
            LinqTests.Test();
            //ExpressionTests.Test();
            // DelegatesTest();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void DelegatesTest()
        {
            Printer printer = new Printer();

            printer.CalculateCost += copies => copies * 1.99m;

            printer.Log += LogConsole;
            printer.Log += LogFile;
            // printer.Log += LogFacebook;

            // Metoda anonimowa
            printer.Log += delegate (string message)
            {
                Console.WriteLine($"anonymous {DateTime.Now} {message}");
            };

            // Wyrażenie lambda
            printer.Log += message => Console.WriteLine($"lambda {DateTime.Now} {message}");

            printer.Print("Hello World!");


            printer.Log -= LogFile;
            printer.Print("Hello .NET Core!");

            printer.Log = null;
            printer.Print("Hello C#!");
        }

        public static void LogFacebook(string message, string username = "marcin")
        {

        }


        public static void LogConsole(string message)
        {
            Console.WriteLine($"{DateTime.Now} {message}");
        }

        public static void LogFile(string content)
        {
            System.IO.File.WriteAllText("log.txt", $"{DateTime.Now} {content}");
        }

    }
}
