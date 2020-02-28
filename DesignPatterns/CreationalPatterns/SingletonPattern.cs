using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns
{
    class SingletonPattern
    {

        public static void Test()
        {
            After();
        }

        //public static void Before()
        //{
        //    Logger logger = new Logger();
        //    logger.Log("Hello");


        //    if (logger != null)
        //    {
        //        logger = new Logger();
        //    }

        //    logger.Log("World!");
        //}

        public static void After()
         {
            
            Logger logger1 = Logger.Instance;

            logger1.Log("Hello");

            Logger logger2 = Logger.Instance;
            logger2.Log("Hello");

            ISender sender1 = Singleton<Sender>.Instance;
            ISender sender2 = Singleton<Sender>.Instance;
        }
    }

    class Logger
    {
        protected Logger()
        {
            Console.WriteLine("ctor!");
        }

        private static object syncLock = new object();

        private static Lazy<Logger> lazyLogger = new Lazy<Logger>(new Logger());

        private static Logger logger = null;
        public static Logger Instance
        {
            get
            {
                return lazyLogger.Value;

                lock (syncLock)
                {
                    if (logger == null)
                    {
                        logger = new Logger();
                    }
                }

                return logger;
            }
        }

        public void Log(string message)
        {
            System.IO.File.WriteAllText("log.txt", message);
        }
    }

    public interface ISender
    {
        void Send(string message);
    }
    public class Sender : ISender
    { 
        public void Send(string message)
        {
            Console.WriteLine($"Send {message}");
        }
    }

    public sealed class Singleton<T>
        where T : new()
    {
        private static readonly Lazy<T> lazy = new Lazy<T>(() => new T());
        public static T Instance => lazy.Value;
        private Singleton()
        {
        }

    }


}
