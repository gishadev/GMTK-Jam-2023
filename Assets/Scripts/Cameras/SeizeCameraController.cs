using UnityEngine;

namespace GMTK.Cameras
{
    public class SeizeCameraController : MonoBehaviour
    {
        [SerializeField] private float cameraSpeed = 20f;

        private float _horizontalInput;
        private float _verticalInput;
        
        private void Update()
        {
            Vector3 position = transform.position;

            _verticalInput = Input.GetAxisRaw("Vertical");
            _horizontalInput = Input.GetAxisRaw("Horizontal");

            position.z += _verticalInput * cameraSpeed * Time.deltaTime;
            position.x += _horizontalInput * cameraSpeed * Time.deltaTime;

            transform.position = position;
        }
    }
}