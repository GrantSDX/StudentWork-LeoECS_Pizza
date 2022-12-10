using UnityEngine;
using Leopotam.Ecs;
using ScriptableObjects;
using Components;

namespace Systems
{
    public class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private CameraInitData _cameraInitData;
        public void Init()
        {
            var camera = _world.NewEntity();

            ref var cameraComponent = ref camera.Get<CameraComponent>();
            cameraComponent.Camera = Camera.main;
            cameraComponent.Transform = cameraComponent.Camera.transform;
            cameraComponent.Scope = _cameraInitData.Scope;


        }
    }
}