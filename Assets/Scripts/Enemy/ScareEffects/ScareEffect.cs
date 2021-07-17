using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enemy.ScareEffects
{
    public abstract class ScareEffect : MonoBehaviour
    {
        [Range(0, 10)] public float scareTime = 5;
        public abstract void Execute();
        
    }
}