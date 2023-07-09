using UnityEngine;

namespace GMTK.Game.TrapsCore
{
    public abstract class TrapController : MonoBehaviour
    {
        [SerializeField] protected DamageType damageType;
        
        [SerializeField] protected float cooldown;
        
        protected bool canUse = true;
    }
}