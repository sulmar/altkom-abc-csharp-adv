using System;
using ExtensionMethods.Helpers;


namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (DateTime.Today.IsHoliday())
            {
                Console.WriteLine("Hooray weekend!");
            }
            else
            {
                Console.WriteLine(":-(");            
            }
        }

        // Fluent DateTime
        // https://github.com/FluentDateTime/FluentDateTime
    }
}
