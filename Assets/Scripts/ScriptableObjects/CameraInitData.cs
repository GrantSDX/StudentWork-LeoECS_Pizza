using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CameraInitData", menuName = "ScriptableObjects/CameraInitData", order = 0)]
    public class CameraInitData : ScriptableObject
    {
        [SerializeField] private float scope;
        public float Scope => scope;
    }
}