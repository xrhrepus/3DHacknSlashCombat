using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCtrl : MonoBehaviour
{
    
    #region Fields
    private InputControl _inputActions;
    [SerializeField] private Vector2 _readMovVal;

    //movement
    [Header("Movement")]
    [SerializeField] private CameraFocus _camFocus;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Rigidbody _rigidbody;

    [Tooltip("Speed of character turn around(degree)")]
    public float maxTurningSpeed = 3.0f;
    private float turningMag = 0.0f;//assigned to animator
    [Tooltip("Abs value of 0 ~ 3.14(pi) (radian) ")]
    [Range(0.0f, Mathf.PI)]
    public float startTurningThreshold = 0.6f;

    //speed
    public float maxMoveSpeed = 3.0f;
    public float acceleration = 1.0f;
    public float currHorizonSpeed = 0.0f;//current speed on local X-Z plane
    public Vector3 currHorizonVelocity;//velocity on local X-Z plane, used by animator
    public float curVerticalSpeed = 0.0f;//current speed on world Y
    //public Vector3 currVerticalVelocity;//velocity on world Y, used to compute jump/gravity

    public bool isUserMoveInput = false;

    //jump
    [Tooltip("How many times player can jump before next time landed")]
    public int maxAirJump = 1;
    public int airJumpCount;

    public float jumpForce = 8.0f;
    public float gravityMag = 9.8f;
    public bool isGrounded = false;
    private bool isReadyToJump = false;

    //adjust collider position for foot postion in jump animation
    [SerializeField] private CapsuleCollider _characterCollider;
    [SerializeField] private Transform jumpUpGroundCheckPos;
    private float ground_jump_offset;//cache the y offset
    //
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private float groundCheckDist = 0.6f;
    [SerializeField] private LayerMask groundCheckLayer;


    [Header("Animation")]
    //[SerializeField] private Animator _animator;
    [SerializeField] private UnityChanAnimationControl _UCAnimControl;
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
        Gizmos.DrawCube(transform.position + currHorizonVelocity, Vector3.one * 0.2f);
    }
    #endregion

    #region Inits
    private void Awake()
    {
        //input controller
        _characterController = GetComponent<CharacterController>();
        _inputActions = new InputControl();
        _inputActions.PlayerControl.Move.performed += _move => {_readMovVal = _move.ReadValue<Vector2>();  };
        _inputActions.PlayerControl.Jump.performed += _jump => JumpPrepare();
        //animator
        _UCAnimControl.GetComponentInChildren<UnityChanAnimationControl>();
        //rb
        _rigidbody = GetComponent<Rigidbody>();

        //jump
        ground_jump_offset = Vector3.Distance(jumpUpGroundCheckPos.position, groundCheckPos.position);


    }
    void Start()
    {
        
    }

    #endregion

    #region Updates
    private void FixedUpdate()
    {
        MoveSlowdown();
        GroundCheck();
        UpdateVelocity();

    }

    private void Update()
    {
        UpdateAnimation();

    }
    private void LateUpdate()
    {
        if (_readMovVal.magnitude == 0)
        {
            isUserMoveInput = false;
        }
        MovePlayer();
    }

    #endregion



    #region Jump
    void JumpPrepare()
    {
        if (!isReadyToJump)
        {
            return;
        }
        //ground jump
        if (isGrounded)
        {
            _UCAnimControl.SetParamTrigger("jump");
        }
        else // air jump
        {
            //TODO
        }

        isReadyToJump = false;

    }

    //triggered by animation clip event
    public void ReadyToJump(bool ready)
    {
        isReadyToJump = ready;
    }

    public void Jump()
    {
        if (!isGrounded)
        {
            return;
        }
        //_characterCollider.height -= ground_jump_offset;
        //groundCheckPos.Translate(Vector3.up * ground_jump_offset);

        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        //_animator.SetTrigger("jump");
         //curVerticalSpeed += Mathf.Sqrt(2.0f * gravityMag * jumpForce * Time.deltaTime);
     }
    public void JumpLanding()
    {
 
        currHorizonSpeed = 0.0f;
        currHorizonVelocity = Vector3.zero;
        //_characterCollider.height += ground_jump_offset;
        //groundCheckPos.Translate(-Vector3.up * ground_jump_offset);
        
    }
    #endregion

    #region Move,Speed
    void MovePlayer()
    {
        //if (!isGrounded)
        //{
        //     return;
        //}

        Vector3 desireDir = (_camFocus.horizonLookDir * _readMovVal.y + _camFocus.horizonLookRight * _readMovVal.x).normalized;


        if (desireDir != Vector3.zero)
        {
            isUserMoveInput = true;
            Accelerate();
            Quaternion dest = Quaternion.LookRotation(desireDir).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dest, maxTurningSpeed * Time.deltaTime);

            //turningMag = GetRotateDirection(prevDirection, transform.rotation);
            //turningMag = Mathf.Abs(turningMag) > startTurning ? turningMag : 0.0f;

            turningMag = GetRotateDirection(transform.rotation, dest);
            turningMag = Mathf.Abs(turningMag) > startTurningThreshold ? turningMag : 0.0f;

        }
 

        //currHorizonVelocity = transform.forward * currHorizonSpeed;
        ////_characterController.Move(currHorizonVelocity * Time.deltaTime);
        //currHorizonVelocity.y = _rigidbody.velocity.y;
        // _rigidbody.velocity = currHorizonVelocity;
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
    void UpdateVelocity()
    {
        currHorizonVelocity = transform.forward * currHorizonSpeed;
        currHorizonVelocity.y = _rigidbody.velocity.y;
        //_characterController.Move(currHorizonVelocity * Time.deltaTime);
        _rigidbody.velocity = currHorizonVelocity;

    }
    //if no move input, start to slow down
    void MoveSlowdown()
    {
        if (!isUserMoveInput)
        {
            turningMag = 0.0f;
            Deccelerate();
        }
        //currHorizonVelocity = transform.forward * currHorizonSpeed; // already computed in UpdateVelocity()
    }
    void GroundCheck()
    {
        isGrounded = Physics.Raycast(groundCheckPos.position, -Vector3.up, groundCheckDist, groundCheckLayer);
        if (isGrounded)
        {
            airJumpCount = maxAirJump;
        }
        //if (!_characterController.isGrounded)//if airborne
        //{
        //    curVerticalSpeed += -gravityMag * Time.deltaTime;
        //    _characterController.Move(Vector3.down * curVerticalSpeed * Time.deltaTime);
        //}
    }
    void UpdateAnimation()
    {
        //_animator.SetFloat("speed", currHorizonVelocity.magnitude);
        //_animator.SetFloat("forward", currHorizonVelocity.magnitude / maxMoveSpeed);
        //_animator.SetFloat("turning", turningMag);
        //_animator.SetFloat("ySpeed", _rigidbody.velocity.y);

        //_animator.SetBool("isGrounded", isGrounded);
        _UCAnimControl.SetParamFloat("speed", currHorizonVelocity.magnitude);
        _UCAnimControl.SetParamFloat("forward", currHorizonVelocity.magnitude / maxMoveSpeed);
        _UCAnimControl.SetParamFloat("turning", turningMag);
        _UCAnimControl.SetParamFloat("ySpeed", _rigidbody.velocity.y);

        _UCAnimControl.SetParamBool("isGrounded", isGrounded);
        


    }

    #endregion



}
