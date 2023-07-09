using GMTK.Game.EnemyCore;
using UnityEditor;
using UnityEngine;

namespace GMTK.Editor
{
    [CustomEditor(typeof(EnemyHealth))]
    public class EnemyHealthEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EnemyHealth enemyHealth = (EnemyHealth) target;

            if (GUILayout.Button("Kill"))
            {
                enemyHealth.TakeDamage(enemyHealth.MortaldamageType);
            }
        }
    }
}