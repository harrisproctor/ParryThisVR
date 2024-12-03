using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingrockpush : MonoBehaviour
{
    public int fireForce;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
         transform.rotation = Random.rotation;
         rb = gameObject.GetComponent<Rigidbody>();

         rb.AddForce(transform.forward*fireForce, ForceMode.Force);
    }

     private void OnCollisionEnter(Collision collision)
    {
        
     rb.AddForce(transform.forward*-1*fireForce, ForceMode.Force);      
      
        
    }
}
