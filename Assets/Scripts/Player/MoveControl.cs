using Assets.Scripts.Utils.Keybind;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveControl : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private CapsuleCollider col;
    
    [Header("Settings")]
    [SerializeField][Range(1f, 10f)] private float moveSpeed;
    [SerializeField][Range(1f, 10f)] private float jumpAmount;
    
    [Header("Debug")]
    public bool landed = false;
    public bool moving = false;

    private int jumpKeybindID, moveKeybindID;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        
        //FSM 부수고 EDD하기!
        KeyBindManager.Instance
            .Bind(KeyCode.Space)
            .Then(() =>
            {
                if (IsLanded()) Jump();
            })
            .GetID(out jumpKeybindID)
            .Bind(KeyCodeUtils.Horizontal)
                .Or(KeyCodeUtils.Vertical)
                .Then((KeyCode[] codes) =>
                {
                    Move(codes);
                })
            .GetID(out moveKeybindID);
    }

    private void OnDestroy()
    {
        KeyBindManager.Instance.UnBind(jumpKeybindID, moveKeybindID);
    }

    private void Jump()
    {
        Vector3 vel = rigid.velocity;
        vel.y = jumpAmount;
        rigid.velocity = vel;
    }

    private bool IsLanded() {
        Vector3 center = col.bounds.center;
        Vector3 origin = new(center.x, center.y - ((col.height - 1f) / 2 + 0.15f), center.z);
        return Physics.CheckSphere(origin, 0.45f, 1 << 3, QueryTriggerInteraction.Ignore);
    }

    void Move(KeyCode[] codes)
    {
        Vector2 xz = new();

        foreach (KeyCode code in codes)
        {
            Vector2 res = code switch
            {
                KeyCode.A or KeyCode.LeftArrow => new(-1, 0),
                KeyCode.D or KeyCode.RightArrow => new(1, 0),
                KeyCode.W or KeyCode.UpArrow => new(0, 1),
                KeyCode.S or KeyCode.DownArrow => new(0, -1),
                _ => throw new NotImplementedException(),
            };
            if (xz.x == 0) xz.x = res.x;
            if (xz.y == 0) xz.y = res.y;
        }
        Vector3 movement = new(xz[0], 0f, xz[1]);
        movement.Normalize();
        transform.Translate(moveSpeed * Time.deltaTime * movement);
    }
}
