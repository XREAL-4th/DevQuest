using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField][Range(1f, 20f)] private float sensitivity = 20f;
    private float mouseX, mouseY;
    private Transform playerTransform;

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 400.0f;
    private bool _isRotating = false;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;//
        //원활한 Debugging을 위해 마우스 커서를 보이지 않도록 하였습니다, Play 중 Esc 키를 누르면 마우스를 볼 수 있습니다.
        Cursor.visible = false;
        playerTransform = transform.parent;
        //this.transform.localEulerAngles = new Vector3(0, 0, 0);

    }
    
    private void FixedUpdate()
    {

        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.lockState = CursorLockMode.Locked;

        if (!ClickBtn.IsPause)
        {

            if (Input.GetMouseButton(0)) _isRotating = true;

            if (_isRotating)
            {
                mouseX += Input.GetAxis("Mouse X") * sensitivity;
                playerTransform.rotation = Quaternion.Euler(new Vector3(0, mouseX, 0));

                mouseY += Input.GetAxis("Mouse Y") * sensitivity;
                mouseY = Mathf.Clamp(mouseY, -75f, 75f);
                transform.localRotation = Quaternion.Euler(new Vector3(-mouseY, 0, 0));
            }

        }
    }

}