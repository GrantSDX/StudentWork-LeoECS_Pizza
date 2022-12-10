using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptsComponents
{
    public class IngredientsParent : MonoBehaviour
    {
        [SerializeField] private List<GameObject> ingredients;
        public List<GameObject> Ingredients => ingredients;

    }
}