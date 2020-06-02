using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ThrowingOut : MonoBehaviour
{
    [SerializeField] private Player _player;
    //[SerializeField] private Rigidbody _rigidbody;
    //public Rigidbody Rigidbody { get => _rigidbody; }
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private Vector3 _destination;
    [Tooltip("weapon rotating speed")]
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _travelSpeed = 20.0f;
    
    [Tooltip("initial angle of weapon rotation around local X")]
    [SerializeField] private float _initTiltAngle = 35.0f;
    [Tooltip("initial angle between player forward and weapon init velocity")]
    [SerializeField] private Transform _initDir;
    [Tooltip("weapon will go straight toward to target if distance between them less than _minDistance")]
    [SerializeField] private float _minSteerDistance = 10f;
    [Tooltip("weapon stops traveling and move to destinationif distance between them less than _finishDistance")]
    [SerializeField] private float _finishDistance = 1.0f;

    [Header("Calling back to owner")]
    [SerializeField] private Transform _ownerTransform;
    [SerializeField] private bool _waitingForCall = false;
    public bool WaitingForCall { get => _waitingForCall; }
    [SerializeField] private bool _returningToHand = false;
    public bool ReturningToHand { get => _returningToHand; }

    [Header("Tracking Target")]
    [SerializeField] private Transform _targetTransform;

    [SerializeField] private float _maxSteerForce = 1.0f;
    [SerializeField] private bool _timerStart = false;
    [SerializeField] private float _timer = 0.0f;
    [SerializeField] private float _maxTime = 8.0f;
    [SerializeField] private bool _stop = true;
    [SerializeField] private bool _isTraveling = false;
    public bool IsStop { get => _stop; }
    public bool IsTraveling { get => _isTraveling; }

    [Header("Hit detect")]
    [SerializeField] private BoxCollider _insertCollider;
    [SerializeField] private BoxCollider _damageCollider;


    private void OnDrawGizmos()
    {
        //if (_destination != null)
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawCube(_destination, Vector3.one);

        //    Gizmos.color = Color.green;
        //    Gizmos.DrawLine(transform.position, transform.position + _velocity);
        //    Gizmos.DrawCube(transform.position + _velocity, Vector3.one * 0.5f);
        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawWireSphere(_destination, _minSteerDistance);

        //    Gizmos.color = Color.cyan;
        //    Gizmos.DrawLine(transform.position, transform.position + transform.forward * 4.0f);
 
 
        //}
    }
    public void ThrowingAttack(Vector3 destination)
    {
        SetDestination(destination);
        _stop = false;
        
        _velocity = _initDir.transform.forward * _travelSpeed;
        _damageCollider.enabled = true;
        StartCoroutine(SteerTravel());

    }
    public void ThrowingAttack_Tracking(Transform target)
    {
        _targetTransform = target;
        _stop = false;

        _velocity = _initDir.transform.forward * _travelSpeed;
        _damageCollider.enabled = true;

        StartCoroutine(SteerTravel_Tracking());

    }

    public void BackToHand(Transform owner)
    {
        if (!_isTraveling && _stop && _waitingForCall)
        {
            //gameObject.transform.SetParent(null);
            gameObject.transform.parent = null;

            _ownerTransform = owner;
            SetDestination(owner.position);
            _stop = false;
            _waitingForCall = false;
            _damageCollider.enabled = true;
            _returningToHand = true;
            _velocity = _initDir.transform.forward * _travelSpeed;
            StartCoroutine(SteerTravelBack());

        }

    }

    public void StopMoving()
    {
        _stop = true;
        _isTraveling = false;
        _timerStart = false;
        _timer = 0.0f;
        _velocity = Vector3.zero;
    }
    void SetDestination(Vector3 destination)
    {
        _destination = destination;
    }
    Vector3 ComputeVelocity(Vector3 vel , Vector3 dest)
    {
        Vector3 steer = (((dest - transform.position).normalized * _travelSpeed) - vel);
        return Vector3.ClampMagnitude(steer, _maxSteerForce);
    }
    IEnumerator SteerTravel()
    {
        _timer = 0.0f;
        _timerStart = true;

        _isTraveling = true;
        transform.Rotate(_initTiltAngle , 0.0f, 0.0f, Space.Self);

        while (Vector3.Distance(transform.position, _destination ) > _minSteerDistance && !_stop && (_timer < _maxTime))
        {
            transform.Rotate(0.0f, 0.0f, _rotateSpeed, Space.Self);
             _velocity += ComputeVelocity(_velocity, _destination )  * Time.fixedDeltaTime;
            yield return null;
        }
        while (Vector3.Distance(transform.position, _destination ) > _finishDistance && !_stop && (_timer < _maxTime))
        {
            _velocity = (_destination  - transform.position).normalized * _travelSpeed;
            yield return null;
        }
        if (Vector3.Distance(transform.position, _destination) < _finishDistance)
        {
            transform.position = _destination ;
        }
        _stop = true;
        _isTraveling = false;
        _timerStart = false;
        _velocity = Vector3.zero;
        _waitingForCall = true;
        _damageCollider.enabled = false;


        yield return null;
    }
    IEnumerator SteerTravel_Tracking()
    {
        _timer = 0.0f;
        _timerStart = true;

        _isTraveling = true;
        transform.Rotate(_initTiltAngle, 0.0f, 0.0f, Space.Self);

        while (Vector3.Distance(transform.position, _targetTransform.position) > _minSteerDistance && !_stop && (_timer < _maxTime))
        {
            transform.Rotate(0.0f, 0.0f, _rotateSpeed, Space.Self);
            _velocity += ComputeVelocity(_velocity, _targetTransform.position) * Time.fixedDeltaTime;
            yield return null;
        }
        while (Vector3.Distance(transform.position, _targetTransform.position) > _finishDistance && !_stop && (_timer < _maxTime))
        {
            _velocity = (_targetTransform.position - transform.position).normalized * _travelSpeed;
            yield return null;
        }
        if (Vector3.Distance(transform.position, _targetTransform.position) < _finishDistance)
        {
            transform.position = _targetTransform.position;
        }
        _stop = true;
        _isTraveling = false;
        _timerStart = false;
        _velocity = Vector3.zero;
        _waitingForCall = true;
        _damageCollider.enabled = false;

        yield return null;
    }

    IEnumerator SteerTravelBack()
    {
        _timer = 0.0f;
        _timerStart = true;

        _isTraveling = true;
        transform.Rotate(_initTiltAngle, 0.0f, 0.0f, Space.Self);

        while (Vector3.Distance(transform.position, _ownerTransform.position) > _minSteerDistance && !_stop && (_timer < _maxTime))
        {
            transform.Rotate(0.0f, 0.0f, _rotateSpeed, Space.Self);
            _velocity += ComputeVelocity(_velocity, _ownerTransform.position) * Time.fixedDeltaTime;
            yield return null;
        }
        while (Vector3.Distance(transform.position, _ownerTransform.position) > _finishDistance && !_stop && (_timer < _maxTime))
        {
            _velocity = (_ownerTransform.position - transform.position).normalized * _travelSpeed;
            yield return null;
        }
        if (Vector3.Distance(transform.position, _ownerTransform.position) < _finishDistance)
        {
            transform.position = _ownerTransform.position;
            _player.AddToNearbyWeapon(this.GetComponent<Weapon>());
            _player.EquipWeapon();
        }
        _stop = true;
        _isTraveling = false;
        _damageCollider.enabled = false;
        _timerStart = false;
        _velocity = Vector3.zero;
        _returningToHand = false;

        yield return null;
    }

    private void FixedUpdate()
    {
        if (_timerStart)
        {
            _timer += Time.fixedDeltaTime;
        }
        //if (!_stop)
        {
            transform.Translate(_velocity * Time.fixedDeltaTime,Space.World);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L) && _stop)
        //{
        //    Debug.Log("L");
        //    ThrowingAttack(_destination);
        //    //_stop = false;
        //    ////rigidbody.AddForce(Player.transform.forward * force);
        //    //StartCoroutine(Travel());
        // }
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    Debug.Log("m");
        //    _stop = true;
        //}


        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Debug.Log("P");
        //    //rigidbody.AddForce(Player.transform.forward * force);
        //    _velocity = _player.transform.forward * _travelSpeed;
        //}

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    Debug.Log("O");
        //    transform.position = _player.transform.position;
        //    _velocity = Vector3.zero;
        //}
        //if (Input.GetKey(KeyCode.I))
        //{
        //    Debug.Log("I");
        //    //transform.Rotate(new Vector3(0.0f,angle,0.0f),Space.World);
        //    //transform.RotateAround(transform.position, Vector3.up, _rotateSpeed);
        //    //_velocity = (Matrix4x4.Rotate(Quaternion.Euler(_initVelocityAngle)).MultiplyVector(_player.transform.forward)).normalized * _travelSpeed;
        //    //Quaternion.FromToRotation(transform.up, _destination - transform.position)
        //    //transform.r

        //    transform.rotation = Quaternion.Lerp(Quaternion.FromToRotation(transform.forward, _destination - transform.position), Quaternion.Euler(transform.forward), 0.3f) * transform.rotation;

        //}

    }
}
