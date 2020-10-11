using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Transform : MonoBehaviour
{
    //
    [SerializeField]
    private Knight _knight;
    public Knight Knight { get => _knight; }

    [SerializeField]
    private Transform _transform;
    public Transform Transform { get => _transform; }

    [SerializeField]
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody { get => _rigidbody; }


    //
    [SerializeField]
    private float _speed = 0.0f;
    public float Speed { get => _speed; }
    [SerializeField]
    private float _turningSpeed;
    public float TurningSpeed { get => _turningSpeed; }

    [SerializeField][ReadOnly]
    private Vector3 _velocity;
    public Vector3 Velocity { get => _velocity; }

    [SerializeField][ReadOnly]
    private Vector3 _direction = Vector3.forward;
    public Vector3 Direction {  get => _direction; /*private set => _direction = value;*/  }


    //

    //
    /// <summary>
    /// use for normal walking running
    /// </summary>
    public void TurningTowardCameraLookAt()
    {
        Vector3 camForward = Knight.Camera.transform.TransformDirection(Vector3.forward);
        camForward.y = 0.0f;
        camForward = camForward.normalized;

        // Calculate target direction based on camera forward and direction key.
        Vector3 right = new Vector3(camForward.z, 0, -camForward.x);
        Vector2 inputDir = Knight.KnightInput.InputDirection;
        Vector3 targetDirection = camForward * inputDir.y + right * inputDir.x;




        //_direction = Knight.KnightInput.InputDirctionVector3;
        //Vector3 desireDir = GetDesiredCurrHorizonDirection();
        if (targetDirection != Vector3.zero)
        {
            Quaternion dest = Quaternion.LookRotation(targetDirection).normalized;
            Transform.rotation = Quaternion.RotateTowards(Transform.rotation, dest, TurningSpeed);
            _direction = Transform.forward;
            //Rigidbody.MoveRotation(dest);
        }

    }
    /// <summary>
    /// move character by rigidbody moveposition use character forward and speed
    /// </summary>
    public void MoveCharacter()
    {
        Rigidbody.MovePosition(Transform.position + Transform.forward * Speed * Time.fixedDeltaTime);
    }
    /// <summary>
    /// move character position by rigidbody moveposition
    /// </summary>
    public void MoveCharacter(Vector3 dir,float spd)
    {
        Rigidbody.MovePosition(Transform.position + dir * spd * Time.fixedDeltaTime);
    }

    public void RotateCharacter()
    {
    }

}
