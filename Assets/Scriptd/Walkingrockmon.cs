using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkingrockmon : MonoBehaviour
{
     public GameObject prefabBall;
    public float fireForce;
    public Transform firePlace;
    public Transform playerloc;
    public float speed;
    public Transform target1;
     public Transform target2;
    private Transform target;
  
    public float throwDelay;
    public int range;
    private int steps;
    Animator m_Animator;
    bool walking = true;
    float lockPos = 0;
    Vector3 targetDirection;
    public int extra;
     public int starttime;
     string animatt = "Armature|shuffle";

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        target = target1;
        InvokeRepeating("Act", starttime, 3.0f);
    }

    void Update()
    {
    if(walking){
       Vector3 targetDirection = playerloc.position - transform.position;
       transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,  targetDirection, 0.01f, 0.0f));
       transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, lockPos);
       
    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
    }
    }

    void Act()
    {
    walking = false;
    Throw();
    steps += 1;
    if(steps > range){
    steps = 0;
    if(target == target1){
        target = target2;
        animatt = "Armature|shuffle";
    }else{
        target = target1;
        animatt = "Armature|shuffleleft";
    }
    }

    
    }

    void Walk(){
        m_Animator.Play(animatt,0,0.0f);
        walking = true;
    }
    

    void Throw(){
    //transform.LookAt(playerloc);
         //Send the message to the Animator to activate the trigger parameter named "Jump"
         m_Animator.Play("throw2",0,0.0f);
         Invoke("Shoot",throwDelay);
    }

    void Shoot()
    {
         
    
        int rad = Random.Range(1, extra);
         GameObject shotIn = Instantiate(prefabBall, firePlace.position, transform.rotation);
         Rigidbody rb = shotIn.GetComponent<Rigidbody>();

         rb.AddForce(firePlace.forward*(fireForce+rad), ForceMode.Force);
         Destroy(shotIn,8);
         Invoke("Walk",0.8f);

    }
}
