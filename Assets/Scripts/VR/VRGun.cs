using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VRGun : MonoBehaviour
{
    public Transform firePos;
    public Transform fireBack;
    public GameObject bulletPrefab;
    [SerializeField] private PointableUnityEventWrapper tmp;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        //tmp = GetComponent<PointableUnityEventWrapper>();
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("Ba");
            GameObject _bullet;
            dir = (firePos.position - fireBack.position);

            _bullet = Instantiate(bulletPrefab);
            _bullet.transform.position = firePos.position;
            Bullet bb = _bullet.GetComponent<Bullet>();
            bb.SetDirection(dir);
            Debug.Log("ng");
        }
    }
}
