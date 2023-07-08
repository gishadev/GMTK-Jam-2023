using Cinemachine;
using UnityEngine;

namespace GMTK.Cameras
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera playerCamera;
        
        public void SwapCameraTo(SeizeableObject objectToTrack)
        {
            playerCamera.gameObject.SetActive(true);
            playerCamera.Priority = 10;

            var objectToTrackTransform = objectToTrack.transform;
            
            playerCamera.Follow = objectToTrackTransform;
            playerCamera.LookAt = objectToTrackTransform;
        }

        public void DeactivateCamera()
        {
            playerCamera.gameObject.SetActive(false);
            playerCamera.Priority = 0;
        }
    }
}
