using System;
using HOR.BattleSystem.Character.Movement.Model;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class CharacterRotateInspectors: IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(RotateModel);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            CharacterRotateGUI(value as RotateModel);
        }

        public static RotateModel CharacterRotateGUI(RotateModel model)
        {
            EditorGUILayout.LabelField ("-Character Rotate", EditorStyles.linkLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.FloatField ("speed", model.RotateSpeed);
            EditorGUI.indentLevel--;
            return model;
        }
    }
}