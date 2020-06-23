using HOR.BattleSystem.Input.Component;
using Leopotam.Ecs;

namespace HOR.BattleSystem.Input.System
{
    public class InputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> filterInput = null;
        private readonly EcsWorld world;
        private readonly CharacterManager manager;
        
        public void Init()
        {
            EcsEntity entity = world.NewEntity();
            
            InputComponent input = new InputComponent();
            input.Setup(manager.CharacterMovementHandle, manager.CharacterActionHandle);
            entity.Replace(input);
        }
        

        public void Run()
        {
            foreach (var i in filterInput)
            {
                ref var input = ref filterInput.Get1(i);
                input.Update();
            }
        }
    }
}