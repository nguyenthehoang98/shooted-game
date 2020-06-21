using HOR.BattleSystem.Weapon.Model;
using UnityEngine;

namespace HOR.BattleSystem.Weapon.Component
{
    public struct BulletMovementComponent
    {
        public Transform root;
        public BulletModel bulletModel;
        private float time;
        private bool isLive;
        
        public void Setup(Transform bullet, BulletModel bulletModel)
        {
            this.root = bullet;
            this.bulletModel = bulletModel;
        }

        public void Fire()
        {
            isLive = true;
            root.gameObject.SetActive(true);
            time = Time.time + bulletModel.TimeLife;
        }

        public void Update()
        {
            if (isLive)
            {
                var transform = root.transform;
                transform.position += bulletModel.MoveSpeed * Time.deltaTime * transform.forward;

                if (Expired() || Physics.Raycast(root.transform.position, root.transform.forward,
                        bulletModel.RadiusColl))
                {
                    Exit();
                }
            }
        }

        public bool IsDestroy()
        {
            return !isLive;
        }
        
        void Exit()
        {
            // explosion == colider những thằng nào trong bán kinh nổ thì -> nổ
            
            isLive = false;
            Collider[] colls = Physics.OverlapSphere(root.transform.position, bulletModel.RadiusDamage);
            // nếu là vật nhận sát thương-> gây dame theo bán kinh, vật ko thì nổ thường
            // fx
            root.gameObject.SetActive(false);
        }

        bool Expired()
        {
            return Time.time > time;
        }
    }
}