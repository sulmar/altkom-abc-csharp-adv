using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns
{
    class FactoryMethod
    {
        public static void Test()
        {
            Before();
            After();
        }

        public static void Before()
        {
            string input = Console.ReadLine();

            decimal totalAmount;

            /*
              if (input=="NFZ")
              {
                totalAmount = 0;      
              }
              else if (input="Pakiet")
              {
                totalAmount = 100;
              }
              else
              {
                totalAmount = 200;
              }

            */


            switch (input)
            {
                case "PS": totalAmount = 100; break;
                case "NFZ": totalAmount = 0; break;
                case "Pakiet": totalAmount = 100; break;
                default: totalAmount = 200; break;
            }

            Console.WriteLine($"Total amount: {totalAmount}");

        }

        public static void After()
        {
            string input = Console.ReadLine();

            IVisitFactory visitFactory = new VisitFactory();

            Visit visit = visitFactory.Create(input);

            decimal totalAmount = visit.CalculateTotalAmount();

            Console.WriteLine($"Total amount: {totalAmount}");
        }
    }


    interface IVisitFactory
    {
        Visit Create(string symbol);
    }

    class VisitFactory : IVisitFactory
    {
        public Visit Create(string symbol)
        {
            switch (symbol)
            {
                case "PS": return new PSVisit();
                case "NFZ": return new NFZVisit();
                case "Pakiet": return new PakietVisit();

                default: throw new NotSupportedException();

            }
        }
    }


    abstract class Visit 
    {
         public abstract decimal CalculateTotalAmount();
    }

    class NFZVisit : Visit
    {
        public override decimal CalculateTotalAmount()
        {
            return 0;
        }
    }

    class PakietVisit : Visit
    {
        public override decimal CalculateTotalAmount()
        {
            return 100;
        }
    }




    class PSVisit : Visit
    {
        public override decimal CalculateTotalAmount()
        {
            return 100;
        }
    }

}
