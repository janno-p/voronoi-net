namespace Voronoi.Net
{
    internal class SiteEvent : IEvent
    {
        private readonly VoronoiVertex sitePoint;

        internal VoronoiVertex SitePoint { get { return sitePoint; } }
        
        internal SiteEvent(VoronoiVertex sitePoint)
        {
            this.sitePoint = sitePoint;
        }

        double IEvent.Location { get { return sitePoint.X; } }
        
        void IEvent.Handle()
        {
            // 1. Locate the existing arc (if any) that is above the new site

            // 2. Break the arc by replacing the leaf node with a sub tree representing the new arc and its break points
            
            // 3. Add two half-edge records in the doubly linked list
            
            // 4. Check for potential circle event(s), add them to event queue if they exist
        }
    }
}