using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private float speed = 5f;

    [HideInInspector] public bool RotationEitherThumbstick = false;
    public OVRCameraRig CameraRig;
    public float RotationAngle = 45.0f;
    private Vector3 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpdateInput();
        Turn();
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