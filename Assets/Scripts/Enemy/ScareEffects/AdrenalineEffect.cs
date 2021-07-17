using System;
using System.Collections;
using UnityEngine;

namespace Enemy.ScareEffects
{
    public class AdrenalineEffect : ScareEffect
    {
        public override void Execute()
        {
            StartCoroutine(nameof(SpeedTimeUp));
        }

        private IEnumerator SpeedTimeUp()
        {
            Time.timeScale = 1.5f;
            yield return new WaitForSeconds(scareTime);
            Time.timeScale = 1f;
        }
    }
}