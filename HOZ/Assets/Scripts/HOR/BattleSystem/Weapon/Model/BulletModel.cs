using UnityEngine;

namespace HOR.BattleSystem.Weapon.Model
{
    public class BulletModel
    {
        [SerializeField] private float speed;
        [SerializeField] private float timeLife;
        [SerializeField] private float damage;
        [SerializeField] private float radiusDamage;
        [SerializeField] private float radiusColl;

        public BulletModel(float speed, float timeLife, float damage, float radius)
        {
            this.speed = speed;
            this.timeLife = timeLife;
            this.damage = damage;
            this.radiusDamage = radius;
        }

        public float MoveSpeed => speed;
        public float TimeLife => timeLife;
        public float Damage => damage;
        public float RadiusColl => radiusColl;
        public float RadiusDamage => radiusDamage;
    }
}