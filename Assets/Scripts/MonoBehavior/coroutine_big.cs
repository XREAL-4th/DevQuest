using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutine_big : MonoBehaviour
{
    Vector3 chg_Scale;
    Coroutine coroutine;
    public GameObject hitfx;
    // Start is called before the first frame update
    void Start()
    {
        chg_Scale = GetComponent<Transform>().localScale;
        print(chg_Scale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && coroutine == null){
            print("Start update");
            StartCoroutine(Bigger());
        }
    }

    IEnumerator Bigger(){
        for(int i=0; i < 100; i++){
            print("Bigger!");
            //chg_Scale += (0.02f, 0.02f, 0.02f);
            chg_Scale.x += 0.02f;
            chg_Scale.y += 0.02f;
            chg_Scale.z += 0.02f;
            GetComponent<Transform>().localScale = chg_Scale;
            Instantiate(hitfx, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(hitfx);
        yield return new WaitForSeconds(10f);
        for(int i=0; i < 100; i++){
            print("Smaller!");
            //chg_Scale += (0.02f, 0.02f, 0.02f);
            chg_Scale.x -= 0.02f;
            chg_Scale.y -= 0.02f;
            chg_Scale.z -= 0.02f;
            GetComponent<Transform>().localScale = chg_Scale;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
