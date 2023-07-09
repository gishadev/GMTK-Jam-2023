using DG.Tweening;
using UnityEngine;

namespace GMTK.Game.Interactable
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] private Transform door;
        
        public void OpenDoor()
        {
            door.DOLocalRotate(new Vector3(0, -90, 0), 0.5f);
        }
    }
}