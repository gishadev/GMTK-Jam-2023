namespace GMTK.Game.Location
{
    public interface ILocationLoader
    {
        void Init();
        void Dispose();

        void LoadCurrentLocation();
        void MoveToNextLocation();
    }
}