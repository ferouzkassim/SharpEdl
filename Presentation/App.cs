using System;
using System.ComponentModel.DataAnnotations;
using LibUsbDotNet;
using sharpEdl;
namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your code starts here
           
            var sare = new Sahara();
            sare.ConnectDevice();
            Sahara.Handhshake();
            Sahara.ReadResponse();
            
        }
    }

}
