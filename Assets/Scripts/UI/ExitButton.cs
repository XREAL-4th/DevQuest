using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnClick()
    {
        DialogManager.Main.Show(new () {
            title = "Warning!",
            description = "Are you sure want to exit?",
            onConfirmed = (dialog) => {
                dialog.Close();
                StartCoroutine(GameExit());
            }
        });
    }
    IEnumerator GameExit()
    {
        yield return ScreenTransitionController.Main.StartTransition<ScreenFadeInTransition>(1);
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
