using Leopotam.Ecs;

namespace HOR.BattleSystem.Character.Action.Model
{
    public abstract class BaseAction
    {
        protected readonly EcsWorld world;
        public BaseAction(EcsWorld world) { this.world = world; }

        public void Execute(CharacterActionHandle actionHandle)
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