using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughCooking : MonoBehaviour
{
    [SerializeField] private List<Transform> positionsForIngedients;
    public List<Transform> PositionsForIngedients => positionsForIngedients;
}
