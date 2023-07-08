using Cinemachine;
using UnityEngine;

namespace GMTK.Cameras
{
    public class SeizeCameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private float cameraSpeed = 20f;

        private float _horizontalInput;
        private float _verticalInput;
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 position = transform.position;

            _verticalInput = Input.GetAxisRaw("Vertical");
            _horizontalInput = Input.GetAxisRaw("Horizontal");

            position.z += _verticalInput * cameraSpeed * Time.deltaTime;
            position.x += _horizontalInput * cameraSpeed * Time.deltaTime;

            transform.position = position;
        }

        public void DeactivateSeizeCamera(Transform seizableObject)
        {
            virtualCamera.Priority = 0;
            virtualCamera.gameObject.SetActive(false);

            transform.position = seizableObject.position;
        }

        public void ActivateSeizeCamera()
        {
            virtualCamera.Priority = 10;
            virtualCamera.gameObject.SetActive(true);
        }
    }
}