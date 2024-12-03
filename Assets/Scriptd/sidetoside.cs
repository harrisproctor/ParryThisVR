using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidetoside : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float speed;
    bool goingup = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(goingup){
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
       float dist = Vector3.Distance(target.position, transform.position);
     if(dist < 0.5f)
     {
     goingup = false;
     }
        }else{
          //  Debug.Log("help");

        transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
       float dist = Vector3.Distance(target2.position, transform.position);
     if(dist < 0.5f)
     {
     goingup = true;
     }


        }




    }
    public void Goup()
    {
        goingup = true;
    }

}
