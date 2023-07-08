using UnityEngine;
using Zenject;

namespace GMTK.Infrastructure
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}