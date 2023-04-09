using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Canvas : MonoBehaviour
{
    public GameObject Exit_Pannel;
    //public Transform Left_Controller;
    public GameObject UI_Anchor;
    void Start()
    {
        Exit_Pannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit_Pannel.SetActive(!Exit_Pannel.activeSelf);
        }*/
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Exit_Pannel.SetActive(!Exit_Pannel.activeSelf);
        }
        if (Exit_Pannel.activeSelf == true)
        {
            this.transform.position = UI_Anchor.transform.position;
            this.transform.eulerAngles = new Vector3(UI_Anchor.transform.eulerAngles.x, UI_Anchor.transform.eulerAngles.y, UI_Anchor.transform.eulerAngles.z);
        }
        /*        if(Exit_Pannel.activeSelf == true)
                {
                    this.transform.position = Left_Controller.transform.position;
                    this.transform.rotation = Left_Controller.transform.rotation;
                }*/

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
