using Components;
using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

namespace Systems
{
    public class CameraMoovementRunSystem : IEcsRunSystem
    {
        private EcsFilter<CameraComponent> _filter;
        private Vector2 _firstTouchPosition;
        private Vector2 _secondTouchPosition;
        private Vector2 _touchDirection;

        public void Run()
        {
            foreach (var i in _filter)
            {

                var camera = _filter.Get1(i);

                

                if(Input.touchCount >0)
                {
                    var touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began) _firstTouchPosition = touch.position;

                    if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                    {
                        _secondTouchPosition = touch.position;
                        _touchDirection = _firstTouchPosition - _secondTouchPosition;
                        _touchDirection = Vector2.ClampMagnitude(_touchDirection, 20f);
                        if (Mathf.Abs(camera.Transform.position.x + _touchDirection.x * Time.deltaTime) <= camera.Scope)
                            camera.Transform.position += new Vector3(_touchDirection.x, 0f, 0f) * Time.deltaTime;
                    }

                    if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                        _firstTouchPosition = _secondTouchPosition = _touchDirection = Vector2.zero;
                }

            }
        }
    }
}