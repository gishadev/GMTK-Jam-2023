namespace GMTK.Game.Location
{
    public interface ILocationLoader
    {
        Location CurrentSceneLocation { get; }
        Player.Player Player { get; }
        void Init();
        void Dispose();

        void LoadScene();
        void MoveToNextLocation();
        void ResetIndex();
    }
}