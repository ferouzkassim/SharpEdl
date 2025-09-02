using System;
using System.Configuration.Assemblies;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
namespace sharpEdl
{
    public class Connect
    {
   
        public static string? FindSerialDevice()
        {
            var seril = SerialPort.GetPortNames();
            var Qload = seril.FirstOrDefault(e => e.Contains("9008"));

            //snding device information\
            
            return Qload ?? null;
        }

        public UsbRegistry? FindUsbDevice()
        {
            var UsbDevice = LibusbWrapper();
            if (UsbDevice != null)
            {
             
               
                if(UsbDevice.Open(out var usbDevice))
                {
                    if (usbDevice.UsbRegistryInfo.Vid == 0x05C6 
                        && (usbDevice.UsbRegistryInfo.Pid == 0x9008 || usbDevice.UsbRegistryInfo.Pid == 0xA000 || usbDevice.UsbRegistryInfo.Pid == 0x9006))
                    {
                        return UsbDevice;
                    }
                    usbDevice.Close();
                }

                   return null;
            }
            return null;
        }

        private UsbRegistry? LibusbWrapper()
        {
          
            foreach (var tes in UsbDevice.AllDevices)
            {
                Console.WriteLine(tes);
            }
            var rs = new UsbDeviceFinder(vid: 0x05C6);
             
            return UsbDevice.AllDevices.FirstOrDefault(e => e.Vid == 0x05C6);
        }
    }
}