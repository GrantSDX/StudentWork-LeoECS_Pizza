using System.Collections;
using UnityEngine;
using Leopotam.Ecs;
using Components;

namespace Systems
{
    public class DoughCookingRunSystem : IEcsRunSystem
    {
        private EcsFilter<DoughCookingComponent> _filter;
        private int counter = 0;

        public void Run()
        {
            

            foreach (var i in _filter)
            {
                var doughCooking = _filter.Get1(i);

                if(Input.touchCount >0)
                {
                    var touch = Input.GetTouch(0);
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector3.forward);
                    if(hit.collider)
                    {
                        if(hit.collider.TryGetComponent(out Ingredient ingredient))
                        {
                            if (counter < doughCooking.PositionsForIngedients.Count && (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Stationary))
                            {
                                ingredient.transform.position = doughCooking.PositionsForIngedients[counter++].position;
                                
                            }
                        }
                    }
                }
            }
        }
    }
}