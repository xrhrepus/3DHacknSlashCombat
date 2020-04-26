using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCtrl : MonoBehaviour
{
    #region Fields
    private InputControl _inputActions;
    private Vector2 _readMovVal;

    //movement
    [Header("Movement")]
    [SerializeField] private CameraFocus _camFocus;
    [SerializeField] private CharacterController _characterController;

    [Tooltip("Speed of character turn around(degree)")]
    public float maxTurningSpeed = 3.0f;
    private float turningMag = 0.0f;//assigned to animator
    [Tooltip("Abs value of 0 ~ 3.14(pi) (radian) ")]
    [Range(0.0f, Mathf.PI)]
    public float startTurningThreshold = 0.6f;

    //speed
    public float maxMoveSpeed = 3.0f;
    public float acceleration = 1.0f;
    public float currHorizonSpeed = 0.0f;//current speed on X-Z plane
    public Vector3 currHorizonVelocity;//velocity on X-Z plane, used by animator
    public bool isMoving = false;

    //jump
    public float jumpForce = 8.0f;
    public float gravityMag = 9.8f;

    [Header("Animation")]
    [SerializeField] private Animator _animator;

    #endregion

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

    #region Inits
    private void Awake()
    {
        //input controller
        _characterController = GetComponent<CharacterController>();
        _inputActions = new InputControl();
        _inputActions.PlayerControl.Move.performed += _move => { _readMovVal = _move.ReadValue<Vector2>(); MovePlayer(); };
        _inputActions.PlayerControl.Jump.performed += _jump => Jump();
        //animator
        _animator.GetComponentInChildren<Animator>();


    }
    void Start()
    {
    }

    #endregion

    #region Updates
    private void FixedUpdate()
    {

        MoveSlowdown();
        Falling();

    }

    void Update()
    {
        UpdateAnimation();

    }
    private void LateUpdate()
    {

    }

    #endregion



    #region Jump
    void Jump()
    {
     
        _characterController.attachedRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);
    }
    #endregion

    #region Move,Speed
    void MovePlayer()
    {
        Vector3 desireDir = (_camFocus.horizonLookDir * _readMovVal.y + _camFocus.horizonLookRight * _readMovVal.x).normalized;


        if (desireDir != Vector3.zero)
        {
            isMoving = true;
            Accelerate();
            Quaternion dest = Quaternion.LookRotation(desireDir).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dest, maxTurningSpeed * Time.deltaTime);

            //turningMag = GetRotateDirection(prevDirection, transform.rotation);
            //turningMag = Mathf.Abs(turningMag) > startTurning ? turningMag : 0.0f;

            turningMag = GetRotateDirection(transform.rotation, dest);
            turningMag = Mathf.Abs(turningMag) > startTurningThreshold ? turningMag : 0.0f;

        }
        else
        {
            isMoving = false;
        }

        currHorizonVelocity = transform.forward * currHorizonSpeed;

        _characterController.Move(currHorizonVelocity * Time.deltaTime);

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

    float GetRotateDirection(Quaternion from, Quaternion to)
    {
        //https://forum.unity.com/threads/checking-rotation-direction.437670/

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

        float minDeg = (Mathf.Min(clockWise, counterClockWise)) * (Mathf.PI / 180f);

        return ((clockWise <= counterClockWise) ? 1.0f : -1.0f) * minDeg;
    }



    #endregion

    #region UpdateData
    void MoveSlowdown()
    {
        if (!isMoving)
        {
            turningMag = 0.0f;
            Deccelerate();
        }
        currHorizonVelocity = transform.forward * currHorizonSpeed;
    }
    void Falling()
    {
        if (!_characterController.isGrounded)
        {
            _characterController.Move(Vector3.down * gravityMag * Time.deltaTime);
        }
    }
    void UpdateAnimation()
    {
        _animator.SetFloat("speed", currHorizonVelocity.magnitude);
        _animator.SetFloat("forward", currHorizonVelocity.magnitude / maxMoveSpeed);
        _animator.SetFloat("turning", turningMag);
        
    }

    #endregion



}
