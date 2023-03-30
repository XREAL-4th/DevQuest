using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadMask : SingletonMonoBehaviour<ReloadMask>
{
    [SerializeField] private Image maskImage;

    private IEnumerator ReloadCoroutine(float duration)
    {
        float t = 0;

        while(t < duration)
        {
            t += Time.deltaTime;

            maskImage.fillAmount = 1 - t / duration;
    
            yield return null;
        }
    }

    public void StartReload(float duration) => StartCoroutine(ReloadCoroutine(duration));
}
