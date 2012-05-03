namespace Voronoi.Net
{
    internal interface IEvent
    {
        double Location { get; }

        void Handle();
    }
}