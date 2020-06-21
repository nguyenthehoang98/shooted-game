using HOR.BattleSystem.Character.System;
using HOR.BattleSystem.Input.System;
using HOR.BattleSystem.Weapon.System;
using Leopotam.Ecs;
using UnityEngine;

namespace HOR.BattleSystem
{
    public class BattleStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        
        void Start ()
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new InputSystem())
                .Add(new CharacterSystem())
                .Add(new SpawnBulletRunSystem())
                .Add(new BulletRunSystem())
                .Inject(Service.Get<BattleManager>())
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }
        
        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }

        void PauseAll()
        {
            
        }

        void Pause()
        {
            
        }
    }
}