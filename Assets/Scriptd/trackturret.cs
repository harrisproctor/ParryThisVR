using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackturret : MonoBehaviour
{
    public GameObject prefabBall;
    public float fireForce;
    public Transform firePlace;
    public Transform playerloc;
   // public float xoff;
   // public float xoff;
   // public float yoff;
    //public float zoff;
    public Animator m_Animator;
    public float throwDelay;
    public int starttime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Throw", starttime, 4f);
    }

    void Update()
    {
        transform.LookAt(playerloc);
    }

    void Throw(){
    //transform.LookAt(playerloc);
         //Send the message to the Animator to activate the trigger parameter named "Jump"
         m_Animator.Play("Act",0,0.0f);
         Invoke("Shoot",throwDelay);
    }

    void Shoot()
    {
        // transform.LookAt(playerloc);
         //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + xoff, transform.rotation.eulerAngles.y + yoff, transform.rotation.eulerAngles.z + zoff);
         firePlace.LookAt(playerloc);
    
    
         GameObject shotIn = Instantiate(prefabBall, firePlace.position, transform.rotation);
         Rigidbody rb = shotIn.GetComponent<Rigidbody>();

         rb.AddForce(firePlace.forward*fireForce, ForceMode.Force);
         Destroy(shotIn,8);
    }
}
