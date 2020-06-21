using HOR.BattleSystem.Weapon.Component;
using Leopotam.Ecs;

namespace HOR.BattleSystem.Weapon.System
{
    public class BulletRunSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BulletMovementComponent> filterBullet = null;

        public void Run()
        {
            foreach (var i in filterBullet)
            {
                ref var run = ref filterBullet.Get1(i);
                run.Update();

                ref var entity = ref filterBullet.GetEntity(i);
                if(run.IsDestroy())
                    filterBullet.OnRemoveEntity(entity);
            }
        }
    }
}