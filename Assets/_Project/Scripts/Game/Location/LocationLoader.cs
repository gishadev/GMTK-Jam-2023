using GMTK.Game.Core;
using GMTK.Game.Player;
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

        public Location CurrentSceneLocation => _currentSceneLocation;
        public Player.Player Player { get; private set; }
        public GameObject Camera { get; private set; }

        public void Init()
        {
            _gameManager.Won += OnWon;
            _gameManager.Lost += OnLost;
            SceneManager.sceneLoaded += OnSceneLoaded;
            PlayerAI.DoneMovingToFinish += OnDoneMovingToFinish;

            // Debug Location, because it should be no pre loaded location on the scene.
            var debugLocation = Object.FindObjectOfType<Location>();
            _currentSceneLocation = debugLocation;
            _currentLocationData = _gameDataSO.Locations[_locationIndex];
        }

        public void Dispose()
        {
            _gameManager.Won -= OnWon;
            _gameManager.Lost -= OnLost;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            PlayerAI.DoneMovingToFinish -= OnDoneMovingToFinish;
        }

        private void OnWon()
        {
        }

        private void OnLost()
        {
            LoadScene();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            // Load location.
            if (CurrentSceneLocation != null)
                Object.Destroy(CurrentSceneLocation.gameObject);
            _currentSceneLocation = _diContainer.InstantiatePrefab(_currentLocationData.LocationPrefab.gameObject,
                Vector3.zero,
                Quaternion.identity, null).GetComponent<Location>();

            // Load player.
            if (Player != null)
                Object.Destroy(Player.gameObject);
            Player = _diContainer.InstantiatePrefab(_gameDataSO.PlayerPrefab,
                _currentSceneLocation.EnterPoint.transform.position,
                Quaternion.identity, null).GetComponent<Player.Player>();

            // Load camera.
            if (Camera != null)
                Object.Destroy(Camera.gameObject);
            Camera = _diContainer.InstantiatePrefab(_gameDataSO.CameraPrefab,
                Vector3.zero,
                Quaternion.identity, null);

            Debug.Log("location loaded: " + _currentLocationData);
        }

        private void OnDoneMovingToFinish()
        {
            MoveToNextLocation();
            LoadScene();
        }

        public void LoadScene()
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