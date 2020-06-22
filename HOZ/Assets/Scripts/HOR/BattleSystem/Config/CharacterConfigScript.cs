using System;
using HOR.BattleSystem.Character.Action.Model;
using HOR.BattleSystem.Character.Movement.Model;
using UnityEngine;

namespace HOR.BattleSystem.Config
{
    [CreateAssetMenu(menuName = "ScriptObject/CharacterConfig", order = 1, fileName = "CharacterConfig")]
    public class CharacterConfigScript : ScriptableObject
    {
        public string pathModel;
        public RunModel run;
        public RotateModel rotate;
        public DashModel dash;
        public ActionModel action;
    }
}