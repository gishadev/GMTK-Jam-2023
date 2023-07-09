﻿using System;
using GMTK.Cameras;
using GMTK.Game.Location;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace GMTK.Game.Player
{
    public class PlayerAI : MonoBehaviour, IFollowable
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float maxDistanceToFinishMoving = 0.2f;

        [Inject] private ILocationLoader _locationLoader;

        private bool _isMovingToFinish;
        public static event Action DoneMovingToFinish;
        public static event Action<IFollowable> StartedMovingToFinish;

        private void Update()
        {
            if (!_isMovingToFinish)
                return;

            if (_isMovingToFinish && agent.remainingDistance < maxDistanceToFinishMoving)
            {
                DoneMovingToFinish?.Invoke();
                _isMovingToFinish = false;
            }
        }


        public void MoveToFinish()
        {
            agent.SetDestination(_locationLoader.CurrentSceneLocation.ExitPoint.transform.position);
            _isMovingToFinish = true;

            StartedMovingToFinish?.Invoke(this);
        }
    }
}