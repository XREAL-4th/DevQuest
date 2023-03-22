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

    private float timer;
    private bool isCooldown = false;

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
        if(Input.GetKeyDown(KeyCode.Alpha1))
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
                _bullet.GetComponent<Bullet>().SetDirection(dir);
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
}
