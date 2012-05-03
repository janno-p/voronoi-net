using System;

namespace Voronoi.Net
{
    internal class BeachLine
    {
        private class BeachLineNode
        {
            private BeachLineNode LeftNode { get; set; }
            private BeachLineNode RightNode { get; set; }
            private VoronoiVertex SitePoint { get; set; }

            internal void AddSite(VoronoiVertex location)
            {
                if (LeftNode == null)
                {
                    LeftNode = new BeachLineNode { SitePoint = location };
                    return;
                }

                if (RightNode == null)
                {
                    RightNode = new BeachLineNode { SitePoint = location };
                    return;
                }

                var breakPoint = CalculateBreakingPoint(location);
                if (Math.Abs(breakPoint.X - location.X) < double.Epsilon)
                {
                    // Breakpoint in the middle
                }

                if (location.X < breakPoint.X)
                    LeftNode.AddSite(location);
                else
                    RightNode.AddSite(location);
            }

            private VoronoiVertex CalculateBreakingPoint(VoronoiVertex location)
            {
                if (LeftNode == null || RightNode == null)
                    return null;

                var p1 = LeftNode.SitePoint.X - location.X;
                var m1 = LeftNode.SitePoint.X + p1 / 2;
                var n1 = LeftNode.SitePoint.Y;

                var p2 = RightNode.SitePoint.X - location.X;
                var m2 = RightNode.SitePoint.X + p2 / 2;
                var n2 = RightNode.SitePoint.Y;

                var lhs = (p1 * n2 - p2 * n1) / (p1 - p2);
                var rhs = Math.Sqrt(p1 * p2 * ((n1 - n2) * (n1 - n2) + 2 * (p2 - p1) * (m1 - m2))) / (p1 - p2);

                var y1 = lhs + rhs;
                var y2 = lhs - rhs;

                var minY = Math.Min(n1, n2);
                var maxY = Math.Max(n1, n2);

                var y = (y1 >= minY && y1 <= maxY) ? y1 : ((y2 >= minY && y2 <= maxY) ? y2 : double.NaN);
                if (double.IsNaN(y))
                    return null;

                var x = m1 - (y - n1) * (y - n1) / 2 * p1;

                return new VoronoiVertex { X = x, Y = y };
            }
        }

        private readonly BeachLineNode rootNode = new BeachLineNode();

        internal void AddSite(VoronoiVertex location)
        {
            rootNode.AddSite(location);
        }
    }
}