using System;

namespace GMTK.Infrastructure
{
    public interface IGameManager
    {
        event Action Won, Lost;
        bool IsPlaying { get; }
        void Init();
        void Dispose();
    }
}