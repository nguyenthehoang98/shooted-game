using HOR.BattleSystem;
using HOR.BattleSystem.Character.Action;
using HOR.BattleSystem.Character.Action.Model;
using HOR.BattleSystem.Character.Movement;
using HOR.BattleSystem.Character.Movement.Model;
using HOR.BattleSystem.Config;
using HOR.BattleSystem.Weapon;
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
            CharacterConfigScript _characterConfig =
                Resources.Load("ScriptObject/CharacterConfig") as CharacterConfigScript;
            WeaponConfigScripts _weaponConfig = 
                Resources.Load("ScriptObject/WeaponConfig") as WeaponConfigScripts;
//=====================
            CharacterConfigScript characterConfig = new CharacterConfigScript()
            {
                action = new ActionModel(_characterConfig.action.IdAttack,
                    _characterConfig.action.IdSkill_1,
                    _characterConfig.action.IdSkill_2, _characterConfig.action.IdSkill_3),
                dash = new DashModel(_characterConfig.dash.DashDistance, _characterConfig.dash.DashDuration,
                    _characterConfig.dash.DashingTime, _characterConfig.dash.LayerCollision,
                    _characterConfig.dash.DashEasing),
                rotate = new RotateModel(_characterConfig.rotate.RotateSpeed),
                run = new RunModel(_characterConfig.run.RunSpeed),
                pathModel = _characterConfig.pathModel
            };
            CharacterMovementHandle characterMovement = new CharacterMovementHandle(
                Object.Instantiate(Resources.Load(_characterConfig.pathModel) as GameObject)
                    .GetComponent<CharacterController>());
            CharacterActionHandle characterAction = new CharacterActionHandle()
            {
                actionModel = characterConfig.action
            };
            WeaponContainer weaponContainer = new WeaponContainer();
            weaponContainer.AddWeapon(_weaponConfig.bullets[0]);
            Service.Set(new BattleManager()
            {
                CharacterConfigScript = characterConfig,
                CharacterActionHandle =  characterAction,
                CharacterMovementHandle = characterMovement,
                WeaponContainer = weaponContainer
            });
//=====================
            
            SignalManager.EnterBattleModeSignal.Dispatch();
        }
    }
}