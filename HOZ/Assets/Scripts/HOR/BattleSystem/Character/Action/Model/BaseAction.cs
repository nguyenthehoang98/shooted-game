using Leopotam.Ecs;
using UnityEngine;

namespace HOR.BattleSystem.Character.Action.Model
{
    public abstract class BaseAction
    {
        protected readonly EcsWorld world;
        protected readonly CharacterActionHandle actionHandle;

        public BaseAction(EcsWorld world, CharacterActionHandle action)
        {
            this.world = world;
            this.actionHandle = action;
        }

        public void Execute()
        {
            if (actionHandle.GetSkill() == null) return;
            if (actionHandle.GetSkill().Id.Equals(IdActionRoot()))
            {
                actionHandle.ActionRelease();
                SetupAction();
            }
        }
        
        protected abstract void SetupAction();
        protected abstract int IdActionRoot();
    }
}