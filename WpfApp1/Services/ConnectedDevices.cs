using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using KindleReader.Model;

namespace KindleReader.Services
{
    public class ConnectedDevices
    {
        //To be or not to be.. a singleton(?) I need only one instance for this class in my whole program,
        //but I use it only once in whole program and creating another one won`t have any influence on this program

        public int NumberofKindles { get; private set; }
        private List<Device> GetConnectedKindle()
        {
            List<Device> connectedDevices = new List<Device>();
            ManagementObjectCollection deviceCollection;
            //VID(VendorID) is included in DeviceID. It`ll be the same for all Kindle products
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_UsbHub WHERE DeviceID LIKE 'VID%" + 1949 + "%'"))
            {
                deviceCollection = searcher.Get();
            }
            foreach (var device in deviceCollection)
            {
                connectedDevices.Add(new Device() { DeviceID = (string)device.GetPropertyValue("DeviceID"), PNPDeviceID = (string)device.GetPropertyValue("PNPDeviceID") });
            }
            NumberofKindles = connectedDevices.Capacity;
            return connectedDevices;
        }

        public bool HasConnectedKindle()
        {
            var connectedKindle = GetConnectedKindle();
            bool hasConnectedKindle = false;
            if (connectedKindle.Any())
            {
                hasConnectedKindle = true;
            }
            return hasConnectedKindle;
        }
    }
}
