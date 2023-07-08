namespace GMTK.Infrastructure
{
    public interface IGameManager
    {
        bool IsPlaying { get; }
        void Init();
        void Dispose();
    }
}