using System;
using HOR.BattleSystem.Skill.Model;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class SkillModelInspectors : IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(SkillModel);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            
        }

        public static SkillModel SkillModelGUI(SkillModel model)
        {
            EditorGUILayout.LabelField ("-Skill", EditorStyles.linkLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.IntField ("id", model.Id);
            EditorGUILayout.FloatField ("duration", model.Duration);
            EditorGUILayout.FloatField ("time life", model.TimeLife);
            EditorGUILayout.TextField ("description", model.Description);
            EditorGUI.indentLevel--;
            return model;
        }
    }
}