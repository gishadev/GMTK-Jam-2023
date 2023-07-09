using Cinemachine;
using UnityEngine;

namespace GMTK.Cameras
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        
        public void SwapCameraTo(IFollowable followable)
        {
            playerCamera.gameObject.SetActive(true);
            playerCamera.Priority = 10;

            var objectToTrackTransform = followable.transform;
            
            playerCamera.Follow = objectToTrackTransform;
            playerCamera.LookAt = objectToTrackTransform;
        }

        public void Deactivate()
        {
            playerCamera.gameObject.SetActive(false);
            playerCamera.Priority = 0;
        }
    }
}
