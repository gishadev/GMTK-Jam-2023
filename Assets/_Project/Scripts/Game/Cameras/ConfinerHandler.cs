using Cinemachine;
using GMTK.Game.Location;
using UnityEngine;
using Zenject;

namespace GMTK.Cameras
{
    [RequireComponent(typeof(CinemachineConfiner))]
    public class ConfinerHandler : MonoBehaviour
    {
        private CinemachineConfiner _confiner;

        [Inject] private ILocationLoader _locationLoader;

        private void Awake()
        {
            _confiner = GetComponent<CinemachineConfiner>();
        }

        private void Start()
        {
            _confiner.m_BoundingVolume = _locationLoader.CurrentSceneLocation.LocationBounds.Collider;
        }
    }
}