using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private enum Type
    {
        Primary,
        Secondary,
        Melee
    }
    [SerializeField] private Transform firePos;
    [SerializeField] private Type type;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private ParticleSystem[] fxList;
    private ParticleSystem buffFx;

    private float timer;
    private bool isCooldown = false;
    public bool isPowerShot = false;
    private bool isPowerShotFx = false;

    private Vector3 dir;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        type = Type.Primary;
    }

    // Update is called once per frame
    void Update()
    {
        LoadFx();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //type= Type.Primary;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            //type= Type.Secondary;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            //type = Type.Melee;
        }
        else if(Input.GetMouseButton(0))
        {
           if(!isCooldown)
            {
                GameObject _bullet;
                dir = Camera.main.ScreenPointToRay(Input.mousePosition).direction;
                ray = new Ray(firePos.position, dir);
                switch (type)
                {
                    case Type.Primary:
                        _bullet = Instantiate(bullets[0]);
                        break;
                    case Type.Secondary:
                        _bullet = Instantiate(bullets[1]);
                        break;
                    case Type.Melee:
                        _bullet = Instantiate(bullets[0]);
                        break;
                    default:
                        _bullet = Instantiate(bullets[0]);
                        break;
                }
                _bullet.transform.position = firePos.position;
                Bullet bb = _bullet.GetComponent<Bullet>();
                bb.SetDirection(dir);
                if (isPowerShot)
                {
                    bb.isPowerShot = true;
                    isPowerShot = false;
                    LoadFx();
                }
                timer = _bullet.GetComponent<Bullet>().coolDown;
                isCooldown = true;
            }
        }

        if(isCooldown)
        {
            timer -= Time.deltaTime;
            if (timer < 0) isCooldown = false;
        }
    }

    void LoadFx()
    {
        if(isPowerShot&&!isPowerShotFx)
        {
            isPowerShotFx = true;
            buffFx = Instantiate(fxList[0], this.transform);
        }
        if(!isPowerShot && isPowerShotFx)
        {
            isPowerShotFx = false;
            Destroy(buffFx.gameObject);
        }
    }
}
