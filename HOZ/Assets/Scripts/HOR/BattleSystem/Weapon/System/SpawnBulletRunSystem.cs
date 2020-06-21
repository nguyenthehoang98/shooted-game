using HOR.BattleSystem.Character.Action.Component;
using HOR.BattleSystem.Weapon.Component;
using HOR.BattleSystem.Weapon.Model;
using Leopotam.Ecs;

namespace HOR.BattleSystem.Weapon.System
{
    public class SpawnBulletRunSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LoadBulletComponent>.Exclude<BulletMovementComponent> filterBullet = null;
        public void Run()
        {
            foreach (var i in filterBullet)
            {
                ref var entity = ref filterBullet.GetEntity(i);
                ref var load = ref filterBullet.Get1(i);
                load.Execute();
                
                BulletMovementComponent bulletMove = new BulletMovementComponent();
                bulletMove.Setup(load.Bullet.transform, new BulletModel(20, 4, 0, 0));
                bulletMove.Fire();
                entity.Replace(bulletMove);
            }
        }
    }
}