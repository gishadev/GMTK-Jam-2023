using GMTK.Game.Core;
using UnityEngine;
using Zenject;

namespace GMTK.Infrastructure
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        [SerializeField] private GameDataSO gameDataSO;

        public override void InstallBindings()
        {
            Container.BindInstances(gameDataSO);
        }
    }
}