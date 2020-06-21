using System;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class BoolInspectors : IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(bool);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            BoolGUI(label, (bool)value);
        }

        public static void BoolGUI(string lable, bool value)
        {
            EditorGUILayout.Toggle (lable, value);
        }
    }
}