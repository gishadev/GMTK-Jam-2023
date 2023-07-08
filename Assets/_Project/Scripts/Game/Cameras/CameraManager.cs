using GMTK.Game.Core;
using GMTK.Game.EventsSO;
using UnityEngine;
using Zenject;

namespace GMTK.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private EventSO onEnemyDeactivated;

        [SerializeField] private CameraFollowController cameraFollowController;
        [SerializeField] private SeizeCameraController seizeCameraController;

        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;

        private void OnEnable()
        {
            _seizeAbilityHandler.SeizedIn += cameraFollowController.SwapCameraTo;
            _seizeAbilityHandler.SeizedOut += seizeCameraController.DeactivateSeizeCamera;

            onEnemyDeactivated.OnInvoked += cameraFollowController.DeactivateCamera;
            onEnemyDeactivated.OnInvoked += seizeCameraController.ActivateSeizeCamera;
        }

        private void OnDisable()
        {
            _seizeAbilityHandler.SeizedIn -= cameraFollowController.SwapCameraTo;
            _seizeAbilityHandler.SeizedOut -= seizeCameraController.DeactivateSeizeCamera;

            onEnemyDeactivated.OnInvoked -= cameraFollowController.DeactivateCamera;
            onEnemyDeactivated.OnInvoked -= seizeCameraController.ActivateSeizeCamera;
        }
    }
}