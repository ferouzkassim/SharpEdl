using System;
using sharpEdl;
namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your code starts here
            var sare = new Sahara();
            sare.ConnectDevice(2);

            Console.WriteLine("Hello, World!");
        }
    }

}
