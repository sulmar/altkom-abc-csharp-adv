using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BehavioralPatterns
{
    class CommandTests

    {
        public static void Test()
        {
            ICommand command = new PrintCommand("Hello", 1);

            if (command.CanExecute)
                command.Execute();
        }
    }


    class Printer
    {
        private bool isPowerOn = false;
        private bool printing = false;
        public void PowerOn() => isPowerOn = true;
        public void PowerOff() => isPowerOn = false;
        public void Print(string content, byte copies = 1)
        {
            printing = true;

            for (int i = 0; i < copies; i++)
            {
                if (printing)
                    Console.WriteLine($"#{i} {content}");
            }

            printing = false;
        }
        public bool CanPrint() => isPowerOn;
        public void Cancel() => printing = false;
        public bool CanCancel() => printing;
    }


    interface ICommand
    {
        void Execute();
        bool CanExecute { get; }
    }

    class PrintCommand : ICommand
    {
        private readonly byte copies;
        private readonly string content;

        public PrintCommand(string content, byte copies)
        {
            this.content = content;
            this.copies = copies;
        }

        public void Execute()
        {
            for (int i = 0; i < copies; i++)
            {
                Console.WriteLine($"#{i} {content}");
            }
        }
        public bool CanExecute => !string.IsNullOrEmpty(content) && copies > 0;
    }
}
