using KindleReader.Services;
using NUnit.Framework;

namespace KindleReader.Tests
{
    [TestFixture]
    public class ConnectedDeviceTest
    {
        ConnectedDevices connectedDevices;
        [SetUp]
        public void SetUpConnectedDevice()
        {
            connectedDevices = new ConnectedDevices();
            connectedDevices.connectedDevices.Add(new Model.Device() { DeviceID = "USB\\VID_1949&PID_0101" });
        }
        [Test]
        public void ConnectedDevice_CorrectlyGetKindle()
        {
            Assert.That(connectedDevices.HasConnectedKindle(), Is.EqualTo(true));
        }
    }
}