using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFocus : MonoBehaviour
{

    public Transform _target;
    public Camera _cam;
    public float horizonRotationSpeed = 5.0f;
    public float verticalRotaionSpeed = 2.0f;
    [SerializeField] private float verticalMaxAngle = 60.0f;
    private float verticalMaxAngle_Rad = 60.0f * Mathf.Deg2Rad;

    [SerializeField] private InputControl _inputActions;

    public Vector3 horizonLookDir { get; set; }
    public Vector3 horizonLookRight { get; set; }

    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Awake()
    {
        _cam.transform.LookAt(transform.position);
        _inputActions = new InputControl();

        _inputActions.PlayerControl.RotateCam.performed += _rotCam => MoveCam(_rotCam.ReadValue<Vector2>());
        verticalMaxAngle_Rad = verticalMaxAngle * Mathf.Deg2Rad;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
         Gizmos.DrawLine(_cam.transform.position, _cam.transform.position + horizonLookDir * 5.0f);
        Gizmos.DrawCube(_cam.transform.position + horizonLookDir * 5.0f, Vector3.one * 0.2f);


    }
    // Update is called once per frame
    void Update()
    {
        transform.position = _target.position;
        horizonLookDir = new Vector3(_cam.transform.forward.x, 0.0f, _cam.transform.forward.z).normalized;
        horizonLookRight = new Vector3(_cam.transform.right.x, 0.0f, _cam.transform.right.z).normalized;

        float angle = transform.eulerAngles.x;
        angle = (angle > 180.0f) ? angle - 360.0f : angle;
        if (Mathf.Abs(angle) > verticalMaxAngle)
        {
            transform.eulerAngles = new Vector3( (verticalMaxAngle * (angle >= 0.0f ? 1.0f : -1.0f)), transform.eulerAngles.y, transform.eulerAngles.z);
            //transform.eulerAngles = new Vector3((verticalMaxAngle), transform.eulerAngles.y, transform.eulerAngles.z);

        }

    }

    void MoveCam(Vector2 input)
    {
         if (input != Vector2.zero)
        {
            //transform.Rotate(Vector3.up * input.x * horizonRotationSpeed );
            //transform.Rotate(transform.up * input.x * horizonRotationSpeed,Space.World);
            transform.Rotate(Vector3.up, input.x * horizonRotationSpeed * Time.deltaTime, Space.World);
             float angle = transform.eulerAngles.x;
            angle = (angle > 180.0f) ? angle - 360.0f : angle;

            if (Mathf.Abs(angle) <= verticalMaxAngle)
            {
                 //transform.Rotate( transform.InverseTransformDirection(transform.right) * input.y * verticalRotaionSpeed, Space.World);
                //transform.Rotate(transform.InverseTransformDirection(transform.right) , input.y * verticalRotaionSpeed * Time.deltaTime, Space.World);
                transform.Rotate( transform.right , input.y * verticalRotaionSpeed * Time.deltaTime, Space.World);


            }
 

        }
 
    }
}
