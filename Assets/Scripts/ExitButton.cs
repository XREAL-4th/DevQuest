using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickExit()
    {
        GameManager.instance.ExitButtonClicked = true;
    }
}
