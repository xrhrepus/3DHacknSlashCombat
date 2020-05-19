using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    
    #region Fields
    //private InputControl _inputActions;
    [SerializeField] private Vector2 _readMovVal;

    [Header("CombatBehavior")]
    [SerializeField] private CombatBehavior _combatBehavior;

    //movement
    [Header("Movement")]
    [SerializeField] private CameraFocus _camFocus;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _initRigidbodyMass = 1.0f;

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
    public Vector3 currHorizonVelocityDir;//velocity on local X-Z plane, used by animator
    public float curVerticalSpeed = 0.0f;//current speed on world Y
    //public Vector3 currVerticalVelocity;//velocity on world Y, used to compute jump/gravity

    public bool isUserMoveInput { get; private set; } = false;
    public bool isReadyToMove  = true;

    //jump
    [Header("Jump")]
    [Tooltip("How many times player can jump before next time landed")]
    public int maxAirJump = 1;
    public int airJumpCount;

    public float jumpForce = 8.0f;
    public float gravityMag = 9.8f;
    public bool isGrounded = false;
    public bool isReadyToJump = false;
 
    //adjust collider position for foot postion in jump animation
    [SerializeField] private CapsuleCollider _characterCollider;
    [SerializeField] private Transform jumpUpGroundCheckPos;
    private float ground_jump_offset;//cache the y offset

    //ground Check Position
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private float groundCheckDist = 0.6f;
    [SerializeField] private LayerMask groundCheckLayer;


    //dodge
    [Header("Dodge")]
    private Vector2 dodgeDirection;
    public bool isReadyToDodge { get; set; } = true;
    public bool isDodging { get; private set; } = false;
    public float _dodgeSpeed  = 8.0f;
    public float _dodgeAnimationPlaybackSpeedMultiplier { get; set; } = 1.0f;

    //Animation
    [Header("Animation")]
    [SerializeField] private Animator _animator;
     #endregion

    #region Trivial
 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + currHorizonVelocityDir);
        Gizmos.DrawCube(transform.position + currHorizonVelocityDir, Vector3.one * 0.8f);

        Gizmos.color = Color.yellow;

        Vector3 test = currHorizonVelocityDir.normalized * currHorizonSpeed;
        test.y = _rigidbody.velocity.y;

        Gizmos.DrawLine(transform.position,(transform.position + test));
        Gizmos.DrawCube(transform.position + test, Vector3.one * 0.3f);
 


    }
    #endregion

    #region Inits
    private void Awake()
    {
        ////input controller
        //_inputActions = new InputControl();
        //_inputActions.PlayerControl.Move.performed += _move => { ReadMoveValue(_move.ReadValue<Vector2>());  };
        //_inputActions.PlayerControl.Jump.performed += _jump => JumpPerformed();
        //animator
        _animator.GetComponentInChildren<Animator>();
        //rb
        _rigidbody = GetComponent<Rigidbody>();

        //jump
        ground_jump_offset = Vector3.Distance(jumpUpGroundCheckPos.position, groundCheckPos.position);
        _rigidbody.mass = _initRigidbodyMass;
     }
 

    #endregion

    #region Updates
    private void FixedUpdate()
    {

        GroundCheck();


    }

    private void Update()
    {
        isUserMoveInput = true;

        if (_readMovVal.magnitude == 0)
        {
            isUserMoveInput = false;
        }

        MovePlayer();
        MoveSlowdown();

    }
    private void LateUpdate()
    {
        UpdateVelocity();
        UpdateAnimation();

    }

    #endregion
    #region Getter Setter
    public Transform GetTransform()
    {
        return this.gameObject.transform;
    }
    public void SetRigidbodyMass(float mass)
    {
        _rigidbody.mass = mass;
    }
    public void ResetRigidbodyMass()
    {
        _rigidbody.mass = _initRigidbodyMass;
    }

    #endregion

    #region Jump
    public void JumpPerformed()
    {
        JumpPrepare();
    }
    void JumpPrepare()
    {
        if (!isReadyToJump)
        {
            return;
        }
        //ground jump
        if (isGrounded)
        {
            _animator.SetTrigger("jump");
        }
        else // air jump
        {
            //TODO
        }

        isReadyToJump = false;
        isReadyToDodge = false;
    }

    //triggered by animation clip event
    public void ReadyToJump(bool ready)
    {
        isReadyToJump = ready;
    }

    public void JumpUp()
    {
        if (!isGrounded)
        {
            return;
        }
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Force);
     }
    public void JumpUp(float jForce)
    {
        if (!isGrounded)
        {
            return;
        }

        _rigidbody.AddForce(Vector3.up * jForce, ForceMode.Force);
    }

    public void Airborne_ForceLanding(float airborneLandingForce)
    {
   
        _rigidbody.AddForce(-Vector3.up * airborneLandingForce, ForceMode.VelocityChange);
    }

    public void JumpLanding()
    {
         SetHorizonSpeedZero();
        isReadyToDodge = true;
        _combatBehavior.ResetAttackTriggers();
      //  isReadyToJump = true;
    }
    #endregion

    #region Move,Speed
    public void IdlePoseStart()
    {
        Debug.Log("idps");
        SetHorizonSpeedZero();
        ReadyToJump(true);
        //isReadyToJump = true;
        isReadyToDodge = true;
        isReadyToMove = true;
    }
    public void RunPoseStart()
    {
        ReadyToJump(true);
        isReadyToDodge = true;
        isReadyToMove = true;
    }

    public void SetHorizonSpeedZero()
    {
        currHorizonSpeed = 0.0f;
        currHorizonVelocityDir = Vector3.zero;
    }
    public void SetMoveValue(Vector2 val)
    {
        _readMovVal = val;
    }
    public Vector2 GetMoveValue()
    {
        return _readMovVal;
    }
    //get desired dir according to cam look at
    public Vector3 GetDesiredCurrHorizonDirection()
    {
         return (_camFocus.horizonLookDir * _readMovVal.y + _camFocus.horizonLookRight * _readMovVal.x).normalized;
    }
    public void SetCurrHorizonSpeed(float spd)
    {
        currHorizonSpeed = spd;
    }
    public void SetCurrHorizonVelocityDirection(Vector3 dir)
    {
         currHorizonVelocityDir = dir;
    }
    public void RotateTowardDesireDirection()
    {
        Vector3 desireDir = GetDesiredCurrHorizonDirection();
        if (desireDir != Vector3.zero)
        {
            Quaternion dest = Quaternion.LookRotation(desireDir).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dest, maxTurningSpeed);
        }

    }
    public void Rotate_To_Cam()
    {
        //if (isUserMoveInput)
        //{
        //    //currHorizonVelocity.x = _readMovVal.x;
        //    //currHorizonVelocity.z = _readMovVal.y;
        //    currHorizonVelocity = Vector3.zero;
        //}
        RotateTowardDesireDirection();

    }
    public void Align_With_Cam()
    {
        transform.forward = _camFocus.horizonLookDir;
    }

    void MovePlayer()
    {
        if (!isReadyToMove || isDodging)
        {
            return;
        }

        Vector3 desireDir = (_camFocus.horizonLookDir * _readMovVal.y + _camFocus.horizonLookRight * _readMovVal.x).normalized;

        if (_combatBehavior.IsAiming && desireDir != Vector3.zero)
        {
            Debug.Log("1");
             Accelerate();
            Align_With_Cam();
            currHorizonVelocityDir = desireDir;
            return;
        }

        if (desireDir != Vector3.zero)
        {
             Accelerate();
            Quaternion dest = Quaternion.LookRotation(desireDir).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dest, maxTurningSpeed * Time.deltaTime);

            currHorizonVelocityDir = transform.forward;
            turningMag = GetRotateDirection(transform.rotation, dest);
            turningMag = Mathf.Abs(turningMag) > startTurningThreshold ? turningMag : 0.0f;

        }
 
    }

    void Accelerate()
    {
        if (isReadyToMove)
        {
            if (currHorizonSpeed < maxMoveSpeed)
            {
                currHorizonSpeed += acceleration * Time.fixedDeltaTime;
            }
        }

    }
    void Deccelerate()
    {
        //if (currHorizonSpeed > 0.0f)
        //{
        //    currHorizonSpeed -= acceleration * Time.fixedDeltaTime * 8.0f;
        //}
        //else
        {
            currHorizonSpeed = 0.0f;
         }
    }

    private float GetRotateDirection(Quaternion from, Quaternion to)
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

    #region Dodge
    public void DodgePerformed()
    {
 
        if (isReadyToDodge)
        {
            //if (desireDir != Vector3.zero)
            isReadyToDodge = false;
            isReadyToMove = false;
            isReadyToJump = false;
            isDodging = true;

            //DodgeMovement();
            _animator.SetTrigger("dodge");
            _animator.SetBool("isDodging", isDodging);
            _combatBehavior.ResetAnimatorSpeed();
            _combatBehavior.ResetAttackTriggers();
        }
    }

    public void DodgeMovement()
    {

        Vector3 desireDir = (_camFocus.horizonLookDir * _readMovVal.y + _camFocus.horizonLookRight * _readMovVal.x).normalized;
        currHorizonSpeed = _dodgeSpeed;
        if (desireDir != Vector3.zero)
        {
            Quaternion dest = Quaternion.LookRotation(desireDir).normalized;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, dest, maxTurningSpeed);
            
        }

 
    }

    //used by animation event
    public void DodgeCompelete()
    {
        isDodging = false;
        isReadyToDodge = true;
        isReadyToMove = true;
        isReadyToJump = true;
         SetHorizonSpeedZero();
        _animator.SetBool("isDodging", isDodging);

    }

    #endregion

    #region UpdateData
    void UpdateVelocity()
    {
        //Debug.Log("cv0 " + currHorizonVelocity);

        if (currHorizonVelocityDir == Vector3.zero)
        {
            currHorizonVelocityDir = transform.forward;
        }
        //Debug.Log("cv 1" + currHorizonVelocity);

        //currHorizonVelocityDir = transform.forward * currHorizonSpeed;
        //Debug.Log("fwd " + transform.forward);
        //currHorizonVelocity = new Vector3( currHorizonVelocity.x, 0.0f, currHorizonVelocity.z) * currHorizonSpeed /** Time.fixedDeltaTime*/;
        currHorizonVelocityDir = currHorizonVelocityDir.normalized * currHorizonSpeed ;

        currHorizonVelocityDir.y = _rigidbody.velocity.y;
       _rigidbody.velocity = currHorizonVelocityDir;


    }
    //if no move input, start to slow down
    void MoveSlowdown()
    {
        if (!isUserMoveInput && !isDodging && isReadyToMove)
        {
            turningMag = 0.0f;
            Deccelerate();
        }
    }
    void GroundCheck()
    {
        isGrounded = Physics.Raycast(groundCheckPos.position, -Vector3.up, groundCheckDist, groundCheckLayer);
        if (isGrounded)
        {
            airJumpCount = maxAirJump;
        }
 
    }
    void UpdateAnimation()
    {
 
        _animator.SetFloat("speed", currHorizonVelocityDir.magnitude);
        
        _animator.SetFloat("forward", currHorizonSpeed / maxMoveSpeed);
        _animator.SetFloat("turning", turningMag);
        _animator.SetFloat("ySpeed", _rigidbody.velocity.y);
        _animator.SetFloat("moveH",_readMovVal.x);
        _animator.SetFloat("moveV", _readMovVal.y);

        _animator.SetBool("isGrounded", isGrounded);
     }

    #endregion



}
