using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> points = new List<Transform>(); //아이템이 나타날 위치를 저장할 List 변수
    public List<Transform> points2 = new List<Transform>(); //아이템이 나타날 위치를 저장할 List 변수

    public GameObject ItemMinus; // -가 되는 아이템을 연결할 변수
    public GameObject ItemPlus; // +가 되는 아이템을 연결할 변수

    public int playerAttack = 10; //player의 기본 공격력은 10

    private bool isGameOver; //게임 종료 여부를 저장할 멤버 변수

    public int score = 0; //죽인 적의 수 

    //public float cooltime = 0.0f; //쿨타임은 10초 세기
    //public float time = 0;

    public bool IsGameOver
    {
        get { return isGameOver; } //getter 영역: 외부에서 프로퍼티를 읽을 때 실행되는 영역: 

        set
        {
            isGameOver = value;
            if (isGameOver = value)
            {
                print("게임종료");
                Application.Quit();
                Quit(); //유니티 에디터에서 게임종료

            }
        } //setter 영역: 값을 저장할 때 실행되는 영역. 프로퍼티에 값을 대입하면 그 값은 value 키워드를 통해 전달
    }

    public static GameManager instance = null; //싱글턴 인스턴스 선언
    //public static GameManager getInstance 


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } //인스턴스가 할당되지 않았을 경우

        else if (instance != this)
        {
            Destroy(this.gameObject);
        } //인스턴스에 할당된 클라스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미

        DontDestroyOnLoad(this.gameObject); //다른 씬으로 넘어가더도 삭제되지 않고 유지
        
    }

    private void Start()
    {
        //coolTimeSet(); //시작할 때 바로 쿨타임 시간 한 번 세주기 update랑 중복되니까 제거. 어차피 시작할 때부터 false라서 update에서 시작할때부터 시간세줌

        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;   //SpwanGroup 오브젝트의 Transform 컴포넌트 추출

        Transform spawnPointGroup2 = GameObject.Find("SpawnPointGroup2")?.transform;   //SpwanGroup2 오브젝트의 Transform 컴포넌트 추출

        //spawnPointGroup?.GetComponentsInChildren<Transform>(points); //SpawnGroup 하위에 있는 모든 차일드 게임 오븢게트의 Trnasform 컴포넌트 추출

        foreach (Transform point in spawnPointGroup)
        {
            points.Add(point);
        } //SpwanPointGroup 하위에 있는 모든 차읻르 게임 오브젝트의 Transfor 컴포넌트 추출


        foreach (Transform point2 in spawnPointGroup2)
        {
            points2.Add(point2);
        }

        Invoke("CreateMinusItem", 1.0f); //1초 후에 CreateMinusItem 함수 호출
        Invoke("CreatePlusItem", 1.0f); //1초 후에 CreatePlusItem 함수 호출
    }

    // Update is called once per frame
    void Update()
    {
        //cooltime += Time.deltaTime;
        //print("현재 쿨타임은:" + cooltime);
        
        /*
        if (GameObject.Find("Player").GetComponent<PlayerSkill>().setCooltime == false)
        {
            //StartCoroutine(coolTimeSet());
            //StartCoroutine(CoStartTimeCount());
        }
        */

        
        //Player Skill 에 setCooltime이 false면 시간 세주는 함수 불러오기
    }


    public void Score()
    {
        score++; //적을 한 명 죽이면 score +1
        print("현재 죽인 적의수 =" + score);
        if (score >= 5)
        {
            print("적을 5명이상 죽여서 게임종료");
            IsGameOver = true;//isGameOver 실행
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
    } //아이템 생성 


    public void AttackMinus()
    {
        playerAttack -= 5; //5씩 감소

    } //아이템 먹으면 공격력 감소하는 함수

    void CreatePlusItem()
    {
        Instantiate(ItemPlus, points2[0].position, points2[0].rotation);
        Instantiate(ItemPlus, points2[1].position, points2[1].rotation);
    } //아이템 생성


    public void AttackPlus()
    {
        playerAttack += 5; //5씩증가

    }




    /*
     

        /*
    IEnumerator CoStartTimeCount()
    {
        
        while (GameObject.Find("Player").GetComponent<PlayerSkill>().setCooltime == false)
        {  // 공이 부숴지면 시간기록을 멈춘다.
            time += Time.deltaTime;
            System.TimeSpan t = System.TimeSpan.FromSeconds(time);


            print("현재 초 : " + time);
            // print("현재 초 : "+t.TotalSeconds.ToString());
            //timeCountText.text = t.TotalSeconds.ToString();
            yield return new WaitForEndOfFrame();
        }

    }


        IEnumerator coolTimeSet() //쿨타임 시간 세는 함수
     {

        //매번 불러올 때마다 0초부터 시작. 여기서 초기화해주면 PlayerSkill에서 초기화 안해줘도 됨.

        //yield return null;

        while (true)
        {
            if (cooltime >= 0 && cooltime <= 10)
            {
                cooltime += Time.deltaTime;
                print("현재 쿨타임은:" + cooltime);

                if(GameObject.Find("Player").GetComponent<PlayerSkill>().setCooltime == true)
                {
                    print("쿨타임이 true가 되었다");
                    cooltime = 0.0f;
                    break;
                    
                }

            }

            /*
            else
            {
                yield return null;
            }
            */

    //yield return new WaitForEndOfFrame();

        /*
        if(cooltime >= 0 && cooltime <= 10)
        {
            cooltime += Time.deltaTime;
            print("현재 쿨타임은:" + cooltime);

        }
        */

        //yield return null;



        //if 정수일 때마다 print 해주기
        //print("현재 쿨타임은:"+cooltimeSet);
        /*
         cooltimeSet = 0;
        cooltimeSet += Time.deltaTime; //쿨타임 시간

        
        if (cooltimeSet == 10)
        {
            return cooltimeSet;

        }

        return 0;

        */

}