using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batbehavior : MonoBehaviour
{
    public Transform playerloc;
    Vector3 targetDirection;
    public float speed;
    public float turnspeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = gameObject.GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        targetDirection = playerloc.position - transform.position;
       transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,  targetDirection, turnspeed, 0.0f));
     
         rb.AddForce(transform.forward*speed, ForceMode.Force);
       //transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
       //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
