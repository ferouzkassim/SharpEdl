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
        public string? FindSerialDevice()
        {
            var seril = SerialPort.GetPortNames();
            var Qload = seril.FirstOrDefault(e => e.Contains("Qload"));
            //snding device information\
            
            return Qload ?? null;
        }

        public UsbDevice? FindUsbDevice()
        {
            var UsbDevice = LibusbWrapper();
            if (UsbDevice != null)
            {
                
                return UsbDevice.Device;
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