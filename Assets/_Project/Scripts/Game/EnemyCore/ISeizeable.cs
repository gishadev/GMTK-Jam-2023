namespace GMTK.Game.EnemyCore
{
    public interface ISeizeable
    {
        bool IsSeized { get; }
        void SeizeIn();
        void SeizeOut();
    }
}