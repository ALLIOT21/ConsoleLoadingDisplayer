using BestLoadingDisplayerEver;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ld = new LoadingDisplayer("Installing DOTA 2...", 300);
            ld.Start();

            for (int i = 0; i < 10000000; i++)
            {

            }

            ld.Stop();
        }
    }
}
