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

        float dy = MousePos.y - PlayerPos.y;
        float dx = MousePos.x - PlayerPos.x;
 
        float rotateDg = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        Vector3 Dir = MousePos;
        Dir.z = Camera.main.farClipPlane;
        Debug.Log(Dir);*/


        if( Input.GetMouseButton (0)){

            
            if(isFire==false){
                timeron=true;
                isFire = true;
                GameObject weapon = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Vector3 shooting = ray.direction;
                shooting = shooting.normalized * 2000;
                weapon.GetComponent<WeaponController>().Launch(shooting);
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
