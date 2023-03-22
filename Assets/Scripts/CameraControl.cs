using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField][Range(1f, 20f)] private float sensitivity = 20f;
    private float mouseX, mouseY, xRotate, yRotate;
    private Transform playerTransform;
    public float rotateSpeed = 500.0f;
    public float speed = 5.0f;
    private void Start()
    {
        //원활한 Debugging을 위해 마우스 커서를 보이지 않도록 하였습니다, Play 중 Esc 키를 누르면 마우스를 볼 수 있습니다.
        Cursor.visible = false;
        playerTransform = transform.parent;
    }

    private void FixedUpdate()
    {   

        /*
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        playerTransform.rotation = Quaternion.Euler(new Vector3(0, mouseX, 0));
        
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -75f, 75f);
        transform.localRotation = Quaternion.Euler(new Vector3(-mouseY, 0, 0));
        */

        
        mouseX = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        mouseY = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
        yRotate = transform.eulerAngles.y + mouseY;
        xRotate += mouseX;

        xRotate = Mathf.Clamp(xRotate, -90, 90);
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        
        /*
        mouseX = (Input.mousePosition.x / Screen.width ) - 0.5f;
        mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        transform.localRotation = Quaternion.Euler (new Vector4 (-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
        */
        /*
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));
        transform.position = Vector3.Lerp(transform.position, worldPos, speed * Time.deltaTime);
        */
    }
}