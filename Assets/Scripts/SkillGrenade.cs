using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGrenade : MonoBehaviour
{
    //[SerializeField] private float damage = 30.0f;
    [SerializeField] GameObject grenadeObj; //����ź ������
    [SerializeField] GameObject grenadeVfx; //ȿ��
    [SerializeField] Transform grenadaPoint; //����ź ���� ��ġ
    bool skillAvailable = true;

    IEnumerator coroutine;


    private void Start()
    {
        coroutine = UseSkill();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q) && skillAvailable)
        {
            coroutine = UseSkill();
            StartCoroutine(coroutine);
        }
    }

    public void Grenade()
    {
        // RAYCASTHIT[] Physics.SphereCastAll(Vector3 origin, float radius, Vector3 direction, float maxDistance, int layerMask)

        var hits = Physics.SphereCastAll(transform.position, 15, Vector3.up, 0f);
        //var hits = Physics.SphereCastAll(transform.position, radius, Vector3.up, 0f);

  

    }

    IEnumerator UseSkill()
    {
        Grenade();

        skillAvailable = false;
        yield return new WaitForSeconds(10f);
        skillAvailable = true;
        yield break;


    }
}
