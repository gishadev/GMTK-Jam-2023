using DG.Tweening;
using UnityEngine;

namespace GMTK.Game.Interactable
{
    public class LeverController : MonoBehaviour, IInteractable
    {
        [SerializeField] private DoorController connectedDoor;
        [SerializeField] private Transform lever;
        
        private void OnTriggerEnter(Collider other)
        {
            Interact();
        }

        public void Interact()
        {
            connectedDoor.OpenDoor();
            lever.DOLocalRotate(new Vector3(-50, 0, 0), 0.5f);
        }
    }
}