using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindleReader.Model
{
    public class Device
    {
        public string DeviceID { get; set; } //Unique name: contains VID,PID and uniqueId in system

        public string PNPDeviceID { get; set; } // how its indicates in System

    }
}
