using UnityEngine;

namespace GMTK.Game.EnemyCore
{
    [RequireComponent(typeof(CharacterController))]
    public class EnemyAnimationHandler : MonoBehaviour
    {
        private CharacterController _characterController;
        private Animator _animator;

        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _animator.SetBool(IsWalking, _characterController.velocity.magnitude > 0.05f);
        }
    }
}