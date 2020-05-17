using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_ThrowingOut : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _destination;
    [Tooltip("weapon rotating speed")]
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _travelSpeed = 20.0f;
    [Tooltip("initial angle between player forward and weapon init velocity")]
    [SerializeField] private float _initAngle = 0.17f;
    [Tooltip("weapon will go straight toward to target if distance between them less than _minDistance")]
    [SerializeField] private float _minSteerDistance = 10f;
    [Tooltip("weapon stops traveling and move to destinationif distance between them less than _finishDistance")]
    [SerializeField] private float _finishDistance = 1.0f;

    [SerializeField] private float _maxSteerForce = 1.0f;

    [SerializeField] private bool _stop = true;
    [SerializeField] private bool _isTraveling = false;
    public bool IsStop { get => _stop; }
    public bool IsTraveling { get => _isTraveling; }

    private void OnDrawGizmos()
    {
        if (_destination != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(_destination.position, Vector3.one);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + _rigidbody.velocity);
            Gizmos.DrawCube(transform.position + _rigidbody.velocity, Vector3.one * 0.5f);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_destination.position, _minSteerDistance);
        }
    }
    public void ThrowingAttack(Transform destination)
    {
        SetDestination(destination);
        _stop = false;
        StartCoroutine(Travel());
    }
    void SetDestination(Transform destination)
    {
        _destination = destination;
    }
    Vector3 ComputeVelocity(Vector3 vel , Vector3 dest)
    {
        Vector3 steer = (((dest - transform.position).normalized * _travelSpeed) - vel);
        return Vector3.ClampMagnitude(steer, _maxSteerForce);
    }
    IEnumerator Travel()
    {
        _isTraveling = true;
        while (Vector3.Distance(transform.position, _destination.position) > _minSteerDistance && !_stop)
        {
            transform.RotateAround(transform.position, Vector3.up, _rotateSpeed);
            _rigidbody.velocity += ComputeVelocity(_rigidbody.velocity, _destination.position)  * Time.fixedDeltaTime;
            yield return null;
        }
        while (Vector3.Distance(transform.position, _destination.position) > _finishDistance && !_stop)
        {
            _rigidbody.velocity = (_destination.position - transform.position).normalized * _travelSpeed;
            yield return null;
        }
        _stop = true;
        _isTraveling = false;
        transform.position = _destination.position;
        _rigidbody.velocity = Vector3.zero;
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && _stop)
        {
            Debug.Log("L");
            ThrowingAttack(_destination);
            //_stop = false;
            ////rigidbody.AddForce(Player.transform.forward * force);
            //StartCoroutine(Travel());
         }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("m");
            _stop = true;
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            //rigidbody.AddForce(Player.transform.forward * force);
            _rigidbody.velocity = _player.transform.forward * _travelSpeed;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("O");
            transform.position = _player.transform.position;
            _rigidbody.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("I");
            //transform.Rotate(new Vector3(0.0f,angle,0.0f),Space.World);
            transform.RotateAround(transform.position, Vector3.up, _rotateSpeed);
        }

    }
}
