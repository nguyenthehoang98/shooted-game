using UnityEngine;
using System;

namespace HOR.BattleSystem.Skill.Model
{
    [Serializable]
    public class SkillModel
    {
        [SerializeField] private int id;
        [SerializeField] private float duration;
        [SerializeField] private float timeLife;
        [SerializeField] private string des;

        public SkillModel(int id, float duration, float timeLife, string des)
        {
            this.id = id;
            this.duration = duration;
            this.timeLife = timeLife;
            this.des = des;
        }

        public int Id => id;
        public float Duration => duration;
        public float TimeLife => timeLife;
        public string Description => des;
    }
}