using NUnit.Framework;
using System;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Bla()
        {
            Assert.That(true, Is.EqualTo(true));
        }
    }
}
