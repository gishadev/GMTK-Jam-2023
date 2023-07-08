using GMTK.Game.EventsSO;
using UnityEngine;

namespace GMTK.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private EventSO onEnemyDeactivated; 
        
        [SerializeField] private CameraFollowController cameraFollowController;
        [SerializeField] private SeizeCameraController seizeCameraController;

        private void OnEnable()
        {
            SeizeableObject.OnSeizeableObjectSelected += cameraFollowController.SwapCameraTo;
            SeizeableObject.OnSeizeableObjectSelected += seizeCameraController.DeactivateSeizeCamera;

            onEnemyDeactivated.OnInvoked += cameraFollowController.DeactivateCamera;
            onEnemyDeactivated.OnInvoked += seizeCameraController.ActivateSeizeCamera;
        }

        private void OnDisable()
        {
            SeizeableObject.OnSeizeableObjectSelected -= cameraFollowController.SwapCameraTo;
            SeizeableObject.OnSeizeableObjectSelected -= seizeCameraController.DeactivateSeizeCamera;
            
            onEnemyDeactivated.OnInvoked -= cameraFollowController.DeactivateCamera;
            onEnemyDeactivated.OnInvoked -= seizeCameraController.ActivateSeizeCamera;
        }
    }
}