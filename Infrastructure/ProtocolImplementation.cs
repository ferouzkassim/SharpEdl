namespace sharpEdl
{
    public class Sahara : Connect
    {
        public void ConnectDevice(int portNumber)
        {

            
            FindSerialDevice();
            FindUsbDevice();
        
        }
    }
}
