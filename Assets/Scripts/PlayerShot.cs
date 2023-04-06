using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{
    public static bool PlayerDead = false;

    public Slider PlayerHpSlider;

    public static int PlayerHp = 100;

    private void Start()
    {
        PlayerDead = false;
        PlayerHp = 100;
        PlayerHpSlider.gameObject.SetActive(true);
        PlayerHpSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHp > 100)
        {
            PlayerHp = 100;
        }

        PlayerHpSlider.value = PlayerHp;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWeapon")
        {
            PlayerHp -= 5;
            Destroy(other.gameObject);
            if (PlayerHp == 0)
            {
                PlayerDead = true; ;
            }
        }
    }

   
}
