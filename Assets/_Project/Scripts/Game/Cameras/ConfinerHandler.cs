using Cinemachine;
using GMTK.Game.Location;
using UnityEngine;

namespace GMTK.Cameras
{
    [RequireComponent(typeof(CinemachineConfiner))]
    public class ConfinerHandler : MonoBehaviour
    {
        private CinemachineConfiner _confiner;

        private void Awake()
        {
            _confiner = GetComponent<CinemachineConfiner>();
        }

        private void Start()
        {
            _confiner.m_BoundingVolume = FindObjectOfType<LocationBounds>().Collider;
        }
    }
}