using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThruWall : MonoBehaviour
{
    public Camera _cam;
    public Transform _sphereMask;
    public Transform _charLocation;

    public LayerMask _layerMask;
    public float _size = 4.0f;
    public float _dist = 4.0f;


    private void Update()
    {
        RaycastHit hit;
        //if (Physics.Raycast(_cam.transform.position, (_target.transform.position - _cam.transform.position).normalized, out hit, 2000.0f, _layerMask))
            if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 2000.0f, _layerMask))

            {
            Vector3 n = (_charLocation.position - _cam.transform.position);
            Vector3 c2h = hit.transform.gameObject.transform.position - _cam.transform.position;
            
            float c2char_Len = Vector3.Project(n, _cam.transform.forward).magnitude;
            float c2wall_Len = Vector3.Project(c2h, _cam.transform.forward).magnitude;
            if (c2char_Len - c2wall_Len > _dist)
            {
                _sphereMask.transform.localScale = Vector3.one * _size;
            }
            //if (Vector3.Distance(_charLocation.position, _cam.transform.position) > Vector3.Distance(hit.transform.position, _cam.transform.position))
            //{
            //    _sphereMask.transform.localScale = Vector3.one * _size;
            //}
            else
            {
                _sphereMask.transform.localScale = Vector3.zero;

            }
            //if (hit.collider.tag == "SphereMask")
            //{
            //    _target.transform.localScale = Vector3.zero;
            //}
            //else
            //{
            //    _target.transform.localScale = Vector3.one * 5.0f;

            //}
        }
        else
        {
            _sphereMask.transform.localScale = Vector3.zero;

        }

    }
}
