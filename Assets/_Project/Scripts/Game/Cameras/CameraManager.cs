using UnityEngine;

namespace GMTK.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CameraFollowController cameraFollowController;
        [SerializeField] private SeizeCameraController seizeCameraController;

        private void OnEnable()
        {
            SeizeableObject.OnSeizeableObjectSelected += cameraFollowController.SwapCameraTo;
            SeizeableObject.OnSeizeableObjectSelected += seizeCameraController.DeactivateSeizeCamera;
        }

        private void OnDisable()
        {
            SeizeableObject.OnSeizeableObjectSelected -= cameraFollowController.SwapCameraTo;
            SeizeableObject.OnSeizeableObjectSelected -= seizeCameraController.DeactivateSeizeCamera;
        }
    }
}