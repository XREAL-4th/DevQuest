using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textInfo; //스킬 시전 정보 출력
    [SerializeField]
    private TextMeshProUGUI textCooldownTime; // 쿨다운 시간 표시 Text UI
    [SerializeField]
    private Image imageCooldownTime; // 쿨다운 시간 나타내는 Image UI
    [SerializeField]
    private string skillName; // 스킬 이름
    [SerializeField]
    private float maxCooldownTime; // 최대 쿨타임 시간

    private float currentCooldownTime; // 현재 쿨타임 시간
    private bool isCooldown; // 현재 쿨타임이 적용중인지 체크


    private void Awake()
    {
        SetCooldownIs(false);
    }
    //외부에서 스킬 사용할때 호출하는 메소드
    public void StartCooldownTime()
    {
        //이미 스킬 사용해서 쿨타임 남아있으면 종료
        if (isCooldown == true)
        {
            textInfo.text = $"{skillName} CooldownTime : {currentCooldownTime.ToString("F1")}";
            return;
        }
        textInfo.text = $"Use Skill : {skillName}";

        StartCoroutine("OnCooldownTime", maxCooldownTime);

    }

    //실제 스킬 쿨타임 제어 코루틴 메소드
    private IEnumerator OnCooldownTime(float maxCooldownTime)
    {
        //쿨다운 시간 저장
        currentCooldownTime = maxCooldownTime;

        SetCooldownIs(true);

        while (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            //Image UI의 fillAmount를 조절해 채워지는 이미지 모양 설정
            imageCooldownTime.fillAmount = currentCooldownTime / maxCooldownTime;
            // Text UI에 쿨다운 시간 표시
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
