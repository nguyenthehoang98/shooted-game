using HOR.BattleSystem.Character.Action.Component;
using HOR.BattleSystem.Character.Action.Model;
using HOR.BattleSystem.Weapon.Model;
using Leopotam.Ecs;
using UnityEngine;

namespace HOR.BattleSystem.Character.Action
{
    public class LoadBulletAction : BaseAction
    {
        private Transform muzzle;
        private int idBullet = -1;

        public LoadBulletAction(EcsWorld world, CharacterActionHandle actionHandle, Transform muzzle, int id)
            : base(world, actionHandle)
        {
            this.muzzle = muzzle;
            this.idBullet = id;
        }

        protected override void SetupAction()
        {
            var entity = world.NewEntity();
            LoadBulletComponent loadBulletComponent = new LoadBulletComponent();
            BulletModel bulletModel = Service.Get<CharacterManager>().WeaponContainer.GetBulletModel(idBullet);
            loadBulletComponent.Setup(muzzle, bulletModel);
            entity.Replace(loadBulletComponent);
        }

        protected override int IdActionRoot()
        { 
            return 1;
        }
    }
}