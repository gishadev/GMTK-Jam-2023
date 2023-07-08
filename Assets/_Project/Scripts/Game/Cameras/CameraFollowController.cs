using Cinemachine;
using UnityEngine;

namespace GMTK.Cameras
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        
        public void SwapCameraTo(Transform objectToTrack)
        {
            playerCamera.gameObject.SetActive(true);
            playerCamera.Priority = 10;
            
            playerCamera.Follow = objectToTrack;
            playerCamera.LookAt = objectToTrack;
        }

        public void DeactivateCamera()
        {
            playerCamera.gameObject.SetActive(false);
            playerCamera.Priority = 0;
        }
    }
}
