using GMTK.Game.Player;
using UnityEditor;
using UnityEngine;

namespace GMTK.Editor
{
    [CustomEditor(typeof(PlayerAI))]
    public class PlayerAiEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            PlayerAI playerAi = (PlayerAI) target;
            
            if (GUILayout.Button("Move to finish"))
            {
                playerAi.MoveToFinish();
            }
        }
    }
}