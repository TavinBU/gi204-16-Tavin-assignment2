using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveRB : MonoBehaviour
{
   

    public Rigidbody rb;
    public float enginePowerThrust, liftBooster, drag, angularDrag;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //1
        if (Input.GetKey(KeyCode.Space)) 
        {
            rb.AddForce(transform.forward * enginePowerThrust);
        }

        //2
        Vector3 lift = Vector3.Project(rb.velocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        //3
        rb.drag = rb.velocity.magnitude * drag;
        rb.angularDrag = rb.velocity.magnitude * angularDrag;

        //4
        //4.1
        rb.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1);

        //4.2
        rb.AddTorque(Input.GetAxis("Vertical") * transform.right);
    }
}