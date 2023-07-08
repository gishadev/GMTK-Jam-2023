using Cinemachine;
using GMTK.Game.EnemyCore;
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

        public void DeactivateSeizeCamera(ISeizeable seizeable)
        {
            virtualCamera.Priority = 0;
            virtualCamera.gameObject.SetActive(false);

            transform.position = seizeable.transform.position;
        }

        public void ActivateSeizeCamera()
        {
            virtualCamera.Priority = 10;
            virtualCamera.gameObject.SetActive(true);
        }
    }
}