using BestLoadingDisplayerEver;
using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new Loader();



            Console.WriteLine("Establishing the connection to DOTA 2 servers.");
            loader.Start();

            Thread.Sleep(2000);

            loader.Stop();

            Console.WriteLine();
            Console.WriteLine("Connection successfully established.");

            Thread.Sleep(200);

            Console.WriteLine("Hacking the servers.");
            loader.Start();

            Thread.Sleep(4000);

            loader.Stop();

            Console.WriteLine();
            Console.WriteLine("Pudge has been deleted from the game.");

            Console.ReadLine();
        }
    }
}
