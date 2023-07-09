using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace GMTK.Game.TrapsCore
{
    public class SmashWallController : TrapController
    {
        [SerializeField] private Transform[] walls;
        [SerializeField] private Transform[] finalWallsPosition;
        
        [SerializeField] private TriggerTrapController damageTrigger;
        [SerializeField] private AudioSource[] sounds;

        private List<Vector3> _startWallsPosition = new();
        
        private void Start()
        {
            damageTrigger.gameObject.SetActive(false);

            foreach (Transform wall in walls)
            {
                _startWallsPosition.Add(wall.position);
            }
            
            StartCoroutine(MoveWallsRecursively());
        }

        private IEnumerator MoveWallsRecursively()
        {
            foreach (var audioSource in sounds)
            {
                audioSource.Stop();
            }
            
            if (canUse)
            {
                int i = 0;
                foreach (Transform wall in walls)
                {
                    wall.DOLocalMove(finalWallsPosition[i].position, cooldown);
                    i++;
                }

                yield return new WaitForSeconds(cooldown);

                canUse = false;
                
                sounds[Random.Range(0, sounds.Length)].Play();
                damageTrigger.gameObject.SetActive(true);
            }
            else
            {
                canUse = true;
                damageTrigger.gameObject.SetActive(false);
                
                int i = 0;
                foreach (Transform wall in walls)
                {
                    wall.DOLocalMove(_startWallsPosition[i], cooldown);
                    i++;
                }
                
                yield return new WaitForSeconds(cooldown);
            }

            yield return new WaitForSeconds(cooldown / 2);

            StartCoroutine(MoveWallsRecursively());
        }
    }
}