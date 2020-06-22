using HOR.BattleSystem.Character.Action;
using HOR.BattleSystem.Character.Action.Component;
using HOR.BattleSystem.Character.Movement.Component;
using Leopotam.Ecs;
using UnityEngine;

namespace HOR.BattleSystem.Character.System
{
    public class CharacterSystem : IEcsInitSystem, IEcsRunSystem
    { 
        private readonly EcsWorld world;
        private EcsFilter<RunComponent, DashComponent, ActionComponent> filterCharacter;
        private BattleManager manager;

        public void Init()
        {
            EcsEntity entity = world.NewEntity();
            
            RunComponent run = new RunComponent();
            run.Setup(manager.CharacterMovementHandle, manager.CharacterConfigScript.run);
            entity.Replace(run);
            
            DashComponent dash = new DashComponent();
            dash.Setup(manager.CharacterMovementHandle, manager.CharacterConfigScript.dash);
            entity.Replace(dash);
            
            ActionComponent action = new ActionComponent();
            LoadBulletAction loadBullet = new LoadBulletAction(world, manager.CharacterActionHandle,
                manager.CharacterMovementHandle.controller.transform, BattleUtils.IdBullet);
            action.Setup(manager.CharacterConfigScript.action);
            action.AddAction(loadBullet);
            entity.Replace(action);
        }

        public void Run()
        {
            foreach (var i in filterCharacter)
            {
                ref var run = ref filterCharacter.Get1(i);
                run.Update();
                ref var dash = ref filterCharacter.Get2(i);
                dash.Update();
                ref var action = ref filterCharacter.Get3(i);
                action.Update();
            }
        }
    }
}