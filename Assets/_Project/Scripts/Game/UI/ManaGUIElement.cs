using GMTK.Game.Core;
using GMTK.Infrastructure;
using TMPro;
using UnityEngine;
using Zenject;

namespace GMTK.Game.UI
{
    public class ManaGUIElement : MonoBehaviour
    {
        [SerializeField] private RectTransform manaBar;
        [SerializeField] private TMP_Text manaPercentageTMP;

        [Inject] private IManaTimer _manaTimer;
        [Inject] private IGameManager _gameManager;

        private void Update()
        {
            if (!_gameManager.IsPlaying)
                return;

            manaBar.localScale = new Vector3(_manaTimer.ManaPercentage, 1f, 1f);
            manaPercentageTMP.text = $"{Mathf.RoundToInt(_manaTimer.ManaPercentage * 100f)}%";
        }
    }
}