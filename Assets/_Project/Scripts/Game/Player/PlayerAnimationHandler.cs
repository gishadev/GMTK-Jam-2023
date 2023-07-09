using GMTK.Game.Core;
using GMTK.Game.EnemyCore;
using UnityEngine;
using Zenject;

namespace GMTK.Game.Player
{
    [RequireComponent(typeof(PlayerAI))]
    public class PlayerAnimationHandler : MonoBehaviour
    {
        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;

        private PlayerAI _playerAI;
        private Animator _animator;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsCasting = Animator.StringToHash("IsCasting");

        private void Awake()
        {
            _playerAI = GetComponent<PlayerAI>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable()
        {
            _seizeAbilityHandler.SeizedIn += OnSeizedIn;
            _seizeAbilityHandler.SeizedOut += OnSeizedOut;
        }

        private void OnDisable()
        {
            _seizeAbilityHandler.SeizedIn -= OnSeizedIn;
            _seizeAbilityHandler.SeizedOut -= OnSeizedOut;
        }

        private void Update()
        {
            _animator.SetBool(IsWalking, _playerAI.IsMovingToFinish);
        }

        private void OnSeizedIn(ISeizeable obj)
        {
            _animator.SetBool(IsCasting, true);
        }

        private void OnSeizedOut()
        {
            _animator.SetBool(IsCasting, false);
        }
    }
}