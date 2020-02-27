using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    class Printer
    {
        public void Print(string content)
        {
            Delegate[] delegates = Log?.GetInvocationList();

            // delegates[1] = null;

            // LogConsole($"Printing... {content}");
            // LogFile($"Printing... {content}");

            //if (Log!=null)
            //    Log($"Printing... {content}");
            
            Log?.Invoke($"Printing... {content}");

            // ..

            // LogConsole($"Printed.");
            Log?.Invoke($"Printed.");

            Finish?.Invoke(10);

            decimal? cost = CalculateCost?.Invoke(10);

            if (cost.HasValue)
                Display(cost.Value);

            Completed?.Invoke();

            Error?.Invoke(this, EventArgs.Empty);

            
        }

        public delegate void LogDelegate(string message);
        public LogDelegate Log { get; set; }

        // void Finished(byte copies)
        //public delegate void FinishDelegate(byte copies);
        //public FinishDelegate Finish { get; set; }

        public Action<byte> Finish { get; set; }


        // decimal CalculateCost(byte copies)
        //public delegate decimal CalculateCostDelegate(byte copies);
        //public CalculateCostDelegate CalculateCost { get; set; }

        public Func<byte, decimal> CalculateCost { get; set; }


        public delegate void CompletedDelegate();
        public event CompletedDelegate Completed;

        //public delegate void ErrorHandler(object sender, EventArgs e);
        //public event ErrorHandler Error;

        public event EventHandler<EventArgs> Error;

        private void Display(decimal cost)
        {
            Console.WriteLine($"Cost {cost}");
        }
       

    }
}
