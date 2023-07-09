using GMTK.Game.TrapsCore;

namespace GMTK.Game.EnemyCore
{
    public interface IDamageable
    {
        float MaxHp { get; }
        void TakeDamage(DamageType damage);
    }
}