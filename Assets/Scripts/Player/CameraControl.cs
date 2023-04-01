using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField][Range(1f, 20f)] private float sensitivity = 10f;
    private float mouseX, mouseY;

    private void Update()
    {
        if (TimeController.Main.paused) return;

        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, mouseX, 0));
        
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -75f, 75f);
        transform.localRotation = Quaternion.Euler(new Vector3(-mouseY, 0, 0));
    }
}