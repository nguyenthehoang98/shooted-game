using HOR.BattleSystem.Character.Action;
using HOR.BattleSystem.Character.Movement;
using HOR.BattleSystem.Config;
using HOR.BattleSystem.Weapon;

namespace HOR.BattleSystem
{
    public class CharacterManager
    {
        public CharacterConfigScript CharacterConfigScript { get; set; }
        public CharacterMovementHandle CharacterMovementHandle { get; set; }
        public CharacterActionHandle CharacterActionHandle { get; set; }
        public WeaponContainer WeaponContainer { get; set; }
    }
}