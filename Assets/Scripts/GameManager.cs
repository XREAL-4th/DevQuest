using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> points = new List<Transform>(); //�������� ��Ÿ�� ��ġ�� ������ List ����
    public List<Transform> points2 = new List<Transform>(); //�������� ��Ÿ�� ��ġ�� ������ List ����

    public GameObject ItemMinus; // -�� �Ǵ� �������� ������ ����
    public GameObject ItemPlus; // +�� �Ǵ� �������� ������ ����

    public int playerAttack = 10; //player�� �⺻ ���ݷ��� 10

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
    //public static GameManager getInstance 


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

    private void Start()
    {
       

        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;   //SpwanGroup ������Ʈ�� Transform ������Ʈ ����

        Transform spawnPointGroup2 = GameObject.Find("SpawnPointGroup2")?.transform;   //SpwanGroup2 ������Ʈ�� Transform ������Ʈ ����

        //spawnPointGroup?.GetComponentsInChildren<Transform>(points); //SpawnGroup ������ �ִ� ��� ���ϵ� ���� ������Ʈ�� Trnasform ������Ʈ ����

        foreach (Transform point in spawnPointGroup)
        {
            points.Add(point);
        } //SpwanPointGroup ������ �ִ� ��� ���޸� ���� ������Ʈ�� Transfor ������Ʈ ����


        foreach (Transform point2 in spawnPointGroup2)
        {
            points2.Add(point2);
        }

        Invoke("CreateMinusItem", 1.0f); //1�� �Ŀ� CreateMinusItem �Լ� ȣ��
        Invoke("CreatePlusItem", 1.0f); //1�� �Ŀ� CreatePlusItem �Լ� ȣ��
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
    
    void CreateMinusItem()
    {
        Instantiate(ItemMinus, points[0].position, points[0].rotation);
        Instantiate(ItemMinus, points[1].position, points[1].rotation);
    } //������ ���� 


    public void AttackMinus()
    {
        playerAttack -= 5; //5�� ����

    } //������ ������ ���ݷ� �����ϴ� �Լ�

    void CreatePlusItem()
    {
        Instantiate(ItemPlus, points2[0].position, points2[0].rotation);
        Instantiate(ItemPlus, points2[1].position, points2[1].rotation);
    } //������ ����


    public void AttackPlus()
    {
        playerAttack += 5; //5������

    }
}
