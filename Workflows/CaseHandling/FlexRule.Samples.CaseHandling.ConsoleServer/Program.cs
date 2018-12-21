using System;
using FlexRule.Samples.CaseHandling.Server;

namespace FlexRule.Samples.CaseHandling.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            CaseHandlingHost.StartHost();
            Console.WriteLine("Workflow host is running... Press <Enter> key to stop");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
