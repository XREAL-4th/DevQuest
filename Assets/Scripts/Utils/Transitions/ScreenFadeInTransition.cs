using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utils.Transitions
{
    public class ScreenFadeInTransition : ScreenTransition
    {
        Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public override IEnumerator Run(float fadeDuration)
        {
            float t = 0;
            while (true)
            {
                t += Time.deltaTime;
                if (t > fadeDuration) break;
                image.color = new(0, 0, 0, t / fadeDuration);
                yield return null;
            }
        }
    }
}
