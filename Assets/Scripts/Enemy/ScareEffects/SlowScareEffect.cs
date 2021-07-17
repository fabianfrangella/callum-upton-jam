using System;
using System.Collections;
using UnityEngine;

namespace Enemy.ScareEffects
{
    public class SlowScareEffect : ScareEffect
    {
        public override void Execute()
        {
            StartCoroutine(nameof(SlowTime));
        }

        private IEnumerator SlowTime()
        {
            Time.timeScale = 0.5f;
            yield return new WaitForSeconds(scareTime);
            Time.timeScale = 1f;
        }
        
    }
}