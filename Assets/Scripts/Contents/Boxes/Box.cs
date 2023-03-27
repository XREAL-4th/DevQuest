using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Box : MonoBehaviour, IHealthy
{
    [SerializeField] private float health = 10;
    [SerializeField] private GameObject idleBox, destroyedBox;
    public BoxType type;

    private Animator currentAnimator;

    public float Health { get => health; set => health = value; }

    private void Awake()
    {
        Health = type.maxHelath;
        currentAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Health <= 0 && !currentAnimator.GetBool("isCrashed")) OnCrashed();
    }

    protected virtual void OnCrashed()
    {
        currentAnimator.SetBool("isCrashed", true);
        idleBox.SetActive(false);
        destroyedBox.SetActive(true);
    }
}
