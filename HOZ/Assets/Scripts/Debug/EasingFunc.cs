using System;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class EasingFuncInspectors : IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(EasingFunctions.Functions);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            EasingGUI((EasingFunctions.Functions) value);
        }

        public static void EasingGUI(EasingFunctions.Functions functions)
        {
            EditorGUILayout.LabelField ("-Easing", EditorStyles.linkLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.EnumPopup ("functions", functions);
            EditorGUI.indentLevel--;
        }
    }
}