using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    public string weaponName;
    public int bulletsPerMag;       // źâ �� ��ź ��
    public int bulletsTotal;        // ��ü ������ �ִ� ��ź ��
    public int currentBullets;      // ���� źâ�� �����ִ� ��ź ��
    public float range;				// �����Ÿ�
    public float fireRate;			// ����ӵ�
    public float damage;			// ������

    private float fireTimer;		// ��ź�� ��ź ������ �߻� ���� ����

    public Transform shootPoint;        // ��ź�� ���� �߻�Ǵ� ����

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