using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "DoughCookingInitData", menuName = "ScriptableObjects/DoughCookingInitData", order = 0)]
    public class DoughCookingInitData : ScriptableObject
    {
        [SerializeField] private DoughCooking doughCooking;
        public DoughCooking DoughCooking => doughCooking;

    }
}