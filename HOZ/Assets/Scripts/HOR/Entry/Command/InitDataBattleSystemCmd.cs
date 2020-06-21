using HOR.BattleSystem;
using HOR.BattleSystem.Character.Action;
using HOR.BattleSystem.Character.Action.Model;
using HOR.BattleSystem.Character.Movement;
using HOR.BattleSystem.Character.Movement.Model;
using HOR.BattleSystem.Config;
using HOR.Entry.Signal;
using UnityEngine;

namespace HOR.Entry.Command
{
    public class InitDataBattleSystemCmd : strange.extensions.command.impl.Command
    {
        [Inject(EntryInjectionName.ENTRY_SIGNAL_MANAGER)]
        public SignalManager SignalManager { get; set; }

        public override void Execute()
        {
            CharacterConfigScript characterConfig =
                Resources.Load("ScriptObject/CharacterConfig") as CharacterConfigScript;

            Service.Set(new BattleManager()
            {
                CharacterConfigScript = new CharacterConfigScript()
                {
                    action = new ActionModel(characterConfig.action.IdAttack, characterConfig.action.IdSkill_1,
                        characterConfig.action.IdSkill_2, characterConfig.action.IdSkill_3),
                    dash = new DashModel(characterConfig.dash.DashDistance, characterConfig.dash.DashDuration,
                        characterConfig.dash.DashingTime, characterConfig.dash.LayerCollision,
                        characterConfig.dash.DashEasing),
                    rotate = new RotateModel(characterConfig.rotate.RotateSpeed),
                    run = new RunModel(characterConfig.run.RunSpeed),
                    pathModel = characterConfig.pathModel
                },
                CharacterActionHandle = new CharacterActionHandle(),
                CharacterMovementHandle = new CharacterMovementHandle(
                    Object.Instantiate(Resources.Load(characterConfig.pathModel) as GameObject)
                        .GetComponent<CharacterController>())
            });

            SignalManager.EnterBattleModeSignal.Dispatch();
        }
    }
}