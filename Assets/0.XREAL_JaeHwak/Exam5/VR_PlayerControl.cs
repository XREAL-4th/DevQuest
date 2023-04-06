using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class VR_PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private float speed = 5f;
    [HideInInspector] public bool RotationEitherThumbstick = false;
    public OVRCameraRig CameraRig;
    public float RotationAngle = 45.0f;
    private Vector3 moveDir;

    //
    [Header("Debug")]
    public bool landed = false;

    [Header("Preset Fields")]
    [SerializeField] private CapsuleCollider col;

    [Header("Settings")]
    [SerializeField][Range(1f, 10f)] private float moveSpeed;
    [SerializeField][Range(1f, 10f)] private float jumpAmount;

    IEnumerator coroutine;
    public float skill_coolTime;
    private float coolTime = 0;
    public TextMeshProUGUI cool_text;
    public GameObject skill_VFX;
    public Image JumpSkill_BG;

    private void Start()
    {
        cool_text.text = "ON";
        skill_VFX.SetActive(false);
        JumpSkill_BG.fillAmount = 0;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckLanded();
        UpdateInput();
        Turn();
        UpdateKey();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Turn()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft) ||
            (RotationEitherThumbstick && OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)))
        {
            transform.RotateAround(CameraRig.centerEyeAnchor.position, Vector3.up, -RotationAngle);
        }
        else if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight) ||
                 (RotationEitherThumbstick && OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight)))
        {
            transform.RotateAround(CameraRig.centerEyeAnchor.position, Vector3.up, RotationAngle);
        }
    }

    void UpdateInput()
    {
        Quaternion ort = CameraRig.centerEyeAnchor.rotation;
        Vector3 ortEuler = new Vector3(0f, ort.eulerAngles.y, 0f);
        ort = Quaternion.Euler(ortEuler);

        moveDir = Vector3.zero;
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        moveDir += ort * (primaryAxis.x * Vector3.right);
        moveDir += ort * (primaryAxis.y * Vector3.forward);
    }

    void UpdateKey()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("PrimaryIndexTrigger");
        }
/*        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("SecondaryIndexTrigger");
        }*/
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (coolTime == 0)
            {
                JumpSkill_BG.fillAmount = 1;
                coolTime = skill_coolTime;
                coroutine = Jump_up();
                CoroutineStart();
            }
        }
        if (coolTime != 0)
        {
            JumpSkill_BG.fillAmount -= 1 / skill_coolTime * Time.deltaTime;
            if (JumpSkill_BG.fillAmount <= 0)
            {
                JumpSkill_BG.fillAmount = 0;
            }
        }

    }

    //
    void CoroutineStart()
    {
        if (coroutine != null)
        {
            skill_VFX.SetActive(true);
            StartCoroutine(coroutine);
            StartCoroutine(cool_Time());
        }
    }
    IEnumerator cool_Time()
    {
        for (int i = 0; i < skill_coolTime; i++)
        {
            Debug.Log(skill_coolTime - i);
            coolTime = skill_coolTime - i;
            cool_text.text = coolTime.ToString();
            yield return new WaitForSeconds(1f);
            coolTime--;
            cool_text.text = "ON";
        }
        Debug.Log("쿨타임 종료");
    }


    IEnumerator Jump_up()
    {
        Debug.Log("Jump_up 실행");
        jumpAmount *= 2;
        yield return new WaitForSeconds(5f);
        Debug.Log("효과 종료, 쿨타임 시작");
        jumpAmount /= 2;
        skill_VFX.SetActive(false);
    }

    //speedUp 아이템 충돌 시
    public void speedChange(float speed)
    {
        moveSpeed += speed;
        if (moveSpeed <= 0) moveSpeed = 0.5f;
    }

    private void CheckLanded()
    {
        //발 위치에 작은 구를 하나 생성한 후, 그 구가 땅에 닿는지 검사한다.
        //1 << 3은 Ground의 레이어가 3이기 때문, << 는 비트 연산자
        var center = col.bounds.center;
        var origin = new Vector3(center.x, center.y - ((col.height - 1f) / 2 + 0.15f), center.z);
        landed = Physics.CheckSphere(origin, 0.45f, 1 << 3, QueryTriggerInteraction.Ignore);
    }

    //
    void Move()
    {
        rb.MovePosition(rb.position + moveDir * (speed * Time.fixedDeltaTime));
    }

    void RotatePlayerToHMD()
    {
        Transform root = CameraRig.trackingSpace;
        Transform centerEye = CameraRig.centerEyeAnchor;

        Vector3 prevPos = root.position;
        Quaternion prevRot = root.rotation;

        transform.rotation = Quaternion.Euler(0.0f, centerEye.rotation.eulerAngles.y, 0.0f);

        root.position = prevPos;
        root.rotation = prevRot;
    }
}