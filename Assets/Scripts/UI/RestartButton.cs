using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnClick() => ScreenTransitionController.Main.ChangeScene
            <ScreenFadeInTransition, ScreenFadeOutTransition>
            ("Assignment", 0.5f, 1);
}