using LibUsbDotNet;
using System;
using System.Text;

namespace sharpEdl
{
    public class Sahara : Connect
    {
       
        private static UsbDevice MyQualcomDevice= default!;
        public UsbDevice ConnectDevice()
        {


            FindSerialDevice();
           var Device =  FindUsbDevice();
           if(Device is not null)
            {
                Console.WriteLine(Device.FullName);
                Console.WriteLine(Device.Device);
                MyQualcomDevice = Device.Device;
                return MyQualcomDevice;
            }
           
            return default!;
        }
        public static void Handhshake()
        {
            if (MyQualcomDevice is not IUsbDevice usbDevice)
            {
                throw new Exception("Device is not a USB device.");
            }
            usbDevice.SetConfiguration(1);
            usbDevice.ClaimInterface(0);

            UsbEndpointWriter usbEndpointWriter =  usbDevice.OpenEndpointWriter(LibUsbDotNet.Main.WriteEndpointID.Ep01);
            var res =  BitConverter.GetBytes((int)Command.SAHARA_HELLO_REQ);
            usbEndpointWriter.Write(res, 0, out var transferLength);
            Console.WriteLine($"Sent {transferLength} bytes.");
        }
        public static void ReadResponse()
        {
            if (MyQualcomDevice is not IUsbDevice usbDevice)
            {
                throw new Exception("Device is not a USB device.");
            }
            UsbEndpointReader usbEndpointReader = usbDevice.OpenEndpointReader(LibUsbDotNet.Main.ReadEndpointID.Ep01);
            byte[] readBuffer = new byte[1024];
            
            usbEndpointReader.Read(readBuffer, 5000, out var transferLength);
            var uints = Enumerable.Range(0, readBuffer.Length / 4)
                          .Select(i => BitConverter.ToUInt32(readBuffer, i * 4))
                          .ToArray();

                                foreach (var value in uints)
                                {
                                        if (Enum.IsDefined(typeof(Command), value))
                                        {
                                            Command cmd = (Command)value;
                                            Console.WriteLine($"Command: {cmd}");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Raw UInt: {value} (0x{value:X})");
                                        }

                                 }

            //Console.WriteLine($"Received {transferLength} bytes.");
            //Console.WriteLine(BitConverter.ToString(readBuffer, 0, transferLength));
            //Console.WriteLine(BitConverter.ToDouble(readBuffer, 0));
            //Console.WriteLine(BitConverter.IsLittleEndian);
            //Console.WriteLine(BitConverter.DoubleToUInt64Bits(BitConverter.ToDouble(readBuffer, 0)));

        }
        public void DisconnectDevice()
        {
        }   
    }
}
    