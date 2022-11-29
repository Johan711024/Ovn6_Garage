namespace Ovn6_Garage
{
    public interface IHandler
    {
        int AvailableLots { get; }
        int MaximumSpots { get; }

        void searchNoPlate();
    }
}