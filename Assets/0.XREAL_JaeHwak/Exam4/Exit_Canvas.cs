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
        UnityEditor.EditorApplication.isPlaying = false; //�����Ϳ��� �۵�
#else
				Application.Quit(); // ���� �� �۵�
#endif
    }
}
