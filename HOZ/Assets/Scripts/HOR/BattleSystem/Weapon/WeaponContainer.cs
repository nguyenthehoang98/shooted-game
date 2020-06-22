using System.Collections.Generic;
using HOR.BattleSystem.Weapon.Model;
using UnityEngine;

namespace HOR.BattleSystem.Weapon
{
    public class WeaponContainer
    {
        private Dictionary<int, List<BulletModel>> bulletPool = new Dictionary<int, List<BulletModel>>();
        
        public void AddWeapon(BulletModel ob)
        {
            if (!bulletPool.ContainsKey(ob.Id))
            {   List<BulletModel> obs = new List<BulletModel>()
                {
                    new BulletModel(ob.Id, ob.Path, ob.MoveSpeed, ob.TimeLife, ob.Damage, ob.RadiusDamage, ob.RadiusColl)
                };
                bulletPool.Add(ob.Id, obs);
            }
        }
        
        T GetPool<T>(int id) where T : class, new()
        {
            if (typeof(T) == typeof(BulletModel) && bulletPool.ContainsKey(id))
            {
                List<BulletModel> bms = bulletPool[id];
                foreach (var i in bms)
                {
                    if (!i.Bullet.activeSelf)
                    {
                        return i as T;
                    }
                }

                BulletModel new_bm = new BulletModel(bms[0].Id, bms[0].Path, bms[0].MoveSpeed, bms[0].TimeLife,
                    bms[0].Damage, bms[0].RadiusDamage, bms[0].RadiusColl);
                bulletPool[id].Add(new_bm);
                return new_bm as T;
            }

            return default(T);
        }

        public BulletModel GetBulletModel(int id)
        {
            Debug.Log(bulletPool[id].Count);
            BulletModel bulletModel = GetPool<BulletModel>(id);
            bulletModel.Bullet.SetActive(true);
            return bulletModel;
        }
    }
}