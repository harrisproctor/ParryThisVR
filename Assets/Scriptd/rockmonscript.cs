using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockmonscript : MonoBehaviour
{
   public GameObject prefabBall;
    public float fireForce;
    public Transform firePlace;
    public Transform playerloc;
    Animator m_Animator;
    public string aniname;
    public float throwDelay;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();

        InvokeRepeating("Throw", 3.0f, 3.0f);
    }
    
    void Throw(){
    //transform.LookAt(playerloc);
         //Send the message to the Animator to activate the trigger parameter named "Jump"
         m_Animator.Play(aniname,0,0.0f);
         Invoke("Shoot",throwDelay);
    }
    void Shoot()
    {
         
    
    
         GameObject shotIn = Instantiate(prefabBall, firePlace.position, transform.rotation);
         Rigidbody rb = shotIn.GetComponent<Rigidbody>();

         rb.AddForce(firePlace.forward*fireForce, ForceMode.Force);
         Destroy(shotIn,8);
    }
}
