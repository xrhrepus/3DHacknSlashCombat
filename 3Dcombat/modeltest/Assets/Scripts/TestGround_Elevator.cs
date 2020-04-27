using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGround_Elevator : MonoBehaviour
{
    public bool active = false;
    [SerializeField] private bool moving = false;
    [SerializeField] private bool goToTo = true;

    public Transform from;
    public Transform to;
    public float speed = 1.0f;


    // Update is called once per frame
    void Update()
    {
        if (active && !moving)
        {

            active = false;
            //transform.Translate((to.position - from.position).normalized * speed * Time.unscaledDeltaTime);
            StartCoroutine(Move());
        }
    }


    private IEnumerator Move()
    {
        moving = true;
        Vector3 dest = from.position;
        if (goToTo)
        {
            dest = to.position;
        }

        while (Vector3.Distance(transform.position,dest) > 0.1f)
        {
            Debug.Log("w");

            transform.Translate((dest - transform.position).normalized * speed * Time.unscaledDeltaTime);
            yield return null;

        }

        goToTo = goToTo ? false : true;
        moving = false;
         
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        active = true;
    //     }
    //}
}
