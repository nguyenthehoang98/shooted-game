using System.Collections.Generic;
using HOR.BattleSystem.Weapon.Model;
using UnityEngine;

namespace HOR.BattleSystem.Config
{
    [CreateAssetMenu(menuName = "ScriptObject/WeaponConfig", order = 2, fileName = "WeaponConfig")]
    public class WeaponConfigScripts : ScriptableObject
    {
        public List<BulletModel> bullets;
    }
}