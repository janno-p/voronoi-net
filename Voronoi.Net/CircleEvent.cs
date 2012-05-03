namespace Voronoi.Net
{
    internal class CircleEvent : IEvent
    {
        private readonly VoronoiVertex tangentPoint;

        internal CircleEvent(VoronoiVertex tangentPoint)
        {
            this.tangentPoint = tangentPoint;
        }

        double IEvent.Location { get { return tangentPoint.X; } }

        void IEvent.Handle()
        {
            
        }
    }
}