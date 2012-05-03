using System.Collections.Generic;

namespace Voronoi.Net
{
    internal class SweepLine
    {
        private class LinkedEventNode
        {
            internal IEvent Value { get; private set; }
            internal LinkedEventNode NextNode { get; private set; }

            internal LinkedEventNode(IEvent value, LinkedEventNode previousNode = null)
            {
                Value = value;
                if (previousNode != null)
                    previousNode.NextNode = this;
            }
        }

        private readonly SortedList<double, LinkedEventNode> queue = new SortedList<double, LinkedEventNode>();

        internal bool CanMove { get { return queue.Count > 0; } }

        internal void AddSiteLocation(VoronoiVertex location)
        {
            EnqueueEvent(new SiteEvent(location));
        }

        internal void AddCircleCompletedLocation(VoronoiVertex location)
        {
            EnqueueEvent(new CircleEvent(location));
        }
        
        internal IEvent MoveToNextLocation()
        {
            var key = queue.Keys[0];
            var node = queue[key];

            if (node.NextNode != null)
                queue[key] = node.NextNode;
            else queue.Remove(key);

            return node.Value;
        }

        private void EnqueueEvent(IEvent e)
        {
            if (queue.ContainsKey(e.Location))
                new LinkedEventNode(e, queue[e.Location]);
            else
                queue.Add(e.Location, new LinkedEventNode(e));
        }
    }
}