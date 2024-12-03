using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisondeflect : MonoBehaviour
{
    public string targetTag = "Bullet";
    public float fireForce;
    public Transform firePlace;
    public int speedmod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(targetTag) && enabled == true)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            

            float speed = Vector3.Magnitude(gameObject.GetComponent<Rigidbody>().velocity);
            rb.velocity = new Vector3(0, 0, 0);
            collision.transform.forward = firePlace.forward;
            rb.AddForce(firePlace.forward*(fireForce + (speed * speedmod)), ForceMode.Force);
        }
    }
}
