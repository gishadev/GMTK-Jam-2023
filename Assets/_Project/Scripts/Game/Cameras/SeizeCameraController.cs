using Cinemachine;
using GMTK.Game.EnemyCore;
using UnityEngine;

namespace GMTK.Cameras
{
    public class SeizeCameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineConfiner confiner;
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

            position.x += _horizontalInput * cameraSpeed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, confiner.m_BoundingVolume.bounds.min.x,
                confiner.m_BoundingVolume.bounds.max.x);

            position.z += _verticalInput * cameraSpeed * Time.deltaTime;
            position.z = Mathf.Clamp(position.z, confiner.m_BoundingVolume.bounds.min.z,
                confiner.m_BoundingVolume.bounds.max.z);

            transform.position = position;
        }

        public void DeactivateSeizeCamera(ISeizeable seizeable)
        {
            confiner.VirtualCamera.Priority = 0;
            confiner.VirtualCamera.gameObject.SetActive(false);

            transform.position = seizeable.transform.position;
        }

        public void ActivateSeizeCamera()
        {
            confiner.VirtualCamera.Priority = 10;
            confiner.VirtualCamera.gameObject.SetActive(true);
        }
    }
}