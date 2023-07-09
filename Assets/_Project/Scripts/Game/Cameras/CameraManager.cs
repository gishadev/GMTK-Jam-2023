using System;
using GMTK.Game.Core;
using GMTK.Game.EnemyCore;
using GMTK.Game.Player;
using UnityEngine;
using Zenject;

namespace GMTK.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CameraFollowController followController;
        [SerializeField] private NavigationCameraController navigationController;

        [Inject] private ISeizeAbilityHandler _seizeAbilityHandler;

        private void OnEnable()
        {
            _seizeAbilityHandler.SeizedIn += OnSeizedIn;
            PlayerAI.StartedMovingToFinish += OnStartedMovingToFinish;

            _seizeAbilityHandler.SeizedOut += followController.Deactivate;
            _seizeAbilityHandler.SeizedOut += navigationController.Activate;
        }

        private void OnDisable()
        {
            _seizeAbilityHandler.SeizedIn -= OnSeizedIn;
            PlayerAI.StartedMovingToFinish -= OnStartedMovingToFinish;

            _seizeAbilityHandler.SeizedOut -= followController.Deactivate;
            _seizeAbilityHandler.SeizedOut -= navigationController.Activate;
        }

        private void OnStartedMovingToFinish(IFollowable followable)
        {
            followController.SwapCameraTo(followable);
        }

        private void OnSeizedIn(ISeizeable seizeable)
        {
            followController.SwapCameraTo((IFollowable) seizeable);
        }
    }
}