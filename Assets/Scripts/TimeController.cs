using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TimeController: LazyDDOLSingletonMonoBehaviour<TimeController>
{
    float cachedScale;
    bool paused = false;

    public void Pause()
    {
        if(paused) return;
        paused = true;
        cachedScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        if(!paused) return;
        paused = false;
        Time.timeScale = cachedScale;
    }
}
