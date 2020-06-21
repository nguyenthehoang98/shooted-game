using HOR.BattleSystem.Character.Action.Component;
using HOR.BattleSystem.Character.Action.Model;
using Leopotam.Ecs;
using UnityEngine;

namespace HOR.BattleSystem.Character.Action
{
    public class LoadBulletAction : BaseAction
    {
        private Transform muzzle;
        private GameObject bullet;
        
        public LoadBulletAction(EcsWorld world, Transform muzzle, GameObject bullet) : base(world)
        {
            this.muzzle = muzzle;
            this.bullet = bullet;
        }

        protected override void SetupAction()
        {
            var entity = world.NewEntity();
            LoadBulletComponent loadBulletComponent = new LoadBulletComponent();
            loadBulletComponent.Setup(muzzle, bullet);
            entity.Replace(loadBulletComponent);
        }

        protected override int IdActionRoot()
        { 
            return 1;
        }
    }
}