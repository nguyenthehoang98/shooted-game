using System;
using HOR.BattleSystem.Character.Movement.Model;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed  class DashInspector: IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(DashModel);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        { 
            DashModel model = value as DashModel;
            CharacterDashGUI(model);
        }

        public static void CharacterDashGUI(DashModel model)
        {
            EditorGUILayout.LabelField ("-Character Dash", EditorStyles.linkLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.FloatField ("dash distance", model.DashDistance);
            EditorGUILayout.FloatField ("dash parameter", model.DashDuration);
            EditorGUILayout.FloatField ("dashing time", model.DashingTime);
            EditorGUILayout.EnumPopup("easing dash", (EasingFunctions.Functions)model.DashEasing);
            EditorGUILayout.LayerField("layer mask", model.LayerCollision);
            EditorGUI.indentLevel--;
        }
    }
}