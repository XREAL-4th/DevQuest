using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱��� ���� : �� ���� Ŭ���� �ν��Ͻ��� ������ �����ϰ�, �̿� ���� �������� ������ ����
    public static GameManager gm;

    private float GameTime = 15;
    public Text GameTimeText;

    //���� ���� UI ������Ʈ ����
    public GameObject gameLabel;
    //UI �ؽ�Ʈ ������Ʈ ����
    Text gameText;

    //���� ���� UI ������Ʈ ����
    public GameObject menuSet;

    //VR ���� ���� UI ������Ʈ ����
    public GameObject menuVR;

    //���� ���� ��ư ������Ʈ ����
    public GameObject menuButton;

    private void Awake()
    {
        gm = this;
    }

 

    // Update is called once per frame
    void Update()
    {
        
        //���� �޴�   
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                menuButton.SetActive(true);
            }
            else
            {
                menuSet.SetActive(true);
                menuButton.SetActive(false);

            }
                
        }
        //���� �޴� ���� �� ���� ��ư Ȱ��
        if (menuSet.activeSelf)
        {
            if (Input.GetKey(KeyCode.Y))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            if (Input.GetKey(KeyCode.N))
            {
                menuSet.SetActive(false);
            }
           
        }
        //VR ���� �޴� ���� �� ���� ��ư Ȱ��
        if (menuVR.activeSelf)
        {
            if (Input.GetButton("Yes"))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            if (Input.GetButton("No"))
            {
                menuSet.SetActive(false);
            }
        }
       


        if ((int)GameTime == 0)
        {
            SceneManager.LoadScene("Ending");
        }
        else
        {
            GameTime -= Time.deltaTime;
            
        }
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
