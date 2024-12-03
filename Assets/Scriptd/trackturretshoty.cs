using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackturretshoty : MonoBehaviour
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
    int randx = 0;
    int randy = 0;
    int randz = 0;

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
         
            float rando = 0;
         for (int i = 0; i < 9; i++) 
        {
          rando = Random.Range(-0.2f, 0.2f);
          Invoke("Scatter",rando);
        }
         
    }




    void Scatter(){
        randx = Random.Range(-2, 2);
          randy = Random.Range(-2, 2);
          randz = Random.Range(-2, 2);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x+randx, transform.rotation.eulerAngles.y+randy, transform.rotation.eulerAngles.z+randz);

        GameObject shotIn = Instantiate(prefabBall, firePlace.position, transform.rotation);
         Rigidbody rb = shotIn.GetComponent<Rigidbody>();
         rb.AddForce(firePlace.forward*fireForce, ForceMode.Force);
         Destroy(shotIn,8);

    }
}
