using System;

namespace bankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Sterling Bank NG!");
            Console.WriteLine("**************************************************************************");

            try
            {
                var b = new Bank();
                    b.StartApp();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hey! You just pressed the wrong key!");
                Console.WriteLine("--------------------------------------------------------------------------\n\n");
            }
        }
    }
}