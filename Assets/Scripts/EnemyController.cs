using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject deadVFX;
    public GameObject debuffVFX;
    private GameObject Debuff;
    private bool debuffOn = false;

    int hp = 100;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0, 2f, 0);

    Canvas hpCanvas;
    Slider hpSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        SetHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = hp;

        if(hp==0){
            Fire.score += 5;
            Instantiate(deadVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (debuffOn)
        {
            //Debuff.transform.position = this.transform.position;

            /*if(Debuff==null){
              debuffOn=false;
              }
              else{
              Debuff.transform.position = this.transform.position;
              }*/
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet"){
            if (PowerUp.powerup)
            {
                Fire.score += 2;
                hp -= 40;
                PowerUp.powerup = false;
            }
            else
            {
                Fire.score += 1;
                hp -= 20;
            }
            Destroy(other.gameObject);
            if(hp!=0){
                debuffOn = true;
                Debuff = Instantiate(debuffVFX, transform);
                var scale = transform.localScale;
                var debuffScale = Debuff.transform.localScale;
                debuffScale.x /= scale.x;
                debuffScale.y /= scale.y;
                debuffScale.z /= scale.z;
                Debuff.transform.localScale = debuffScale;
                //StartCoroutine(DebuffDisappear());
            }
        }
    }

    /*IEnumerator DebuffDisappear()
    {
        yield return new WaitForSeconds(2f);
        debuffOn = false;
    }*/

    void SetHpBar()
    {
        hpCanvas = GameObject.Find("Enemy Hp Canvas").GetComponent<Canvas>();
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, hpCanvas.transform);
        hpSlider = hpBar.GetComponentInChildren<Slider>();

        var hpbarScript = hpBar.GetComponent<EnemyHPbar>();
        hpbarScript.targetTransform = this.gameObject.transform;
        hpbarScript.offset = hpBarOffset;

    }
}
