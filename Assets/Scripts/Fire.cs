using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Fire : MonoBehaviour {
 
    public GameObject Bullet;
    public GameObject Bomb;
    public Transform FirePos;

    public bool CoolOn = true;
    public float coolTimeAmount = 3.0f;

    
 
    // 마우스 좌클릭 입력을 받아 FirePos에 bulletclone을 생성한 후 일정 시간이 지난 후 파괴
    void Update () {
        if (Input.GetMouseButtonDown (0))
        {
            GameObject bulletclone = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Destroy(bulletclone,1.5f);
            
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject bombclone = Instantiate(Bomb, FirePos.transform.position, FirePos.transform.rotation);
            //CoolOn = false;
            //StartCoroutine(coolTime(coolTimeAmount));
            Destroy(bombclone,1.5f);
            
        }

    }

     IEnumerator coolTime(float time)
    {
        while (time > 1.0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        CoolOn = true;
    }
}