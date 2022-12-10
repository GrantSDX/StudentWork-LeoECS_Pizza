using System.Collections;
using UnityEngine;
using Leopotam.Ecs;
using Components;
using ScriptableObjects;

namespace Systems
{
    public class DoughCookingInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private DoughCookingInitData _doughCookingInitData;
        public void Init()
        {
            var doughCooking = _world.NewEntity();
            var spawnedDoughCooking = GameObject.Instantiate(_doughCookingInitData.DoughCooking.gameObject);
            ref var doughCookingComponent = ref doughCooking.Get<DoughCookingComponent>();
            doughCookingComponent.PositionsForIngedients = spawnedDoughCooking.GetComponent<DoughCooking>().PositionsForIngedients;
        }
    }
}