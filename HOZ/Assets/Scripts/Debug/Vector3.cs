using System;
using UnityEditor;
using UnityEngine;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class Vector3Inspector : IEcsComponentInspector {
        Type IEcsComponentInspector.GetFieldType () {
            return typeof (Vector3);
        }

        void IEcsComponentInspector.OnGUI (string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            Vector3GUI(label, (Vector3) value);
        }

        public static void Vector3GUI(string label, Vector3 value)
        {
            EditorGUILayout.Vector3Field (label, (Vector3) value);
        }
    }
}