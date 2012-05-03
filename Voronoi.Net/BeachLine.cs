namespace Voronoi.Net
{
    internal class BeachLine
    {
        private class BeachLineNode
        {
            internal BeachLineNode LeftNode { get; set; }
            internal BeachLineNode RightNode { get; set; }

            internal VoronoiVertex VertexA { get; set; }
            internal VoronoiVertex VertexB { get; set; }

            internal VoronoiVertex SitePoint { get; set; }
        }

        private readonly BeachLineNode rootNode = new BeachLineNode();

        internal void AddSite(VoronoiVertex location)
        {
            var existingArc = rootNode.LeftNode;

            if (rootNode.RightNode != null)
            {
                var breakingPoint = CalculateBreakingPoint();
            }

        }

        private double CalculateBreakingPoint()
        {
            return 0.0;
        }
    }
}