using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �����Ϳ��� ���� ����� �� �ֵ��� �޴��� ����
[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object Asset/ItemData")]
public class ItemData : ScriptableObject
{
    public string ItemName; //������ �̸�
    public int affectAttack = 5; //������ ������ ���ݷ¿� ��ŭ ������ �ִ���
    public GameObject effect; //VFX

}