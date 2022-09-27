using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 4f;
    [SerializeField] float stopingDist = 2f;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            //if (Vector3.Distance(target.position, transform.position) > stopingDist)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target.position,speed*Time.fixedDeltaTime);
                rb.MovePosition(pos);
                transform.LookAt(target);
            }
        }
    }


}
