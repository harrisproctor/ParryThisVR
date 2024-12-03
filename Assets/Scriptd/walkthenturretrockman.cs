using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkthenturretrockman : MonoBehaviour
{
    public Transform carrot;
    public GameObject prefabBall;
    public float fireForce;
    public Transform firePlace;
    public Transform playerloc;
    public float speed;
    public float throwDelay;
    Animator m_Animator;
    bool walking = false;
    bool turning = false;
    bool targetting = false;
    float lockPos = 0;
    public Transform target1;
    public Transform target2;
    private Transform target;
    Vector3 targetDirection;
    Transform old;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        
        target = target1;
        
        m_Animator.SetInteger("stateo",1);
         Invoke("Walktoggle",4f);
        

    }

    // Update is called once per frame
    void Update()
    {
         
        if(targetting){
          targetDirection = playerloc.position - transform.position;
       transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,  targetDirection, 0.01f, 0.0f));
       transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
        }

        if(walking){
       
    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    Walktoggle();
    }

    if(turning){
         
       transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,  targetDirection, 0.01f, 0.0f));
       if(transform.rotation.y > 0.71){
           Turnstop();
       }
       
      
      
    }


    }
   void Walktoggle()
   {

       float dist = Vector3.Distance(target.position, transform.position);
     if(dist > 0.5f){
         walking = true;
     }else{
         walking = false;
         if(target == target1){
             target = target2;
             targetDirection = target.position - transform.position;
             //Debug.Log("yeah");
             //m_Animator.SetInteger("stateo",3);
             turning = true;
             

             
         }else{
              m_Animator.SetInteger("stateo",0);
              Throw();
         }
         
     }
   }

   void Turnstop(){
       // m_Animator.SetInteger("stateo",1);
             turning = false;
        Walktoggle();

   }



     void Throw(){
    //transform.LookAt(playerloc);
         //Send the message to the Animator to activate the trigger parameter named "Jump"
         m_Animator.Play("throw2",0,0.0f);
         Invoke("Shoot",throwDelay);
    }

    void Shoot()
    {
        int rad = Random.Range(1, 50);
         
    
    
         GameObject shotIn = Instantiate(prefabBall, firePlace.position, transform.rotation);
         Rigidbody rb = shotIn.GetComponent<Rigidbody>();

         rb.AddForce(firePlace.forward*(fireForce+rad), ForceMode.Force);
         Destroy(shotIn,8);
         Invoke("Targettoggle",0.8f);

    }
    void Targettoggle(){
        if(targetting){
         targetting = false;
         Throw();
     }else{
         targetting = true;
         Invoke("Targettoggle",2f);
     }
    }




}
