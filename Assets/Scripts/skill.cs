using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    public RawImage iconImage;
    public Button icon;
    IEnumerator coroutine;
    bool skillAvailable = true;
    GameObject player;

    [Header("VFX")]
    public GameObject bombSplashFx;

    void Start()
    {
        //iconImage = UIManager.instance.;
        player = GameManager.instance.player;
        coroutine = UseSkill();
        //아이콘에 버튼 리스너 붙이기
        icon.onClick.AddListener(Bomb);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && skillAvailable)
        {
            coroutine = UseSkill();
            StartCoroutine(coroutine);
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
    IEnumerator UseSkill()
    {
        //스킬 사용
        Bomb();
        //스킬 쿨타임
        skillAvailable = false;
        iconImage.color = Color.gray;
        yield return new WaitForSeconds(5f);   //10초간 중지
        skillAvailable = true;
        iconImage.color = Color.white;
        yield break;
    }
}
