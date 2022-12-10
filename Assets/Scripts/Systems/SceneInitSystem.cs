using System.Collections;
using UnityEngine;
using Leopotam.Ecs;
using ScriptableObjects;
using Components;
using ScriptsComponents;

namespace Systems
{
    public class SceneInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private SceneInitData _sceneInitData;
        public void Init()
        {
            var table = _world.NewEntity();
            var spawnedTable = GameObject.Instantiate(_sceneInitData.TablePrefab);

            ref var tableComponent = ref table.Get<TableComponent>();
            tableComponent.Transform = spawnedTable.transform;
            tableComponent.SpriteRenderer = spawnedTable.GetComponent<SpriteRenderer>();


            var ingridient = _world.NewEntity();      
            var spawnedIngredient = GameObject.Instantiate(_sceneInitData.IngridientsParent);

            ref var ingridientComponent = ref ingridient.Get<IngredientComponent>();
            ingridientComponent.IngredientsParent = spawnedIngredient.GetComponent<IngredientsParent>();
        }
    }
}