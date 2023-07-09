using GMTK.Game.Location;
using UnityEngine;
using Zenject;

namespace GMTK.Game.UI
{
    public class ReturnToMenuBtn : MonoBehaviour
    {
        [Inject] private ILocationLoader _locationLoader;

        public void OnClick_ReturnToMenu()
        {
            Application.Quit();
        }
    }
}