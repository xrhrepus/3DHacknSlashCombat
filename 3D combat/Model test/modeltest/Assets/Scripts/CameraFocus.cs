using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFocus : MonoBehaviour
{

    public Transform _target;
    public Camera _cam;
    public float horizonRotationSpeed = 5.0f;
    public float verticalRotaionSpeed = 2.0f;
    
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

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(_cam.transform.position,  _cam.transform.position + _cam.transform.forward * 5.0f);
        //Gizmos.DrawCube(_cam.transform.position + _cam.transform.forward * 5.0f, new Vector3(1.0f, 1.0f, 1.0f));
        Gizmos.DrawLine(_cam.transform.position, _cam.transform.position + horizonLookDir * 5.0f);
        Gizmos.DrawCube(_cam.transform.position + horizonLookDir * 5.0f, Vector3.one * 0.2f);


    }
    // Update is called once per frame
    void Update()
    {
        transform.position = _target.position;
        horizonLookDir = new Vector3(_cam.transform.forward.x, 0.0f, _cam.transform.forward.z).normalized;
        horizonLookRight = new Vector3(_cam.transform.right.x, 0.0f, _cam.transform.right.z).normalized;
    }

    void MoveCam(Vector2 input)
    {
        //Quaternion q = Quaternion.FromToRotation(transform.rotation.eulerAngles, new Vector3(input.y * verticalRotaionSpeed, input.x * horizonRotationSpeed, 0.0f));
        if (input != Vector2.zero)
        {
            transform.Rotate(Vector3.up * input.x * horizonRotationSpeed );
            //transform.Translate(Vector3.up * input.y * verticalRotaionSpeed * Time.deltaTime);
            //Quaternion q = Quaternion.AngleAxis(input.x * horizonRotationSpeed,Vector3.up);
            //transform.Rotate(q.eulerAngles);
        }

        

        //transform.Rotate(new Vector3(0.0f, input.x * horizonRotationSpeed, 0.0f));

    }
}
