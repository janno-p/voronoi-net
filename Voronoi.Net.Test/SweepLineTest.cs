using NUnit.Framework;

namespace Voronoi.Net.Test
{
    [TestFixture]
    public class SweepLineTest
    {
        [Test]
        public void WorksAsPriorityQueue()
        {
            var sweepLine = new SweepLine();

            sweepLine.AddSiteLocation(new VoronoiVertex { X = 10.7, Y = 18.0 });
            sweepLine.AddSiteLocation(new VoronoiVertex { X = 99.1, Y = 17.1 });
            sweepLine.AddSiteLocation(new VoronoiVertex { X = 10.7, Y = 19.9 });
            sweepLine.AddSiteLocation(new VoronoiVertex { X = 10.1, Y = 22.2 });

            Assert.IsTrue(sweepLine.CanMove);
            var event1 = sweepLine.MoveToNextLocation() as SiteEvent;
            Assert.IsNotNull(event1);
            Assert.AreEqual(event1.SitePoint.X, 10.1);
            Assert.AreEqual(event1.SitePoint.Y, 22.2);

            Assert.IsTrue(sweepLine.CanMove);
            var event2 = sweepLine.MoveToNextLocation() as SiteEvent;
            Assert.IsNotNull(event2);
            Assert.AreEqual(event2.SitePoint.X, 10.7);
            Assert.AreEqual(event2.SitePoint.Y, 18.0);

            Assert.IsTrue(sweepLine.CanMove);
            var event3 = sweepLine.MoveToNextLocation() as SiteEvent;
            Assert.IsNotNull(event3);
            Assert.AreEqual(event3.SitePoint.X, 10.7);
            Assert.AreEqual(event3.SitePoint.Y, 19.9);

            Assert.IsTrue(sweepLine.CanMove);
            var event4 = sweepLine.MoveToNextLocation() as SiteEvent;
            Assert.IsNotNull(event4);
            Assert.AreEqual(event4.SitePoint.X, 99.1);
            Assert.AreEqual(event4.SitePoint.Y, 17.1);

            Assert.IsFalse(sweepLine.CanMove);
        }
    }
}