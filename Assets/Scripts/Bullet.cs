using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;
    public GameObject splashFx;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(splashFx, transform.position, Quaternion.identity);
            if(splashFx)
            //player의 getDamage 함수 호출 (데미지 입히기)
            collision.gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
        if (collision.gameObject.tag == "Background")
        {
            Destroy(gameObject, 3);
        }
    }
}
