using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textInfo; //��ų ���� ���� ���
    [SerializeField]
    private TextMeshProUGUI textCooldownTime; // ��ٿ� �ð� ǥ�� Text UI
    [SerializeField]
    private Image imageCooldownTime; // ��ٿ� �ð� ��Ÿ���� Image UI
    [SerializeField]
    private string skillName; // ��ų �̸�
    [SerializeField]
    private float maxCooldownTime; // �ִ� ��Ÿ�� �ð�

    private float currentCooldownTime; // ���� ��Ÿ�� �ð�
    private bool isCooldown; // ���� ��Ÿ���� ���������� üũ


    private void Awake()
    {
        SetCooldownIs(false);
    }
    //�ܺο��� ��ų ����Ҷ� ȣ���ϴ� �޼ҵ�
    public void StartCooldownTime()
    {
        //�̹� ��ų ����ؼ� ��Ÿ�� ���������� ����
        if (isCooldown == true)
        {
            textInfo.text = $"{skillName} CooldownTime : {currentCooldownTime.ToString("F1")}";
            return;
        }
        textInfo.text = $"Use Skill : {skillName}";

        StartCoroutine("OnCooldownTime", maxCooldownTime);

    }

    //���� ��ų ��Ÿ�� ���� �ڷ�ƾ �޼ҵ�
    private IEnumerator OnCooldownTime(float maxCooldownTime)
    {
        //��ٿ� �ð� ����
        currentCooldownTime = maxCooldownTime;

        SetCooldownIs(true);

        while (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            //Image UI�� fillAmount�� ������ ä������ �̹��� ��� ����
            imageCooldownTime.fillAmount = currentCooldownTime / maxCooldownTime;
            // Text UI�� ��ٿ� �ð� ǥ��
            textCooldownTime.text = currentCooldownTime.ToString("F1");

            yield return null;
        }

        SetCooldownIs(false);
    }

    private void SetCooldownIs(bool boolean)
    {
        isCooldown = boolean;
        textCooldownTime.enabled = boolean;
        imageCooldownTime.enabled = boolean;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
