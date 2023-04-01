using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{
    public static bool PlayerDead = false;

    public Slider PlayerHpSlider;

    int hp = 100;

    private void Start()
    {
        PlayerHpSlider.gameObject.SetActive(true);
        PlayerHpSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHpSlider.value = hp;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWeapon")
        {
            hp -= 5;
            Destroy(other.gameObject);
            if (hp == 0)
            {
                PlayerDead = true; ;
            }
        }
    }

   
}
