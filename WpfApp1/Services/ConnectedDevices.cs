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
        //nope, it can`t be singleton
        private static readonly object Lock = new object();
        private static ConnectedDevices instanse;
        public static ConnectedDevices Instanse
        {
            get
            {
                lock(Lock)
                {
                    if(instanse == null)
                    {
                        instanse = new ConnectedDevices();
                        return instanse;
                    }
                    else
                    {
                        return instanse;
                    }
                }

            }
        }
        ConnectedDevices()
        {

        }
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
