using System;
using HOR.BattleSystem.Character.Movement;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class MovementInspectors : IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(CharacterMovementHandle);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            CharacterMovementGUI(value as CharacterMovementHandle);
        }

        public static void CharacterMovementGUI(CharacterMovementHandle handle)
        {
            EditorGUILayout.LabelField("-MovementModel", EditorStyles.linkLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.Toggle("dash", handle.IsDash);
            EditorGUI.indentLevel--;

            EditorGUI.indentLevel++;
            BoolInspectors.BoolGUI("run", handle.IsRun);
            BoolInspectors.BoolGUI("lock facing", handle.IsLockFacing);
            EditorGUI.indentLevel--;
            
            EditorGUI.indentLevel++;
            EditorGUI.indentLevel--;
            
            Vector3Inspector.Vector3GUI("dir facing", handle.Facing);
            Vector3Inspector.Vector3GUI("dir move", handle.Direction);

        }
    }
}