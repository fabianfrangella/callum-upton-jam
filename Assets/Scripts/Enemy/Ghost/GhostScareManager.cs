using Enemy.ScareEffects;
using UnityEngine;

namespace Enemy.Ghost
{
    public class GhostScareManager : MonoBehaviour
    {
        public ScareEffect effect;
        private void Start()
        {
            effect = GetComponent<SlowScareEffect>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                effect.Execute();
            }
        }
        
    }
}