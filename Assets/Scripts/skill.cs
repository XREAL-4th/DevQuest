using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skill : MonoBehaviour
{
    [SerializeField] private Image coolTimeImg;
    [SerializeField] private Button icon;
    //IEnumerator coroutine;
    [SerializeField] private bool skillAvailable = true;
    GameObject player;
    [SerializeField] private float coolTimeSecond = 5f;
    [SerializeField] private TMP_Text coolTimeText;

    [Header("VFX")]
    [SerializeField] private GameObject bombSplashFx;

    float currentCooldown = 5f;

    void Start()
    {
        player = GameManager.instance.player;
        //아이콘에 버튼 리스너 붙이기
        icon.onClick.AddListener(Bomb);
        //쿨타임 초기화
        coolTimeImg.fillAmount = 0;
        coolTimeText.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && skillAvailable)
        {
            StartCoroutine("UseSkill");
        }
        //쿨타임 이미지, 시간 표시
        if (!skillAvailable)
        {
            ShowCoolTime();
        }

    }
    public void Bomb()
    {
        //일정 거리 내의 모든 물체 받아오기
        Collider[] colls = Physics.OverlapSphere(player.transform.position, 10.0f);
        int damage = 20;

        //데미지 & vfx 들어가기
        for (int i=0; i<colls.Length; i++)
        {
            if(colls[i].tag == "Enemy")
            {
                Instantiate(bombSplashFx, colls[i].transform.position, Quaternion.identity);
                colls[i].gameObject.GetComponent<Enemy>().GetDamage(damage);
            }
        }        
    }

    //쿨타임 이미지, 시간 표시
    private void ShowCoolTime()
    {
        currentCooldown -= Time.deltaTime;
        coolTimeImg.fillAmount = currentCooldown / coolTimeSecond;
        coolTimeText.text = currentCooldown.ToString("F1");
    }
    IEnumerator UseSkill()
    {
        //스킬 사용
        Bomb();
        //스킬 쿨타임
        skillAvailable = false;
        coolTimeImg.fillAmount = 1;
        coolTimeText.enabled = true;
        
        yield return new WaitForSeconds(coolTimeSecond);   //5초간 중지
        skillAvailable = true;
        coolTimeImg.fillAmount = 0;
        currentCooldown = 5f;
        coolTimeText.enabled = false;
        yield break;
    }
}
