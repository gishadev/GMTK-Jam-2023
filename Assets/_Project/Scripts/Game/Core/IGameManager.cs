namespace GMTK.Infrastructure
{
    public interface IGameManager
    {
        void Init();
        void Tick();
        void Dispose();
    }
}