using Leopotam.Ecs;
using UnityEngine;
using ScriptableObjects;
using Systems;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        
        [SerializeField] private SceneInitData sceneInitData;         
        [SerializeField] private DoughCookingInitData doughCookingInitData;
        [SerializeField] private CameraInitData cameraInitData;    


        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                .Add (new SceneInitSystem())
                .Add (new CameraInitSystem())
                .Add (new CameraMoovementRunSystem())
                .Add (new DoughCookingInitSystem())
                .Add (new DoughCookingRunSystem())
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(sceneInitData)
                .Inject(cameraInitData)
                .Inject(doughCookingInitData)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}