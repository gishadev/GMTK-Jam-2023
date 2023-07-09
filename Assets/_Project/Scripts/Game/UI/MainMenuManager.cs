using UnityEngine;
using UnityEngine.SceneManagement;

namespace GMTK.Game.UI
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private string gameScene;

        [SerializeField] private Animation startTextBlink;

        private void Start()
        {
            startTextBlink.Play();
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(gameScene);
            }
        }
    }
}