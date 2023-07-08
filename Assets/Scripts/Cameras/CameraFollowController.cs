using Cinemachine;
using UnityEngine;

namespace GMTK.Cameras
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook playerCamera;
        
        public void SwapCameraTo(Transform objectToTrack)
        {
            playerCamera.gameObject.SetActive(true);
            playerCamera.Priority = 10;
            
            playerCamera.Follow = objectToTrack;
            playerCamera.LookAt = objectToTrack;
        }
    }
}
