using HOR.BattleSystem.Character.Action;
using HOR.BattleSystem.Character.Movement;
using HOR.BattleSystem.Config;

namespace HOR.BattleSystem
{
    public class BattleManager
    {
        public CharacterConfigScript CharacterConfigScript { get; set; }
        public CharacterMovementHandle CharacterMovementHandle { get; set; }
        public CharacterActionHandle CharacterActionHandle { get; set; }
    }
}