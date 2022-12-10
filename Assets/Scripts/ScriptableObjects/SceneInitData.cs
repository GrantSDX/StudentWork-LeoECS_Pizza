using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SceneInitData", menuName = "ScriptableObjects/SceneInitData", order = 0)]
    public class SceneInitData : ScriptableObject
    {
        [SerializeField] private GameObject tablePrefab;
        public GameObject TablePrefab => tablePrefab;

        [SerializeField] private GameObject ingridientsParent;
        public GameObject IngridientsParent => ingridientsParent;
    }
}