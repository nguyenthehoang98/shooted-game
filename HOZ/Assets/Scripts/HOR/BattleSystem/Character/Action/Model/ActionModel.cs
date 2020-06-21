using System;
using HOR.BattleSystem.Skill.Model;
using UnityEngine;

namespace HOR.BattleSystem.Character.Action.Model
{
    [Serializable]
    public class ActionModel
    {
        public bool Attack { get; set; }
        public bool ActiveSkill1 { get; set; }
        public bool ActiveSkill2 { get; set; }
        public bool ActiveSkill3 { get; set; }

        [SerializeField] private SkillModel idAttack;
        [SerializeField] private SkillModel idSkill1;
        [SerializeField] private SkillModel idSkill2;
        [SerializeField] private SkillModel idSkill3;

        public ActionModel(SkillModel id0, SkillModel id1, SkillModel id2, SkillModel id3)
        {
            this.idAttack = id0;
            this.idSkill1 = id1;
            this.idSkill2 = id2;
            this.idSkill3 = id3;
        }

        public SkillModel IdAttack => idAttack;
        public SkillModel IdSkill_1 => idSkill1;
        public SkillModel IdSkill_2 => idSkill2;
        public SkillModel IdSkill_3 => idSkill3;
    }
}