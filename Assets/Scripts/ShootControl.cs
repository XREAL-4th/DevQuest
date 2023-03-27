using System.Collections;
using System.Xml.Serialization;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShootControl : MonoBehaviour
{
    [Header("Preset Fields")]
    public Camera PlayerCam;
    [SerializeField] GameObject ShootEffect;
    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject coolTimeUI;
    public GameObject muzzle;

    [Header("Settings")]
    [Range(15f, 50f)] public float damage = 25.0f;
    [SerializeField] private float range = 100.0f;
    public float Skill1coolTime = 3.0f;
    private bool IsCoolOver = true;

    void Update()
    {
        //+--- [0320] Task2 ---+//
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.E) && IsCoolOver)
        {
            IsCoolOver = false;
            StartCoroutine(coolTime(Skill1coolTime));
            BoomShoot();
        }
    }

    // Raycasting(Hitscan)
    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null) 
            {
                target.TakeDamage(damage);
            }

            // VFX
            GameObject effect = Instantiate(ShootEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect, 1.0f);
        }
    }

    IEnumerator coolTime(float time)
    {
        while (time > 1.0f)
        {
            time -= Time.deltaTime;
            coolTimeUI.GetComponent<Image>().fillAmount = (1.0f / time);
            yield return new WaitForFixedUpdate();
        }
        IsCoolOver = true;
    }

    public void BoomShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            // πﬂªÁ√º(√—±∏ ~target)
            Vector3 dir = hit.point - muzzle.transform.position;
            GameObject bulletClone = Instantiate(Bomb, muzzle.transform.position, muzzle.transform.rotation);
            bulletClone.GetComponent<Rigidbody>().velocity = dir.normalized * 10.0f;
            Destroy(bulletClone, 2.0f);
        }
    }
}
