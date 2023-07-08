using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(Enemy), typeof(CharacterController))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float gravitySpeed = -10f;

        private Enemy _enemy;
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _enemy = GetComponent<Enemy>();
        }

        private void Update()
        {
            HandleGravity();

            if (!_enemy.IsSeized)
                return;
            var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            HandleMovement(input);
        }

        private void HandleMovement(Vector2 input)
        {
            var moveDir = new Vector3(input.x, 0f, input.y);
            _characterController.Move(moveDir * (moveSpeed * Time.deltaTime));
        }

        private void HandleGravity()
        {
            var gravity = _characterController.isGrounded ? 0f : gravitySpeed;
            _characterController.Move(Vector3.up * (gravity * Time.deltaTime));
        }
    }
}