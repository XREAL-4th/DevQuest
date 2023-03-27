using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDelegator : MonoBehaviour
{
    public void GameIsFin()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Cursor.visible = true;
    }
}
