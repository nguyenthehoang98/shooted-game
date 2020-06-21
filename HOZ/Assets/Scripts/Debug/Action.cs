using System;
using HOR.BattleSystem.Character.Action.Model;
using UnityEditor;

namespace Leopotam.Ecs.UnityIntegration.Editor.Inspectors
{
    sealed class ActionInspectors : IEcsComponentInspector
    {
        public Type GetFieldType()
        {
            return typeof(ActionModel);
        }

        public void OnGUI(string label, object value, EcsWorld world, ref EcsEntity entityId)
        {
            CharacterActionGUI(value as ActionModel);
        }

        public static ActionModel CharacterActionGUI(ActionModel model)
        {
            EditorGUILayout.LabelField ("-Character Action", EditorStyles.linkLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.Toggle ("attack", model.Attack);
            SkillModelInspectors.SkillModelGUI(model.IdAttack);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space(5);
            EditorGUI.indentLevel++;
            EditorGUILayout.Toggle ("skill_1", model.ActiveSkill1);
            SkillModelInspectors.SkillModelGUI(model.IdSkill_1);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space(5);
            EditorGUI.indentLevel++;
            EditorGUILayout.Toggle ("skill_2", model.ActiveSkill2);
            SkillModelInspectors.SkillModelGUI(model.IdSkill_2);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space(5);
            EditorGUI.indentLevel++;
            EditorGUILayout.Toggle ("skill_3", model.ActiveSkill3);
            SkillModelInspectors.SkillModelGUI(model.IdSkill_3);
            EditorGUI.indentLevel--;
            return model;
        }
    }
}