using UnityEngine;

namespace HOR.BattleSystem.Character.Action.Component
{
    public struct LoadBulletComponent
    {
        // test.
        private int id;
        private Transform muzzle;
        private GameObject bullet; // Sau su dung ID lay tu Ressouces
        // private TypeFireBullet
        // private idBullet
        
        public void Setup(Transform muzzle, GameObject bullet)
        {
            this.muzzle = muzzle;
            this.bullet = bullet;
        }

        public void Execute()
        {
            bullet = Object.Instantiate(bullet);
            bullet.transform.position = muzzle.transform.position;
            bullet.transform.rotation = muzzle.transform.rotation;
        }

        public GameObject Bullet => bullet;
    }
}