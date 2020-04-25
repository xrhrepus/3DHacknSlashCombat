using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCtrl : MonoBehaviour
{
    private InputControl _inputActions;
    private Vector2 _readMovVal;

    [Header("Movement")]
    [SerializeField] private CameraFocus _camFocus;
    [SerializeField] private CharacterController _characterController;
    public float maxRotationSpeed = 3.0f;
    public float turningMag = 0.0f;
    [Tooltip(" 0 ~ 1(pi) ")]
    public float startTurning = 0.6f;

    public float maxMoveSpeed = 3.0f;
    public float acceleration = 1.0f;
    public float currHorizonSpeed = 0.0f;
    public Vector3 currHorizonVelocity;
    public Quaternion prevDirection;
    public bool isMoving = false;
 

    public float jumpForce = 8.0f;
    public float gravityMag = 9.8f;

    [Header("Animation")]
    [SerializeField] private Animator _animator;

    #region Trivial
    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + currHorizonDir * 2.0f);
        //Gizmos.DrawCube(transform.position + currHorizonDir * 2.0f, Vector3.one * 0.5f);

        Gizmos.DrawLine(transform.position, transform.position + currHorizonVelocity);
        Gizmos.DrawCube(transform.position + currHorizonVelocity, Vector3.one * 0.5f);
    }
    #endregion

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputActions = new InputControl();
        _inputActions.PlayerControl.Move.performed += _move => { _readMovVal = _move.ReadValue<Vector2>(); MovePlayer(); };

        //
        _animator.GetComponentInChildren<Animator>();


    }
    void Start()
    {
    }



    private void FixedUpdate()
    {
        
        UpdatePhysicalData();

        if (!_characterController.isGrounded)
        {
            _characterController.Move(Vector3.down * gravityMag * Time.deltaTime);
         }




    }

    void Update()
    {
        UpdateAnimation();
        prevDirection = transform.rotation;
 
    }


    void MovePlayer()
    {
        Vector3 desireDir = (_camFocus.horizonLookDir * _readMovVal.y + _camFocus.horizonLookRight * _readMovVal.x).normalized;


        if (desireDir != Vector3.zero)
        {
            isMoving = true;
            Accelerate();
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(desireDir).normalized, maxRotationSpeed * Time.deltaTime);

            turningMag = GetRotateDirection(prevDirection, transform.rotation);
            turningMag = Mathf.Abs(turningMag) > startTurning ? turningMag : 0.0f;
           
 
        }
        else
        {
            isMoving = false;
        }

        currHorizonVelocity = transform.forward * currHorizonSpeed;

        _characterController.Move(currHorizonVelocity * Time.deltaTime);
        
    }
    void Jump()
    {

    }
    void Accelerate()
    {
        if (currHorizonSpeed < maxMoveSpeed)
        {
            currHorizonSpeed += acceleration * Time.deltaTime;
        }
    }
    void Deccelerate()
    {
        if (currHorizonSpeed > 0.0f)
        {
            currHorizonSpeed -= acceleration * Time.deltaTime * 8.0f;
        }
        else
        {
            currHorizonSpeed = 0.0f;
            //currHorizonDir = Vector3.zero;
        }
    }

    void UpdatePhysicalData()
    {
        if (!isMoving)
        {
            turningMag = 0.0f;
            Deccelerate();
        }
        currHorizonVelocity = transform.forward * currHorizonSpeed;
    }
    void UpdateAnimation()
    {
        _animator.SetFloat("speed", currHorizonVelocity.magnitude);
        _animator.SetFloat("forward", currHorizonVelocity.magnitude / maxMoveSpeed);
        _animator.SetFloat("turning", turningMag);
 
    }
    //float GetRotateDirection(Quaternion from, Quaternion to)
    //{
    //    float fromY = from.eulerAngles.y;
    //    float toY = to.eulerAngles.y;
    //    float clockWise = 0f;
    //    float counterClockWise = 0f;

    //    if (fromY <= toY)
    //    {
    //        clockWise = toY - fromY;
    //        counterClockWise = fromY + (358.0f - toY);
    //    }
    //    else
    //    {
    //        clockWise = (358.0f - fromY) + toY;
    //        counterClockWise = fromY - toY;
    //    }

    //    return ((clockWise <= counterClockWise ) ? 1.0f : -1.0f);
    //}

    float GetRotateDirection(Quaternion from, Quaternion to)
    {
        float fromY = from.eulerAngles.y;
        float toY = to.eulerAngles.y;
        float clockWise = 0f;
        float counterClockWise = 0f;

        if (fromY <= toY)
        {
            clockWise = toY - fromY;
            counterClockWise = fromY + (358.0f - toY);
        }
        else
        {
            clockWise = (358.0f - fromY) + toY;
            counterClockWise = fromY - toY;
        }
        //float deg = Mathf.Clamp( Quaternion.Angle(from, to),-1.0f,1.0f) /* * (Mathf.PI / 180f)*/;
        //float deg = Mathf.Clamp( Quaternion.Angle(from, to),-1.0f,1.0f) /* * (Mathf.PI / 180f)*/;

        //float deg = Mathf.Abs(Quaternion.Angle(from, to)) / Mathf.PI;
        //deg = Mathf.Abs(deg) < 0.8f ? 0f : Mathf.Abs(deg) < 1.0f ? deg : 1.0f;
        float minDeg = (Mathf.Min(clockWise, counterClockWise)) * (Mathf.PI / 180f);
        //Debug.Log("deg " + minDeg + "  rad" + minDeg * (180/Mathf.PI));
 
        return ((clockWise <= counterClockWise) ? 1.0f : -1.0f) * minDeg;
    }

    // New Function added here
    // assume you only care about the y Axis rotation
    // can change this to care about other Axis
    // return true if rotating clockwise
    // return false if rotating counterclockwise
    //bool GetRotateDirection(Quaternion from, Quaternion to)
    //{
    //    float fromY = from.eulerAngles.y;
    //    float toY = to.eulerAngles.y;
    //    float clockWise = 0f;
    //    float counterClockWise = 0f;

    //    if (fromY <= toY)
    //    {
    //        clockWise = toY - fromY;
    //        counterClockWise = fromY + (358.0f - toY);
    //    }
    //    else
    //    {
    //        clockWise = (358.0f - fromY) + toY;
    //        counterClockWise = fromY - toY;
    //    }
    //    return (clockWise <= counterClockWise);
    //}


}
