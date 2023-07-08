using Cinemachine;
using UnityEngine;

namespace GMTK
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook playerCamera;
        
        // todo temporary array
        [SerializeField] private Transform[] objectsToTrack;
        private int _i = 1;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwapCameraTo(objectsToTrack[_i % objectsToTrack.Length]);
                _i++;
            }
        }

        public void SwapCameraTo(Transform objectToTrack)
        {
            playerCamera.Follow = objectToTrack;
            playerCamera.LookAt = objectToTrack;
        }
    }
}
