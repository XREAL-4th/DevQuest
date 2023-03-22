using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    public string weaponName;
    public int bulletsPerMag;       // ÅºÃ¢ ´ç ÀåÅº ¼ö
    public int bulletsTotal;        // ÀüÃ¼ °¡Áö°í ÀÖ´Â ÃÑÅº ¼ö
    public int currentBullets;      // ÇöÀç ÅºÃ¢¿¡ ³²¾ÆÀÖ´Â ÃÑÅº ¼ö
    public float range;				// »çÁ¤°Å¸®
    public float fireRate;			// ¿¬»ç¼Óµµ
    public float damage;			// µ¥¹ÌÁö

    private float fireTimer;		// ÃÑÅº°ú ÃÑÅº »çÀÌÀÇ ¹ß»ç °£°Ý ¼³Á¤

    public Transform shootPoint;        // ÃÑÅºÀÌ ½ÇÁ¦ ¹ß»çµÇ´Â ÁöÁ¡

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = bulletsPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (currentBullets > 0)
            {
                Fire();
            }
            if (fireTimer < fireRate)
            {
                fireTimer += Time.deltaTime;
            }
        }
    }

    private void Fire()
    {
        if (fireTimer < fireRate) return;
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.LogWarning(hit.transform.name);
        }
        currentBullets--;
        fireTimer = 0.0f;
    }
}