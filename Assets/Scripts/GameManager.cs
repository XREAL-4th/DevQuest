using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool isGameOver; //���� ���� ���θ� ������ ��� ����

    public int score = 0; //���� ���� �� 

    public bool IsGameOver
    {
        get { return isGameOver; } //getter ����: �ܺο��� ������Ƽ�� ���� �� ����Ǵ� ����: 

        set
        {
            isGameOver = value;
            if (isGameOver = value)
            {
                print("��������");
                Application.Quit();
                Quit(); //����Ƽ �����Ϳ��� ��������

            }
        } //setter ����: ���� ������ �� ����Ǵ� ����. ������Ƽ�� ���� �����ϸ� �� ���� value Ű���带 ���� ����
    }

    public static GameManager instance = null; //�̱��� �ν��Ͻ� ����


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } //�ν��Ͻ��� �Ҵ���� �ʾ��� ���

        else if (instance != this)
        {
            Destroy(this.gameObject);
        } //�ν��Ͻ��� �Ҵ�� Ŭ���� �ν��Ͻ��� �ٸ� ��� ���� ������ Ŭ������ �ǹ�

        DontDestroyOnLoad(this.gameObject); //�ٸ� ������ �Ѿ���� �������� �ʰ� ����
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        score++; //���� �� �� ���̸� score +1
        print("���� ���� ���Ǽ� =" + score);
        if (score >= 5)
        {
            print("���� 5���̻� �׿��� ��������");
            IsGameOver = true;//isGameOver ����
        }
    }


    public static void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                 Application.Quit();
        #endif
    }
}
