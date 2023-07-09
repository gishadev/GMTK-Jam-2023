using GMTK.Game.Core;
using GMTK.Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GMTK.Game.Location
{
    public class LocationLoader : ILocationLoader
    {
        [Inject] private IGameManager _gameManager;
        [Inject] private GameDataSO _gameDataSO;
        [Inject] private DiContainer _diContainer;

        private LocationDataSO _currentLocationData;
        private Location _currentSceneLocation;
        private int _locationIndex;

        public void Init()
        {
            _gameManager.Won += OnWon;
            _gameManager.Lost += OnLost;
            SceneManager.sceneLoaded += OnSceneLoaded;

            _currentLocationData = _gameDataSO.Locations[_locationIndex];
        }

        public void Dispose()
        {
            _gameManager.Won -= OnWon;
            _gameManager.Lost -= OnLost;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnLost()
        {
            LoadCurrentLocation();
            MoveToNextLocation();
        }

        private void OnWon()
        {
            LoadCurrentLocation();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (_currentSceneLocation != null)
                Object.Destroy(_currentSceneLocation.gameObject);

            _currentSceneLocation = _diContainer.InstantiatePrefab(_currentLocationData.LocationPrefab.gameObject,
                Vector3.zero,
                Quaternion.identity, null).GetComponent<Location>();
            Debug.Log("location loaded: " + _currentLocationData);
        }

        public void LoadCurrentLocation()
        {
            SceneManager.LoadScene(Constants.SCENE_GAME_NAME);
        }

        public void MoveToNextLocation()
        {
            _locationIndex++;
            if (_locationIndex <= _gameDataSO.Locations.Length - 1)
            {
                _currentLocationData = _gameDataSO.Locations[_locationIndex];
                return;
            }

            _locationIndex = 0;
        }
    }
}