using System.Collections.Generic;

namespace Voronoi.Net
{
    public class VoronoiDiagram
    {
        private readonly SweepLine sweepLine = new SweepLine();

        public VoronoiDiagram(IEnumerable<VoronoiVertex> sitePoints)
        {
            foreach (var sitePoint in sitePoints)
                sweepLine.AddSiteLocation(sitePoint);

            BuildDiagram();
        }

        private void BuildDiagram()
        {
            while (sweepLine.CanMove)
                sweepLine.MoveToNextLocation().Handle();
        }
    }
}