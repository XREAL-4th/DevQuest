using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusRigtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //OVRCameraRig를 찾습니다.
        OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
        if (cameraRig != null) {
            //OVRCameraRig 내 CenterEyeAnchor를 찾아서 가져옵니다.
            Transform centerEyeAnchor = cameraRig.transform.Find("TrackingSpace/CenterEyeAnchor");

            if (centerEyeAnchor != null) {
                //플레이어 시선 오브젝트의 위치와 회전 값을 CenterEyeAnchor로 설정합니다.
                transform.position = centerEyeAnchor.position;
                transform.rotation = centerEyeAnchor.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //OVRCameraRig를 찾습니다.
        OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
        if (cameraRig != null) {
            //OVRCameraRig 내 CenterEyeAnchor를 찾아서 가져옵니다.
            Transform centerEyeAnchor = cameraRig.transform.Find("TrackingSpace/CenterEyeAnchor");

            if (centerEyeAnchor != null) {
                //플레이어 시선 오브젝트의 위치와 회전 값을 CenterEyeAnchor로 설정합니다.
                transform.position = centerEyeAnchor.position;
                transform.rotation = centerEyeAnchor.rotation;
            }
        }
    }
}

/*
 * private void Start()
    {
        //원활한 Debugging을 위해 마우스 커서를 보이지 않도록 하였습니다, Play 중 Esc 키를 누르면 마우스를 볼 수 있습니다.
        Cursor.visible = false;
        playerTransform = transform.parent;
    }

    private void FixedUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        playerTransform.rotation = Quaternion.Euler(new Vector3(0, mouseX, 0));
        
        mouseY += Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -75f, 75f);
        transform.localRotation = Quaternion.Euler(new Vector3(-mouseY, 0, 0));
    }
 */
