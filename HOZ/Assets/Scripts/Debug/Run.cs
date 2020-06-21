using System;
using HOR.BattleSystem.Character.Movement.Model;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class RunInspector : IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(RunModel);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            CharacterRunGUI(value as RunModel);
        }

        public static RunModel CharacterRunGUI(RunModel model)
        {
            EditorGUILayout.LabelField ("-Character Run", EditorStyles.linkLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.FloatField ("speed", model.RunSpeed);
            EditorGUI.indentLevel--;
            return model;
        }
    }
}