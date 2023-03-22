using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //bullet변수
    public GameObject bulletPrefab;

    bool isFire = false;
    bool timeron = false;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*WeaponController weaponController;
        Vector3 PlayerPos = GetComponent<Rigidbody>().position;
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Dir = MousePointShoot.targetPos;

        float dy = MousePos.y - PlayerPos.y;
        float dx = MousePos.x - PlayerPos.x;
 
        float rotateDg = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;*/


        if( Input.GetMouseButton (0)){
            /*GameObject weapon = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, rotateDg));

            weaponController = weapon.GetComponent<WeaponController>();
 
            weaponController.Launch(Dir.normalized, 900);*/
            if(isFire==false){
                timeron=true;
                isFire = true;
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
            
            if(time>=1){
                timeron=false;
                time=0;
                isFire=false;
                
            }
            
        }

        if(timeron==true){
            time += Time.deltaTime;
        }
    }
}
