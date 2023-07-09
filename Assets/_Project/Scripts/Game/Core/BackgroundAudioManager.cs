using UnityEngine;

namespace GMTK._Project.Scripts.Game.Core
{
    public class BackgroundAudioManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}