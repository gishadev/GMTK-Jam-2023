using UnityEngine;
using UnityEngine.SceneManagement;

namespace GMTK.Infrastructure
{
    public class GameEnterPoint : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("Game");
        }
    }
}