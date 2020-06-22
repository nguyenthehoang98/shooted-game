using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HOR.BattleSystem.Weapon.Model
{
    [Serializable]
    public class BulletModel
    {
        [SerializeField] private int id;
        [SerializeField] private string path;
        [SerializeField] private float speed;
        [SerializeField] private float timeLife;
        [SerializeField] private float damage;
        [SerializeField] private float radiusDamage;
        [SerializeField] private float radiusColl;
        private GameObject bullet;

        public BulletModel()
        {
        }
        
        public BulletModel(int id, string path, float speed, float timeLife, float damage, float radiusDamage, float radiusColl)
        {
            this.id = id;
            this.path = path;
            this.bullet = Object.Instantiate(Resources.Load(path) as GameObject);
            this.speed = speed;
            this.timeLife = timeLife;
            this.damage = damage;
            this.radiusDamage = radiusDamage;
            this.radiusColl = radiusColl;
        }

        public int Id => id;
        public string Path => path;
        public GameObject Bullet => bullet;
        public float MoveSpeed => speed;
        public float TimeLife => timeLife;
        public float Damage => damage;
        public float RadiusColl => radiusColl;
        public float RadiusDamage => radiusDamage;
    }
}