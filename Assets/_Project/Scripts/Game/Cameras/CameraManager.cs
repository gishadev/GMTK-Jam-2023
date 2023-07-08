using UnityEngine;

namespace GMTK.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private SeizeableObject[] seizeableObjects;
        [SerializeField] private CameraFollowController cameraFollowController;
        [SerializeField] private SeizeCameraController seizeCameraController;

        private void OnEnable()
        {
            foreach (SeizeableObject seizeableObject in seizeableObjects)
            {
                seizeableObject.OnSeizeableObjectSelected += cameraFollowController.SwapCameraTo;
                seizeableObject.OnSeizeableObjectSelected += seizeCameraController.DeactivateSeizeCamera;
            }
        }

        private void OnDisable()
        {
            foreach (SeizeableObject seizeableObject in seizeableObjects)
            {
                seizeableObject.OnSeizeableObjectSelected -= cameraFollowController.SwapCameraTo;
                seizeableObject.OnSeizeableObjectSelected -= seizeCameraController.DeactivateSeizeCamera;
            }
        }
    }
}