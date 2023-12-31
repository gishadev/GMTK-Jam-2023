﻿using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(Enemy), typeof(CharacterController))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float gravitySpeed = -10f;

        private Vector2 _input, _rawInput;
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
            GetInputs();
            HandleMovement();
            HandleRotation();
        }

        private void GetInputs()
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _rawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        private void HandleRotation()
        {
            if (_rawInput.magnitude == 0)
                return;

            var lookDir = new Vector3(_input.x, 0f, _input.y);
            transform.rotation = Quaternion.LookRotation(lookDir);
        }

        private void HandleMovement()
        {
            var moveDir = new Vector3(_input.x, 0f, _input.y);
            _characterController.Move(moveDir * (moveSpeed * Time.deltaTime));
        }

        private void HandleGravity()
        {
            var gravity = _characterController.isGrounded ? 0f : gravitySpeed;
            _characterController.Move(Vector3.up * (gravity * Time.deltaTime));
        }
    }
}