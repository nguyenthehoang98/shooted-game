using HOR.BattleSystem.Character.Action.Component;
using HOR.BattleSystem.Weapon.Component;
using HOR.BattleSystem.Weapon.Model;
using Leopotam.Ecs;

namespace HOR.BattleSystem.Weapon.System
{
    public class SpawnBulletRunSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LoadBulletComponent>.Exclude<BulletMovementComponent> filterBullet = null;
        private readonly CharacterManager characterManager = null;
        
        public void Run()
        {
            foreach (var i in filterBullet)
            {
                ref var entity = ref filterBullet.GetEntity(i);
                ref var load = ref filterBullet.Get1(i);
                load.Update();
                
                BulletMovementComponent bulletMove = new BulletMovementComponent();
                bulletMove.Setup(load.BulletModel);
                bulletMove.Fire();
                entity.Replace(bulletMove);
            }
        }
    }
}