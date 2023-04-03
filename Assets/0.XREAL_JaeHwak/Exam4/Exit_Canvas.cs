using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Canvas : MonoBehaviour
{
    public GameObject Exit_Pannel;

    void Start()
    {
        Exit_Pannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit_Pannel.SetActive(!Exit_Pannel.activeSelf);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //에디터에서 작동
#else
				Application.Quit(); // 빌드 시 작동
#endif
    }
}
