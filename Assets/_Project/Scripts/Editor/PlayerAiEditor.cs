using GMTK.Game.Player;
using UnityEditor;
using UnityEngine;

namespace GMTK.Editor
{
    [CustomEditor(typeof(PlayerAi))]
    public class PlayerAiEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            PlayerAi playerAi = (PlayerAi) target;
            
            if (GUILayout.Button("Move to finish"))
            {
                playerAi.MoveToFinish();
            }
        }
    }
}