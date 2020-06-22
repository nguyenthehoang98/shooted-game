using HOR.BattleSystem.Weapon.Model;
using UnityEngine;

namespace HOR.BattleSystem.Character.Action.Component
{
    public struct LoadBulletComponent
    {
        // test.
        private int id;
        private Transform muzzle;
        private BulletModel bullet; // Sau su dung ID lay tu Ressouces
        // private TypeFireBullet
        // private idBullet
        
        public void Setup(Transform muzzle, BulletModel bullet)
        {
            this.muzzle = muzzle;
            this.bullet = bullet;
        }

        public void Update()
        {
            bullet.Bullet.transform.position = muzzle.transform.position;
            bullet.Bullet.transform.rotation = muzzle.transform.rotation;
        }

        public BulletModel BulletModel => bullet;
    }
}